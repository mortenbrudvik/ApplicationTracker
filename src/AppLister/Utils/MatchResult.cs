﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;
using static AppLister.Utils.StringMatcher;

[assembly: InternalsVisibleTo("Microsoft.Plugin.Program.UnitTests")]

namespace AppLister.Utils
{
    public class MatchResult
    {
        public MatchResult(bool success, StringMatcher.SearchPrecisionScore searchPrecision)
        {
            Success = success;
            SearchPrecision = searchPrecision;
        }

        public MatchResult(bool success, StringMatcher.SearchPrecisionScore searchPrecision, List<int> matchData, int rawScore)
        {
            Success = success;
            SearchPrecision = searchPrecision;
            MatchData = matchData;
            RawScore = rawScore;
        }

        public bool Success { get; set; }

        /// <summary>
        /// Gets the final score of the match result with search precision filters applied.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// The raw calculated search score without any search precision filtering applied.
        /// </summary>
        private int _rawScore;

        public int RawScore
        {
            get
            {
                return _rawScore;
            }

            set
            {
                _rawScore = value;
                Score = ScoreAfterSearchPrecisionFilter(_rawScore);
            }
        }

        /// <summary>
        /// Gets matched data to highlight.
        /// </summary>
        public List<int> MatchData { get; private set; }

        public StringMatcher.SearchPrecisionScore SearchPrecision { get; set; }

        public bool IsSearchPrecisionScoreMet()
        {
            return IsSearchPrecisionScoreMet(_rawScore);
        }

        private bool IsSearchPrecisionScoreMet(int rawScore)
        {
            return rawScore >= (int)SearchPrecision;
        }

        private int ScoreAfterSearchPrecisionFilter(int rawScore)
        {
            return IsSearchPrecisionScoreMet(rawScore) ? rawScore : 0;
        }
    }
}
