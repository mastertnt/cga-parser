using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace CGAParser
{
    public static class Common
    {
        /// <summary>
        /// Parser for an identifier (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<string> IDENTIFIER_PARSER =
        from lFirstLetter in Parse.Letter.Once()
        from lRest in Parse.LetterOrDigit.Many()
        select new string(lFirstLetter.Concat(lRest).ToArray());

        public static readonly Parser<char> SPACE = Parse.Char(' ');

        /// <summary>
        /// Generic method to create a parser for an enumeration value.
        /// </summary>
        /// <returns></returns>
        public static Parser<TEnumType> CreateEnumParser<TEnumType>(Dictionary<TEnumType, string> pMappings)
        {
            var lParser = Parse.String(pMappings.First().Value).Return(pMappings.First().Key);
            foreach (var lMapping in pMappings.Skip(1))
            {
                lParser = lParser.Or(Parse.String(lMapping.Value).Return(lMapping.Key));
            }

            return lParser;
        }
    }
}
