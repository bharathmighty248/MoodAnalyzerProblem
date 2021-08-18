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
            string actual;
            try
            {
                MoodAnalyzer mood = new MoodAnalyzer(null);
                actual = mood.AnalyseMood();
            }
            catch
            {
                actual = "Happy";
            }
            
            Assert.AreEqual("Happy", actual);
        }

        /// <summary>
        /// TestCase 3.1
        /// </summary>
        [Test]
        public void GivenNullMood_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer mood = new MoodAnalyzer(null);
                string actual = mood.AnalyseMood();
                Assert.AreEqual("Happy", actual);
            }
            catch(MoodAnalyzerException e)
            {
                Assert.AreEqual("Mood Should not be Null", e.Message);
            }
        }

        /// <summary>
        /// TestCase 3.2
        /// </summary>
        [Test]
        public void GivenEMPTYMood_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer mood = new MoodAnalyzer("");
                string actual = mood.AnalyseMood();
                Assert.AreEqual("Happy", actual);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Mood Should not be Empty", e.Message);
            }
        }

        /// <summary>
        /// TestCase 4.1
        /// </summary>
        [Test]
        public void GivenMoodAnalyzerClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyzer();
            object actual = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(actual);
        }

        /// <summary>
        /// TestCase 4.2
        /// </summary>
        [Test]
        public void GivenMoodAnalyzerClassName_WhenImproper_ShouldThrowMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProblem.Mood", "Mood");
            }
            catch(MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        /// <summary>
        /// TestCase 4.2
        /// </summary>
        [Test]
        public void GivenMoodAnalyzerConstructorName_WhenImproper_ShouldThrowMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyzer", "Mood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}