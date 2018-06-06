using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformSentences.Domain.Contract
{
    public interface IProcessText
    {
        string ProcessBracket(string text);
    }
}
