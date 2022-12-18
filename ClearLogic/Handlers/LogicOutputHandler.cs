using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Handlers;

public class LogicOutputHandler
{
    private readonly GoalsHandler _goalsHandler;
    private readonly RulesHandler _rulesHandler;

    public LogicOutputHandler(GoalsHandler goalsHandler, RulesHandler rulesHandler)
    {
        _goalsHandler = goalsHandler;
        _rulesHandler = rulesHandler;
    }

    public void Find()
    {
        bool moveNext;

        _goalsHandler.InputGoal();

        do
        {
            moveNext = false;

            for (int i = 0; i < _rulesHandler.RulesCount; i++)
            {
                if (_rulesHandler.TestRule(i))
                {
                    moveNext = true;
                }
            }

        } while (moveNext);

        _goalsHandler.ConfirmGoal();
    }

    public void BackFind()
    {
        bool moveNext;
        _goalsHandler.InputGoal();
        do
        {
            moveNext = false;

            for (int i = 0; i < _goalsHandler.GoalsCount; i++)
            {
                for (int j = 0; j < _rulesHandler.RulesCount; j++)
                    if (_rulesHandler.Rules[j].IsInUse &&
                        _rulesHandler.Rules[j].ExecutablePart == _goalsHandler.Goals[i])
                    {

                        _goalsHandler.AddGoals(_rulesHandler.Rules[j].ConditionalPart!);

                        if (_rulesHandler.TestRule(j))
                        {
                            moveNext = true;
                        }
                    }
            }
        } while (moveNext);
        _goalsHandler.ConfirmGoal();
    }
}
