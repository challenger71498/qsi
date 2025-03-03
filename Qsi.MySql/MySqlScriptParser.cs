﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Qsi.Data;
using Qsi.Parsing.Common;
using Qsi.Shared.Extensions;

namespace Qsi.MySql
{
    public class MySqlScriptParser : CommonScriptParser
    {
        private const string table = "TABLE";
        private const string delimiter = "DELIMITER";
        private const string deallocate = "DEALLOCATE";
        private const string prepare = "PREPARE";
        private const string desc = "DESC";

        private const string XA = "XA";
        private const string BEGIN = "BEGIN";
        private const string END = "END";
        private const string IF = "IF";
        private const string ELSEIF = "ELSEIF";
        private const string ELSE = "ELSE";
        private const string WHILE = "WHILE";
        private const string DO = "DO";
        private const string REPEAT = "REPEAT";
        private const string UNTIL = "UNTIL";
        private const string LOOP = "LOOP";
        private const string CASE = "CASE";
        private const string WHEN = "WHEN";
        private const string THEN = "THEN";

        private readonly Regex _delimiterPattern = new(@"\G\S+(?=\s|$)");

        public bool UseDelimiter { get; set; } = true;

        public override IEnumerable<QsiScript> Parse(string input, CancellationToken cancellationToken)
        {
            if (!UseDelimiter)
            {
                return ParseWithoutDelimiter(input, cancellationToken);
            }

            return base.Parse(input, cancellationToken);
        }

        private IEnumerable<QsiScript> ParseWithoutDelimiter(string input, CancellationToken cancellationToken)
        {
            var context = new ParseContext(input, ";", cancellationToken);
            using IEnumerator<Token> tokenEnumerator = ParseTokens(context.Cursor).GetEnumerator();
            var tokenStream = new BufferedTokenStream(input, tokenEnumerator);

            while (tokenStream.TryNext(out var token))
            {
                if (TryParseBeginEndBlockState(context, tokenStream, out var label))
                {
                    context.AddToken(token);
                    ProcessBeginEndBlock(context, tokenStream, label);

                    var script = CreateScript(context, context.Tokens);
                    context.ClearTokens();

                    yield return script;
                }
                else if (context.Cursor.Value[token.Span] == ";")
                {
                    foreach (var script in BuildScripts(context))
                        yield return script;
                }
                else
                {
                    context.AddToken(token);
                }
            }

            foreach (var script in BuildScripts(context))
                yield return script;
        }

        #region Block
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessInnerStatements(ParseContext context, BufferedTokenStream stream, in Token token)
        {
            if (context.Cursor.Value[token.Span] == ";")
            {
                // skip
            }
            else if (TryParseBeginEndBlockState(context, stream, out var innerState))
            {
                ProcessBeginEndBlock(context, stream, innerState);
            }
            else if (TryParseIfBlock(context, stream))
            {
                ProcessIfBlock(context, stream);
            }
            else if (TryParseWhileBlock(context, stream))
            {
                ProcessWhileBlock(context, stream);
            }
            else if (TryParseRepeatBlock(context, stream))
            {
                ProcessRepeatBlock(context, stream);
            }
            else if (TryParseLoopBlock(context, stream))
            {
                ProcessLoopBlock(context, stream);
            }
            else if (TryParseCaseBlock(context, stream))
            {
                ProcessCaseBlock(context, stream);
            }
            else
            {
                context.AddToken(token);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseBeginEndBlockState(ParseContext context, BufferedTokenStream stream, out string label)
        {
            label = null;

            // BEGIN .. END -> O
            // XA BEGIN ..  -> X
            if (stream.IsKeyword(BEGIN) && !stream.IsKeyword(XA, -1))
            {
                Token? labelColonToken = stream.Get(-1);

                if (labelColonToken.HasValue && labelColonToken.Value.Type == TokenType.Identifier)
                {
                    label = context.Cursor.Value[labelColonToken.Value.Span];
                    label = label.EndsWith(':') ? label[..^1] : null;
                }

                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessBeginEndBlock(ParseContext context, BufferedTokenStream stream, string label)
        {
            // label: BEGIN| ..
            //             ^ current

            while (stream.TryNext(out var token))
            {
                // .. END [<label>]|
                //                 ^ end
                if (stream.IsKeyword(END))
                {
                    context.AddToken(token);

                    if (label != null && stream.IsKeyword(label, 1))
                    {
                        stream.TryNext(out var nextToken);
                        context.AddToken(nextToken);
                    }

                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseIfBlock(ParseContext context, BufferedTokenStream stream)
        {
            return stream.IsKeyword(IF);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessIfBlock(ParseContext context, BufferedTokenStream stream)
        {
            // IF| ..
            //   ^ current

            if (!SkipToThen())
                throw new QsiException(QsiError.Syntax);

            // IF .. THEN|
            //           ^ current

            while (stream.TryNext(out var token))
            {
                var text = context.Cursor.Value[token.Span];
                context.AddToken(token);

                if (text.EqualsIgnoreCase(ELSEIF))
                {
                    if (!SkipToThen())
                        throw new QsiException(QsiError.Syntax);
                }
                else if (text.EqualsIgnoreCase(ELSE))
                {
                    // skip
                }
                else if (text.EqualsIgnoreCase(END) && stream.IsKeyword(IF, 1))
                {
                    stream.TryNext(out var nextToken);
                    context.AddToken(nextToken);
                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }

            bool SkipToThen()
            {
                while (stream.TryNext(out var token))
                {
                    var text = context.Cursor.Value[token.Span];
                    context.AddToken(token);

                    if (text == ";")
                        return false;

                    if (THEN.EqualsIgnoreCase(text))
                        return true;
                }

                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseWhileBlock(ParseContext context, BufferedTokenStream stream)
        {
            return stream.IsKeyword(WHILE);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessWhileBlock(ParseContext context, BufferedTokenStream stream)
        {
            // WHILE| ..
            //      ^ current

            if (!SkipToDo())
                throw new QsiException(QsiError.Syntax);

            // WHILE .. DO| ..
            //            ^ current

            while (stream.TryNext(out var token))
            {
                context.AddToken(token);

                if (stream.IsKeyword(END) && stream.IsKeyword(WHILE, 1))
                {
                    stream.TryNext(out var nextToken);
                    context.AddToken(nextToken);
                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }

            bool SkipToDo()
            {
                while (stream.TryNext(out var token))
                {
                    var text = context.Cursor.Value[token.Span];
                    context.AddToken(token);

                    if (text == ";")
                        return false;

                    if (DO.EqualsIgnoreCase(text))
                        return true;
                }

                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseRepeatBlock(ParseContext context, BufferedTokenStream stream)
        {
            return stream.IsKeyword(REPEAT);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessRepeatBlock(ParseContext context, BufferedTokenStream stream)
        {
            // REPEAT|
            //       ^ current

            while (stream.TryNext(out var token))
            {
                context.AddToken(token);

                // UNTIL .. END REPEAT
                if (stream.IsKeyword(UNTIL))
                {
                    while (stream.TryNext(out _))
                    {
                        context.AddToken(token);

                        if (stream.IsKeyword(END))
                            break;
                    }

                    if (!stream.IsKeyword(REPEAT, 1))
                        throw new QsiException(QsiError.Syntax);

                    stream.TryNext(out var nextToken);
                    context.AddToken(nextToken);

                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseLoopBlock(ParseContext context, BufferedTokenStream stream)
        {
            return stream.IsKeyword(LOOP);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessLoopBlock(ParseContext context, BufferedTokenStream stream)
        {
            // LOOP|
            //     ^ current

            while (stream.TryNext(out var token))
            {
                context.AddToken(token);

                // .. END LOOP
                if (stream.IsKeyword(END) && stream.IsKeyword(LOOP, 1))
                {
                    stream.TryNext(out var nextToken);
                    context.AddToken(nextToken);
                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryParseCaseBlock(ParseContext context, BufferedTokenStream stream)
        {
            return stream.IsKeyword(CASE);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessCaseBlock(ParseContext context, BufferedTokenStream stream)
        {
            // CASE|
            //     ^ current

            while (stream.TryNext(out var token))
            {
                var text = context.Cursor.Value[token.Span];
                context.AddToken(token);

                if (WHEN.EqualsIgnoreCase(text))
                {
                    // WHEN .. THEN

                    if (!SkipToThen())
                        throw new QsiException(QsiError.Syntax);
                }
                else if (ELSE.EqualsIgnoreCase(text))
                {
                    // ELSE
                }
                else if (END.EqualsIgnoreCase(text) && stream.IsKeyword(CASE, 1))
                {
                    // END CASE

                    stream.TryNext(out var nextToken);
                    context.AddToken(nextToken);
                    break;
                }

                ProcessInnerStatements(context, stream, token);
            }

            bool SkipToThen()
            {
                while (stream.TryNext(out var token))
                {
                    var text = context.Cursor.Value[token.Span];
                    context.AddToken(token);

                    if (text == ";")
                        return false;

                    if (THEN.EqualsIgnoreCase(text))
                        return true;
                }

                return false;
            }
        }
        #endregion

        protected override bool TryParseToken(CommonScriptCursor cursor, out Token token)
        {
            const TokenType labelType = TokenType.Keyword | TokenType.Identifier;

            if (!UseDelimiter && cursor.Current == ';')
            {
                token = new Token(TokenType.Fragment, new Range(cursor.Index, cursor.Index + 1));
                return true;
            }

            if (!base.TryParseToken(cursor, out token))
                return false;

            if (labelType.HasFlag(token.Type) && cursor.Next == ':')
            {
                var (offset, length) = token.Span.GetOffsetAndLength(cursor.Length);
                token = new Token(TokenType.Identifier, new Range(offset, offset + length + 1));
                cursor.Index++;
            }

            return true;
        }

        protected override bool IsEndOfScript(ParseContext context)
        {
            if (UseDelimiter)
            {
                IReadOnlyList<Token> tokens = context.Tokens;

                if (tokens.Count > 1 &&
                    tokens[^1].Type == TokenType.WhiteSpace &&
                    tokens[^2].Type == TokenType.Keyword &&
                    delimiter.EqualsIgnoreCase(context.Cursor.Value[tokens[^2].Span]) &&
                    tokens.SkipLast(2).All(t => TokenType.Trivia.HasFlag(t.Type)))
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
            }

            return base.IsEndOfScript(context);
        }

        protected override QsiScriptType GetSuitableType(CommonScriptCursor cursor, IReadOnlyList<Token> tokens, Token[] leadingTokens)
        {
            return leadingTokens.Length switch
            {
                >= 1 when table.EqualsIgnoreCase(cursor.Value[leadingTokens[0].Span]) => QsiScriptType.Select,
                >= 1 when desc.EqualsIgnoreCase(cursor.Value[leadingTokens[0].Span]) => QsiScriptType.Describe,
                >= 2 when deallocate.EqualsIgnoreCase(cursor.Value[leadingTokens[0].Span]) &&
                          prepare.EqualsIgnoreCase(cursor.Value[leadingTokens[1].Span]) => QsiScriptType.DropPrepare,
                _ => base.GetSuitableType(cursor, tokens, leadingTokens)
            };
        }

        private class BufferedTokenStream
        {
            private readonly string _input;
            private readonly IEnumerator<Token> _enumerator;
            private readonly List<Token> _buffer;

            private int _position;

            public BufferedTokenStream(string input, IEnumerator<Token> enumerator)
            {
                _input = input;
                _enumerator = enumerator;
                _buffer = new List<Token>();
            }

            public Token? Get(int offset)
            {
                var index = _position + offset - 1;

                if (index >= 0 && index < _buffer.Count)
                    return _buffer[index];

                return null;
            }

            public bool TryNext(out Token token)
            {
                if (_position < _buffer.Count)
                {
                    token = _buffer[_position++];
                    return true;
                }

                while (_enumerator.MoveNext())
                {
                    if (TokenType.Trivia.HasFlag(_enumerator.Current.Type))
                        continue;

                    token = _enumerator.Current;
                    _buffer.Add(token);
                    _position++;
                    return true;
                }

                token = default;
                return false;
            }

            public bool IsKeyword(string keyword)
            {
                if (_position == 0)
                    return false;

                return keyword.EqualsIgnoreCase(_input[_buffer[_position - 1].Span]);
            }

            public bool IsKeyword(string keyword, int offset)
            {
                if (offset == 0)
                    return IsKeyword(keyword);

                if (offset < 0)
                {
                    offset = -offset;

                    for (int i = _position - offset - 1; i >= 0; i--)
                    {
                        var token = _buffer[i];

                        if (token.Type != TokenType.Keyword)
                            return false;

                        if (--offset == 0)
                            return keyword.EqualsIgnoreCase(_input[token.Span]);
                    }

                    return false;
                }

                var save = _position;

                try
                {
                    while (TryNext(out var token))
                    {
                        if (token.Type != TokenType.Keyword)
                            return false;

                        if (--offset == 0)
                            return keyword.EqualsIgnoreCase(_input[token.Span]);
                    }
                }
                finally
                {
                    _position = save;
                }

                return false;
            }
        }
    }
}
