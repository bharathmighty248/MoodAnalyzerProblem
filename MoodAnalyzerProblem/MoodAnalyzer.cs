using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        public readonly string msg;
        public MoodAnalyzer()
        {

        }
        public MoodAnalyzer(string msg)
        {
            this.msg = msg;
        }
        public string AnalyseMood()
        {
            string message = msg.ToLower();
            if (message.Contains("sad"))
                return "Sad";
            else
                return "Happy";
        }
    }
}
