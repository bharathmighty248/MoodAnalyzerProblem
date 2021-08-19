using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerReflector
    {
        public static object CreateMoodAnalyse(string className, string constructorName, string message = "")
        {
            if (message.Length == 0)
            {
                string pattern = @"." + constructorName + "";
                Match result = Regex.Match(className, pattern);
                try
                {
                    if (result.Success)
                    {
                        Assembly executing = Assembly.GetExecutingAssembly();
                        Type moodAnalyseType = executing.GetType(className);
                        if (!moodAnalyseType.Name.Equals(constructorName))
                        {
                            throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                        }
                        return Activator.CreateInstance(moodAnalyseType);
                    }
                    else
                    {
                        throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCHCLASS, "Class not found");
                    }
                }
                catch (MoodAnalyzerException e)
                {
                    return e.Message;
                }
            }
            else
            {
                Type type = Type.GetType(className);
                try
                {
                    if (type.FullName.Equals(className) || type.Name.Equals(className))
                    {
                        if (type.Name.Equals(constructorName))
                        {
                            ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                            object instance = info.Invoke(new object[] { message });
                            return instance;
                        }
                        else
                        {
                            throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                        }
                    }
                    else
                    {
                        throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCHCLASS, "Class not found");
                    }
                }
                catch (Exception e)
                {
                    return e;
                }
            }

        }

        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyzer");
                object moodAnalyseObject = MoodAnalyzerReflector.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo == null)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Method not found");
                }
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (MoodAnalyzerException e)
            {
                return e.Message;
            }
        }

        public static string SetFieldDynamic(string message, string fieldName)
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
                Type type = typeof(MoodAnalyzer);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (fieldInfo == null)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_FIELD, "Field not found");

                }
                if (message == null)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_MOOD, "Mood should not be null");
                }
                fieldInfo.SetValue(moodAnalyzer, message);
                return moodAnalyzer.msg;
            }
            catch (MoodAnalyzerException e)
            {
                return e.Message;
            }
        }
    }
}
