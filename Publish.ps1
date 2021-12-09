Param (
    [Parameter(Mandatory = $true)]
    [Version] $Version,

    [ValidateSet('Archive', 'Publish')]
    [string] $Mode = 'Publish'
)

Enum PublishMode {
    Archive = 0
    Publish = 1
}

$_Mode = [PublishMode]$Mode

Set-Location $(Get-Item "$PSScriptRoot").FullName

if (Get-Module Common) {
    Remove-Module Common -Force
}

if (Get-Module Antlr) {
    Remove-Module Antlr -Force
}

Import-Module ".\Build\Common.ps1"

if ($_Mode -eq [PublishMode]::Publish) {
    # git rev-parse HEAD
    $GitTagVersion = [Version]$(git describe --tags $(git rev-list --tags --max-count=1)).trimstart('v')

    if ($(git rev-parse --abbrev-ref HEAD) -ne "master") {
        throw "Publish is only allow in 'master' branch."
    }

    $GitCurrentCommitId = git rev-parse HEAD
    $GitLatestCommitId = git rev-parse origin/master

    if ($GitCurrentCommitId -ne $GitLatestCommitId) {
        throw "Not in the latest commit. (latest: $GitLatestCommitId)"
    }

    if ($(git diff --name-only).Length -gt 0) {
        throw "There are files that have been changed."
    }

    if ($GitTagVersion -ge $Version) {
        throw "The version is lower than the git tag. ($GitTagVersion >= $Version)"
    }

    $NugetApiKey = $Env:QSI_NUGET_API_KEY

    if ($NugetApiKey.Length -eq 0) {
        throw "QSI_NUGET_API_KEY environment variable not found."
    }
}

Class Task {
    [string] $Project
    [bool] $Antlr
 
    Task ([string] $Project, [bool] $Antlr) {
        $this.Project = $Project
        $this.Antlr = $Antlr
    }
}

$PublishDirectory = $(Resolve-Path-Safe ".\Publish")
$Tasks = 
[Task]::new("Qsi", $false),
[Task]::new("Qsi.MySql", $true),
[Task]::new("Qsi.PostgreSql", $false),
[Task]::new("Qsi.Oracle", $true),
[Task]::new("Qsi.SqlServer", $false),
[Task]::new("Qsi.MongoDB", $false),
[Task]::new("Qsi.PhoenixSql", $false),
[Task]::new("Qsi.Cql", $true),
[Task]::new("Qsi.PrimarSql", $false),
[Task]::new("Qsi.Hana", $true),
[Task]::new("Qsi.Impala", $true),
[Task]::new("Qsi.Trino", $true),
[Task]::new("Qsi.Athena", $true)

Function DotNet-Pack {
    Param (
        [Parameter(Mandatory = $true)][string] $ProjectName
    )

    Write-Host "[.NET] $($ProjectName) Pack" -ForegroundColor Cyan

    Remove-Directory-Safe "$ProjectName/bin"
    Remove-Directory-Safe "$ProjectName/obj"

    dotnet pack $ProjectName `
        --nologo `
        -v=q `
        -c Release `
        -o $PublishDirectory `
        -p:Version=$Version `
        -p:PackageVersion=$Version `
        -p:Packaging=true
}

Function NuGet-Push {
    Param (
        [Parameter(Mandatory = $true)]
        [System.IO.FileInfo] $PackageFile,

        [Parameter(Mandatory = $true)]
        [string] $Source,

        [Parameter(Mandatory = $true)]
        [string] $ApiKey
    )

    Write-Host "[NuGet] '$($PackageFile.Name)' Push to '$Source'" -ForegroundColor Cyan

    dotnet nuget push $PackageFile --source $Source --api-key $ApiKey
}

# Clean publish
Remove-Directory-Safe $PublishDirectory

$Tasks | ForEach-Object {
    if ($PSItem.Antlr) {
        & "$PSScriptRoot\Setup.ps1" $PSItem.Project
    }

    DotNet-Pack $PSItem.Project
}

Write-Host "Done pack." -ForegroundColor Green

if ($_Mode -eq [PublishMode]::Publish) {
    # Publish
    Get-ChildItem -Path $PublishDirectory/*.nupkg | ForEach-Object {
        NuGet-Push $PSItem "https://api.nuget.org/v3/index.json" $NugetApiKey
    }

    # Tag
    if ($_Mode -eq [PublishMode]::Publish) {
        $GitTag = "v$Version"
        git tag $GitTag
        git push origin $GitTag
    }

    Write-Host "Done $Version publish." -ForegroundColor Green
}
