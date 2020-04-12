using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMLab
{
    public class PhraseSearcher
    {
        private readonly int _allowedFrequency;

        public PhraseSearcher(int allowedFrequency)
        {
            _allowedFrequency = allowedFrequency;
        }

        public string GetPhrase(string text)
        {
            var charactersToReplace = GetCharactersToReplace(text);
            return Replace(text, charactersToReplace.ToList());

        }

        private IEnumerable<char> GetCharactersToReplace(string text)
        {
            return text.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .Where(x => x.Value > _allowedFrequency)
                .Select(x => x.Key);
        }

        private string Replace(string text, IReadOnlyCollection<char> charactersToReplace)
        {
            var sb = new StringBuilder();
            foreach (var c in text.Where(c => !charactersToReplace.Contains(c)))
            {
                sb.Append(c, 1);
            }

            return sb.ToString();
        }
    }
}
