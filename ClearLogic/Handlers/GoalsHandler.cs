using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Handlers;

public class GoalsHandler
{
    public int GoalsCount { get; private set; } = 0;

    public string[] Goals { get; private set; }

    private readonly FactsHandler _factsHandler;

    public GoalsHandler(FactsHandler factsHandler)
    {
        Goals = new string[100];
        _factsHandler = factsHandler;
    }

    public bool IsGoal(string goal)
    {
        goal = goal.Trim();
        var result = false;

        for (int i = 0; i < GoalsCount; i++)
        {
            if (Goals[i] == goal)
            {
                result = true;
            }
        }
        return result;
    }

    public void AddGoal(string goal)
    {
        goal = goal.Trim();

        if ((goal != "") && (!IsGoal(goal)))
        {
            Goals[GoalsCount] = goal;
            GoalsCount++;
        }
    }

    public void InputGoal()
    {
        Console.WriteLine("Goal: ");

        var goal = Console.ReadLine();

        if (!string.IsNullOrEmpty(goal))
        {
            AddGoal(goal);
        }
    }

    public void AddGoals(string goal) // Добавление новых целей
    {
        while (goal != "")
        {
            AddGoal(FactsHandler.GetFact(ref goal));
        }
    }

    public void ConfirmGoal() // Подтверждение цели
    {
        if (GoalsCount > 0 && Goals[0] != "")
        {
            if (_factsHandler.IsTrue(Goals[0]))
            {
                Console.WriteLine("Rule is approved");
            }
            else
            {
                Console.WriteLine("Rule is not approved");
            }              
        }
    }
}
