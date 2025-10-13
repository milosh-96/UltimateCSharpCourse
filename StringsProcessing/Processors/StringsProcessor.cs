using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsProcessing.Processors;
public class StringsProcessor
{
    public List<string> Process(List<string> words)
    {
        List<string> temp = new List<string>();
        foreach (string word in words)
        {
            temp.Add(TransformWord(word));
        }
        return temp;
    }

    protected virtual string TransformWord(string word) => word;
}
