using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NULL_MOOD, EMPTY_MOOD
        }
        public MoodAnalyzerException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
