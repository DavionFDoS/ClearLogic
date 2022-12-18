using ClearLogic.Handlers;

var factsHandler = new FactsHandler();
var goalsHandlers = new GoalsHandler(factsHandler);
var rulesHandler = new RulesHandler(factsHandler);
var logicOutputHandler = new LogicOutputHandler(goalsHandlers, rulesHandler);
var menuHandler = new MenuHandler();
string menuPoint;

Console.WriteLine("Solving logical tasks ");

do
{
    menuPoint = menuHandler.ShowMenu();

    switch (menuPoint)
    {
        case "1":
            factsHandler.AddFacts();
            break;
        case "2":
            factsHandler.ShowFacts();
            break;
        case "3":
            factsHandler.ResetFacts();
            break;
        case "4":
            rulesHandler.AddRules();
            break;
        case "5":
            rulesHandler.ShowRules();
            break;
        case "6":
            rulesHandler.ResetRules();
            break;
        case "7":
            logicOutputHandler.Find();
            break;
        case "8":
            logicOutputHandler.BackFind();
            break;
        default:
            Console.WriteLine("Incorrect input");
            menuPoint = menuHandler.ShowMenu();
            break;
    };

} while (menuPoint != "9");