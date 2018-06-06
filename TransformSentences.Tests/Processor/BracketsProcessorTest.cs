using System;
using Moq;
using NUnit.Framework;
using TransformSentences.Domain.Contract;
using TransformSentences.Application.Constanst;
using TransformSentences.Infrastructure.Processor;
using TransformSentences;

namespace TransformSentences.Tests.Processor
{
    [TestFixture]
    class BracketsProcessorTest
    {
        private ProcessString _processString;
        private RoundBracketsProcessor _roundBracketsProcessor;
        private SquareBracketProcessor _squareBracketsProcessor;

        [SetUp]
        public void SetUp()
        {
            _squareBracketsProcessor = new SquareBracketProcessor();
            _roundBracketsProcessor = new RoundBracketsProcessor(_squareBracketsProcessor);
            _processString = new ProcessString(_roundBracketsProcessor);
        }

        #region RoundTests
        [TestCase]
        public void SingleRoundBracketsText()
        {
            string expected = "Tests of a elpmas supplied by MeMFIS";

            string actual = _processString.ProcessText(SentencesExamples.FirstSentence);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MultipleRoundBracketsText()
        {
            string expected = "Tests of a elpmas supplied by MeMFIS rehtona dnuor stekcarb";

            string actual = _processString.ProcessText(SentencesExamples.MultipleRoundBrackets);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NestedRoundBracketsText()
        {
            string expected = "Tests of a zeta alpha beta sdrow by MeMFIS";

            string actual = _processString.ProcessText(SentencesExamples.NestedRoundBrackets);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NotClosingRoundBracketFound()
        {
            string expected = WarningMessage.NotClosingRoundBracket;

            string actual = _processString.ProcessText(SentencesExamples.NotClosingRoundBracket);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NotOpeningRoundBracketFound()
        {
            string expected = WarningMessage.NotOpeningRoundBracket;

            string actual = _processString.ProcessText(SentencesExamples.NotOpeningRoundBracket);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FormatTextProperly()
        {
            string expected = "elpmas";

            string actual = _roundBracketsProcessor.FormatTextInsideBrackets("(sample)");

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region SquareTests
        [TestCase]
        public void SingleSquareBracketsText()
        {
            string expected = "Tests of a sample by MeMFIS supplied";

            string actual = _processString.ProcessText(SentencesExamples.SecondSentence);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MultipleSquareBracketsText()
        {
            string expected = "Tests of a elpmas supplied by MeMFIS rehtona dnuor stekcarb";

            string actual = _processString.ProcessText(SentencesExamples.MultipleRoundBrackets);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NestedSquareBracketsText()
        {
            string expected = "Tests of a zeta alpha beta sdrow by MeMFIS";

            string actual = _processString.ProcessText(SentencesExamples.NestedRoundBrackets);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NotClosingSquareBracketFound()
        {
            string expected = WarningMessage.NotClosingSquareBracket;

            string actual = _processString.ProcessText(SentencesExamples.NotClosingSquareBracket);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NotOpeningSquareBracketFound()
        {
            string expected = WarningMessage.NotOpeningSquareBracket;

            string actual = _processString.ProcessText(SentencesExamples.NotOpeningSquareBracket);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FormatTextProperlySquare()
        {
            string expected = "alpha beta zeta";

        string actual = _squareBracketsProcessor.FormatTextInsideBrackets("[zeta beta alpha]");

            Assert.AreEqual(expected, actual);
        }
        #endregion

    }
}
