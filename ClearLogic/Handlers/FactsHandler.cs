using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Handlers;

public class FactsHandler
{
    const char separator = ',';
    public string[] WorkingMemory { get; private set; }

    public FactsHandler()
    {
        WorkingMemory = new string[100];
    }

    public int FactsCount { get; private set; } = 0;

    public static string GetFact(ref string s)
    {
        var fact = "";
        var index = s.IndexOf(separator);

        if (index < 0)
        {
            fact = s;
            s = "";
        }
        else
        {
            fact = s.Substring(index);
            s = s.Remove(0, index + 1);
        }

        return fact;
    }

    public bool IsFact(string s)
    {
        s = s.Trim();
        var result = false;

        for (int i = 0; i < FactsCount; i++)
        {
            if (WorkingMemory[i] == s)
            {
                result = true;
            }
        }

        return result;
    }

    public bool IsTrue(string s)
    {
        var result = false;
        var isFirst = true;

        while (!string.IsNullOrEmpty(s))
        {
            var tempResult = IsFact(GetFact(ref s));

            if (isFirst)
            {
                result = tempResult;
                isFirst = false;
            }
            else
            {
                result = tempResult && result;
            }
        }

        return result;
    }

    public void AddFact(string s)
    {
        s = s.Trim();

        if (!IsFact(s))
        {
            WorkingMemory[FactsCount] = s;
            FactsCount++;
        }
    }

    public void AddFacts()
    {
        bool moveNext = true;

        do
        {
            Console.WriteLine("Enter a fact");
            var fact = Console.ReadLine();

            if (!string.IsNullOrEmpty(fact))
            {
                AddFact(fact);
            }
            else
            {
                moveNext = false;
            }

        } while (moveNext);

        Console.WriteLine(Environment.NewLine);
    }

    public void ShowFacts()
    {
        Console.WriteLine("Working memory current status");

        if (FactsCount == 0)
        {
            Console.WriteLine("Working memory is empty");
        }
        else
        {
            for (int i = 0; i < FactsCount; i++)
            {
                Console.WriteLine($"{i + 1}. {WorkingMemory[i]}");
            }
        }

        Console.WriteLine(Environment.NewLine);
    }

    public void ResetFacts()
    {
        FactsCount = 0;
        WorkingMemory = new string[100];
    }
}
