using System.Text.RegularExpressions;

namespace RepoMan.Analysis.Counters
{
    class UrlCounter :
        ICounter
    {
        private static readonly Regex _url = new Regex(@"(https?):\/\/[^\s$.?#].[^\s]*", RegexOptions.Compiled | RegexOptions.Multiline);

        public int Count(string s) =>
            string.IsNullOrWhiteSpace(s)
                ? 0
                : _url.Matches(s).Count;
    }
}