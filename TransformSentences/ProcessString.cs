using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransformSentences.Domain.Contract;
using TransformSentences.Infrastructure.Processor;
using TransformSentences.Application.Constanst;

namespace TransformSentences
{
    public class ProcessString
    {
        IProcessText _textProcessor;
        public ProcessString(IProcessText textProcessor)
        {
            _textProcessor = textProcessor;
        }

        public string ProcessText(string text)
        {
            return _textProcessor.ProcessBracket(text);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Insert text to format: ");
            //Console.ReadLine();
            string round = SentencesExamples.ThirdSentence;
            Console.WriteLine("Original Text: " + round);

            ProcessString obj = new ProcessString(new RoundBracketsProcessor(new SquareBracketProcessor()));

            string formattedText = obj.ProcessText(round);
            Console.WriteLine("Processed Text: " + formattedText);
            Console.ReadLine();
        }
    }
        
}
