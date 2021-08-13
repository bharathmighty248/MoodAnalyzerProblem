using MoodAnalyzerProblem;
using NUnit.Framework;

namespace MoodAnalyzerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// TestCase 1.1
        /// </summary>
        [Test]
        public void GivenSadMessage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyzer mood = new MoodAnalyzer();
            string actual = mood.AnalyseMood("Iam in sad Mood");
            Assert.AreEqual("Sad", actual);
        }

        /// <summary>
        /// TestCase 1.2
        /// </summary>
        [Test]
        public void GivenAnyMoodMessage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyzer mood = new MoodAnalyzer();
            string actual = mood.AnalyseMood("Iam in Any Mood");
            Assert.AreEqual("Happy", actual);
        }
    }
}