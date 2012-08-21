using System;
using blogger2jekyll.Blogger;

namespace blogger2jekyll.Jekyll
{
    /// <summary>
    /// Utility for performing tokenization and/or keyword expansion as a step in the export process.
    /// </summary>
    public class Tokenizer
    {
        /// <summary>
        /// Expands the specified keyword in the provided <see cref="Entry"/>'s content field.
        /// </summary>
        /// <param name="keywordToExpand">The keyword to expand.</param>
        /// <param name="valueToSubstitute">The value to substitute.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>Chainable reference to <b>entry</b>.</returns>
        public Entry Expand(string keywordToExpand, string valueToSubstitute, Entry entry)
        {
            throw new NotImplementedException();
        }
    }
}