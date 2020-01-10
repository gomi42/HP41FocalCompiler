using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FocalCompiler
{
    class Token
    {
        public enum TokType
        {
            Id,
            Int,
            Letter,
            Indirect,
            Komma,
            Append,
            Number,
            Text,
            Comment,
            Eol
        }

        public TokType TokenType;
        public short IntValue;
        public String StringValue;

        public Token ()
        {
        }

        public Token (Token Token2)
        {
            TokenType = Token2.TokenType;
            IntValue = Token2.IntValue;
            StringValue = Token2.StringValue;
        }
    }

    //////////////////////////////////////////////////////////////////

    class Lex
    {
        Dictionary<String, Token> Defines = new Dictionary<string, Token> ();

        Regex Parser;
        Match Match;

        /////////////////////////////////////////////////////////////

        bool GetNextToken (ref Token Token)
        {
            const int RegexIdxAll        = 0;
            const int RegexIdxQuotedText = 1;
            const int RegexIdxText       = 2;
            const int RegexIdxNumber     = 4;
            const int RegexIdxExponent   = 7;
            const int RegexIdxSingleExponent = 8;
            const int RegexIdxIndirect   = 9;
            const int RegexIdxLetter     = 10;
            const int RegexIdxComment    = 11;
            const int RegexIdxKomma      = 12;
            const int RegexIdxAppend     = 13;
            const int RegexIdxId         = 14;

            if (Match.Groups[RegexIdxIndirect].Success)
            {
                Token.TokenType = Token.TokType.Indirect;
                return true;
            }

            if (Match.Groups[RegexIdxNumber].Success)
            {
                if (Match.Groups[RegexIdxExponent].Success || Match.Groups[RegexIdxSingleExponent].Success)
                {
                    Token.TokenType = Token.TokType.Number;
                    Token.StringValue = Match.Groups[RegexIdxNumber].Value;
                }
                else
                {
                    Token.TokenType = Token.TokType.Int;
                    Int16.TryParse (Match.Groups[RegexIdxNumber].Value, out Token.IntValue);
                    Token.StringValue = Match.Groups[RegexIdxNumber].Value;
                }

                return true;
            }

            if (Match.Groups[RegexIdxLetter].Success)
            {
                Token.TokenType = Token.TokType.Letter;
                Token.StringValue = Match.Groups[RegexIdxLetter].Value;
                return true;
            }

            if (Match.Groups[RegexIdxKomma].Success)
            {
                Token.TokenType = Token.TokType.Komma;
                return true;
            }

            if (Match.Groups[RegexIdxAppend].Success)
            {
                Token.TokenType = Token.TokType.Append;
                return true;
            }

            if (Match.Groups[RegexIdxQuotedText].Success)
            {
                Token.TokenType = Token.TokType.Text;
                Token.StringValue = Match.Groups[RegexIdxText].Value;
                return true;
            }

            if (Match.Groups[RegexIdxId].Success)
            {
                Token.TokenType = Token.TokType.Id;
                Token.StringValue = Match.Groups[RegexIdxId].Value;

                Token DefineToken;

                if (Defines.TryGetValue (Token.StringValue, out DefineToken))
                {
                    Token.TokenType = DefineToken.TokenType;
                    Token.StringValue = DefineToken.StringValue;
                    Token.IntValue = DefineToken.IntValue;
                }
                return true;
            }

            if (Match.Groups[RegexIdxComment].Success)
            {
                Token.TokenType = Token.TokType.Comment;
                Token.StringValue = Match.Groups[RegexIdxComment].Value;
                return true;
            }

            Token.TokenType = Token.TokType.Eol;
            Token.StringValue = Match.Groups[RegexIdxAll].Value;
            return false;
        }

        /////////////////////////////////////////////////////////////

        public bool GetFirstToken (String Line, ref Token Token)
        {
            if (Parser == null)
            {
                //1:$[1] # 2:$[2] # 3:$[3] # 4:$[4] # 5:$[5] # 6:$[6] # 7:$[7] # 8:$[8] # 9:$[9] # 10:$[10] # 11:$[11] # 12:$[12]
                Parser = new Regex (@"(""(.+)"")|(((-?\d*\.?\d+((e)-?\d+)?)|(e-?\d+))(?=[\t ,]|$))|(ind)|([A-Z](?=[\t ,]|$))|(;.*$)|(,)|(>)|([^, \t]+)", RegexOptions.IgnoreCase);
            }

            Match = Parser.Match (Line);

            if (Match.Success)
            {
                return GetNextToken (ref Token);
            }

            Token.TokenType = Token.TokType.Eol;
            Token.StringValue = Match.Groups[0].Value;
            return false;
        }

        /////////////////////////////////////////////////////////////

        public bool GetToken (ref Token Token)
        {
            Match = Match.NextMatch ();

            if (Match.Success)
            {
                return GetNextToken (ref Token);
            }

            Token.TokenType = Token.TokType.Eol;
            Token.StringValue = Match.Groups[0].Value;
            return false;
        }

        /////////////////////////////////////////////////////////////

        public void AddDefine (String Define, Token Token)
        {
            Defines.Add (Define, new Token (Token));
        }
    }
}
