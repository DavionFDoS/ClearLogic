using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Models;

public class Rule
{
    public string? ConditionalPart { get; set; }

    public string? ExecutablePart { get; set; }

    public bool IsInUse { get; set; } = true;
}
