using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TransformSentences.Domain.Contract;
using TransformSentences.Application.Constanst;

namespace TransformSentences.Infrastructure.Processor
{
    public class SquareBracketProcessor : IProcessText
    {
        private string textProcessed;
        private string toBeReplaced;
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
                            if (String.IsNullOrEmpty(toProcessFormat)) { return WarningMessage.NotClosingSquareBracket; }
                            toProcessFormat = FormatTextInsideBrackets(toProcessFormat);
                            textToProcess = textToProcess.Replace(toBeReplaced, toProcessFormat);
                        }
                    }
                    else
                    {
                        if (textProcessed.Contains("]")) { return WarningMessage.NotOpeningSquareBracket; }
                        exit = true;
                    }

                } while (!exit);


                return textToProcess;
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

                string[] words = textToFormat.Split(' ');
                Array.Sort(words);

                if (words.Length > 1)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < words.Length; i++)
                    {
                        builder.Append(words[i] + " ");
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

        private int FirstCloseIndex(string text)
        {
            return text.IndexOf(Separators.CloseSquare) + 1;
        }

        private int LastOpenIndex(string text)
        {
            return text.LastIndexOf(Separators.OpenSquare);
        }
    }
}
