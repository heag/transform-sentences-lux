using System;

namespace TransformSentences.Application.Constanst
{
    public struct AppConstants
    {
        
    }

    public static class Separators
    {
        public const string OpenSquare = "[";
        public const string CloseSquare = "]";
        public const string OpenRound = "(";
        public const string CloseRound = ")";
    }

    public static class RegexPatters
    {
        public const string RoundPattern = @"\((.*?)\)";
        public const string SquarePattern = @"\[(.*?)\]";
    }

    public static class SentencesExamples
    {
        public const string FirstSentence = "Tests of a (sample) supplied by MeMFIS";
        public const string SecondSentence = "Tests of a sample [supplied by MeMFIS]";
        public const string ThirdSentence = "Tests of [a (sample supplied)] by MeMFIS";
        public const string FourthSentence = "Tests of [a ((sample) supplied)] by MeMFIS";
        public const string FifthSentence = "Tests of [a (sample (supplied word))] by MeMFIS";
        public const string EmptySentence = "";

        public const string MultipleRoundBrackets = "Tests of a (sample) supplied by MeMFIS (another) (round brackets)";
        public const string NestedRoundBrackets = "Tests of (a (zeta alpha beta) words) by MeMFIS";
        public const string NotClosingRoundBracket = "Tests of (not closing by MeMFIS";
        public const string NotOpeningRoundBracket = "Tests of not opening) by MeMFIS";
    }

    public static class WarningMessage
    {
        public const string NotClosingRoundBracket = "No closing bracket ) for current text";
        public const string NotOpeningRoundBracket = "No opening bracket ( for current text";

        public const string NotClosingSquareBracket = "No closing bracket ] for current text";
        public const string NotOpeningSquareBracket = "No opening bracket [ for current text";
    }
}
