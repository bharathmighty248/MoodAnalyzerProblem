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
            if (msg == null)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_MOOD, "Mood Should not be Null");
            }
            try
            {
                if (msg.Length==0)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_MOOD, "Mood Should not be Empty");
                }
                else
                {
                    string message = msg.ToLower();
                    if (message.Contains("sad"))
                    {
                        return "Sad";
                    }
                    else
                    {
                        return "Happy";
                    }
                }
                
            }
            catch
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_MOOD, "Mood Should not be Empty");
            }
        }
    }
}
