﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Qsi.Parsing.Common;

namespace Qsi.MySql
{
    public class MySqlScriptParser : CommonScriptParser
    {
        private readonly Regex _delimiterPattern = new Regex(@"\G\S+(?=\s|$)");
        private readonly TokenType _effectiveType = TokenType.Keyword | TokenType.Literal;

        protected override bool IsEndOfScript(ParseContext context)
        {
            IReadOnlyList<Token> tokens = context.Tokens;

            if (tokens.Count > 1 &&
                tokens[^1].Type == TokenType.WhiteSpace &&
                tokens[^2].Type == TokenType.Keyword &&
                context.Cursor.Value[tokens[^2].Span].Equals("DELIMITER", StringComparison.OrdinalIgnoreCase) &&
                (tokens.Count == 2 || !_effectiveType.HasFlag(tokens[^3].Type)))
            {
                var match = _delimiterPattern.Match(context.Cursor.Value, context.Cursor.Index);

                if (match.Success)
                {
                    context.Cursor.Index = match.Index + match.Length - 1;
                    context.Delimiter = match.Value;
                    context.AddToken(new Token(TokenType.Fragment, match.Index..(context.Cursor.Index + 1)));

                    return true;
                }
            }

            return base.IsEndOfScript(context);
        }
    }
}
