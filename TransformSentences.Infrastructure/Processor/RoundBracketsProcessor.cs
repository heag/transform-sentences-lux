using System;
using System.Text;
using TransformSentences.Domain.Contract;
using TransformSentences.Application.Constanst;

namespace TransformSentences.Infrastructure.Processor
{
    public class RoundBracketsProcessor : IProcessText
    {
        private string textProcessed;
        private string toBeReplaced;
        IProcessText _processSquareBrackets;

        public RoundBracketsProcessor(IProcessText processSquareBrackets)
        {
            _processSquareBrackets = processSquareBrackets;
        }

        public string ProcessBracket(string textToProcess)
        {
            try
            {               
                bool exit = false;                
                do
                {
                    textProcessed = textToProcess;
                    int fromIndex = LastOpenIndex(textProcessed);
                    if (fromIndex > -1)
                    {
                        
                        string toProcessFormat = textProcessed.Substring(fromIndex);

                        int toIndex = FirstCloseIndex(toProcessFormat);

                        if (toIndex > -1)
                        {
                            toProcessFormat = toBeReplaced = toProcessFormat.Substring(0, FirstCloseIndex(toProcessFormat));
                            if(String.IsNullOrEmpty(toProcessFormat)) { return WarningMessage.NotClosingRoundBracket; }
                            toProcessFormat = FormatTextInsideBrackets(toProcessFormat);
                            textToProcess = textToProcess.Replace(toBeReplaced, toProcessFormat);                           
                        }
                    }
                    else
                    {
                        if(textProcessed.Contains(")")) { return WarningMessage.NotOpeningRoundBracket; }
                        exit = true;
                    }                    

                } while (!exit);


                return _processSquareBrackets.ProcessBracket(textToProcess);                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string FormatTextInsideBrackets(string textToFormat)
        {
            try
            {
                textToFormat = textToFormat.Remove(0, 1).Remove(textToFormat.Length - 2);
                textToFormat = ReverseString(textToFormat);

                string[] words = textToFormat.Split(' ');
                if (words.Length > 1)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = words.Length; i > 0; i--)
                    {
                        builder.Append(words[i - 1] + " ");
                    }
                    return builder.ToString().TrimEnd();
                }
                else
                {
                    return textToFormat;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private int FirstCloseIndex(string text)
        {
            return text.IndexOf(Separators.CloseRound) + 1;
        }

        private int LastOpenIndex(string text)
        {
            return text.LastIndexOf(Separators.OpenRound);
        }

    }
}
