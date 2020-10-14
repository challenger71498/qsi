﻿using System.Collections.Generic;
using Qsi.Analyzers;
using Qsi.Data;
using Qsi.Parsing;
using Qsi.Services;

namespace Qsi.MongoDB
{
    public class MongoDBLanguageServiceBase : IQsiLanguageService
    {
        public QsiAnalyzerOptions CreateAnalyzerOptions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<QsiAnalyzerBase> CreateAnalyzers(QsiEngine engine)
        {
            throw new System.NotImplementedException();
        }

        public IQsiTreeParser CreateTreeParser()
        {
            throw new System.NotImplementedException();
        }

        public IQsiTreeDeparser CreateTreeDeparser()
        {
            throw new System.NotImplementedException();
        }

        public IQsiScriptParser CreateScriptParser()
        {
            return new MongoDBScriptParser();
        }

        public IQsiRepositoryProvider CreateRepositoryProvider()
        {
            throw new System.NotImplementedException();
        }

        public bool MatchIdentifier(QsiIdentifier x, QsiIdentifier y)
        {
            throw new System.NotImplementedException();
        }
    }
}
