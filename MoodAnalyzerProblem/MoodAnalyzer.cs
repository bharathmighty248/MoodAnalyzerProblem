using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        public string AnalyseMood(string msg)
        {
            string message = msg.ToLower();
            if (message.Contains("sad"))
                return "Sad";
            else
                return "Happy";
        }
    }
}
