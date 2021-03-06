using System;
using System.Collections.Generic;
using System.Linq;
using RepoInspector.Records;

namespace RepoInspector.Analysis.Scoring
{
    public class WordCountScorer :
        PullRequestScorer
    {
        public const string Label = "WordCount";
        public override double ScoreMultiplier => 0.1;
        public override string Attribute => Label;

        private readonly IWordCounter _wc;
        
        public WordCountScorer(){}    // For deserialization only

        public WordCountScorer(IWordCounter wordCounter)
        {
            _wc = wordCounter ?? throw new ArgumentNullException(nameof(wordCounter));
        }

        public override int Count(PullRequest prDetails)
            => GetWordCounts(prDetails).Sum();

        public IEnumerable<int> GetWordCounts(PullRequest prDetails)
        {
            return prDetails.FullCommentary
                .Select(c => _wc.Count(c.Text))
                .Concat(new[]
                {
                    _wc.Count(prDetails.Title),
                    _wc.Count(prDetails.Body)   
                });
        }
    }
}