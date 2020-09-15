![Logo](https://github.com/chequer-io/qsi/blob/master/Resources/logo-256.png?raw=true)

The QSI is the pure C# Query Structure Interface.

### Features

|Language|Parser|Repos|
|--|--|--|
|MySql|Antlr4|[grammars-v4](https://github.com/antlr/grammars-v4)|
|PostgreSql10|PostgreSQL server source code|[libpg_query](https://github.com/lfittl/libpg_query), [ChakraCore](https://github.com/microsoft/ChakraCore)|
|JSql|JavaCC|[JSqlParser](https://github.com/JSQLParser/JSqlParser), [IKVM](https://github.com/ikvm-revived/ikvm)|


### Common Structure Compiler
It compiles the result structure and relation 

based on semantic tree generated by parser's  for each language.

## Development

#### Requirements

- PowerShell
- .NET Core 3.1
- Java >= 1.8

### Command

#### Setup

```ps1
PS> cd ./qsi
PS> ./Setup.ps1
```

#### Publish

```ps1
PS> cd ./qsi
PS> ./Publish.ps1 <VERSION> [-Mode <PUBLISH_MODE>]
```

- `<VERSION>`

  Specifies the package version.
  
  Version must be greater than the latest version tag on git.

- `-Mode <PUBLISH_MODE>`

  Specifies the publish mode.
  
  |PUBLISH_MODE|Action|
  |--|--|
  |Publish(Default)|Publish packages to NuGet, GitHub repositories|
  |Local|Publish packages to local repository|
  |Archive|Build packages to `./qsi/Publish`|
  
  

### Debugger

It supports abstract syntax trees and semantic trees, and a debugger that can debug compilation results.

|OS|Support|
|--|--|
|Windows|O|
|OSX|O|
|Linux|X|

![Preview](https://github.com/chequer-io/qsi/blob/master/Qsi.Debugger/Screenshot.png?raw=true)

### Run
```sh
$ cd qsi/Qsi.Debugger
$ dotnet run
```
