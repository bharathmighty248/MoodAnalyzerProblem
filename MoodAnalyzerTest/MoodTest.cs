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
            MoodAnalyzer mood = new MoodAnalyzer("Iam in sad Mood");
            string actual = mood.AnalyseMood();
            Assert.AreEqual("Sad", actual);
        }

        /// <summary>
        /// TestCase 1.2
        /// </summary>
        [Test]
        public void GivenAnyMoodMessage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyzer mood = new MoodAnalyzer("Iam in Happy Mood");
            string actual = mood.AnalyseMood();
            Assert.AreEqual("Happy", actual);
        }

        /// <summary>
        /// TestCase 2.1
        /// </summary>
        [Test]
        public void GivenNullMessage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyzer mood = new MoodAnalyzer(null);
            string actual = mood.AnalyseMood();
            Assert.AreEqual("Happy", actual);
        }
    }
}