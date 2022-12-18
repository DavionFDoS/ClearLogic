using ClearLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Handlers;

public class RulesHandler
{
    public int RulesCount { get; private set; }

    public List<Rule> Rules;
    private readonly FactsHandler _factsHandler;

    public RulesHandler(FactsHandler factsHandler)
    {
        Rules = new List<Rule>();
        _factsHandler = factsHandler;
    }

    public void AddRules()
    {
        var moveNext = true;

        do
        {
            var rule = new Rule();

            Console.WriteLine("ЕСЛИ ");
            var conditionalPart = Console.ReadLine();

            if (!string.IsNullOrEmpty(conditionalPart))
            {
                rule.ConditionalPart = conditionalPart;
                Console.WriteLine("ТО ");
                var executablePart = Console.ReadLine();

                if (!string.IsNullOrEmpty(executablePart))
                {
                    rule.ExecutablePart = executablePart;
                    rule.IsInUse = true;

                    Rules.Add(rule);
                    RulesCount++;
                }
            }
            else
            {
                moveNext = false;
            }
        } while (moveNext);
    }

    public void ShowRules()
    {
        char use;

        Console.WriteLine("Rules: ");

        if (RulesCount == 0)
        {
            Console.WriteLine("There is no rules" + Environment.NewLine);
        }
        else
        {
            for (int i = 0; i < RulesCount; i++)
            {
                if (Rules[i].IsInUse)
                {
                    use = '+';
                }
                else
                {
                    use = '-';
                }

                Console.WriteLine($"{i + 1}. {use} ЕСЛИ {Rules[i].ConditionalPart}," +
                    $" ТО {Rules[i].ExecutablePart}");
            }
        }

        Console.WriteLine(Environment.NewLine);
    }

    public bool TestRule(int index)
    {
        var result = false;

        if (Rules[index].IsInUse && _factsHandler.IsFact(Rules[index].ConditionalPart!))
        {
            _factsHandler.AddFact(Rules[index].ExecutablePart!);
            Rules[index].IsInUse = false;
            result = true;
        }

        return result;
    }

    public void ResetRules()
    {
        RulesCount = 0;
        Rules = new List<Rule>();
    }
}