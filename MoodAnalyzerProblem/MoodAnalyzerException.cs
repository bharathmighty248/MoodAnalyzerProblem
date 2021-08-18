using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerException : Exception
    {
        public readonly ExceptionType type;
        public enum ExceptionType
        {
            NULL_MOOD, EMPTY_MOOD, NO_SUCHCLASS, NO_SUCH_CONSTRUCTOR
        }
        public MoodAnalyzerException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
