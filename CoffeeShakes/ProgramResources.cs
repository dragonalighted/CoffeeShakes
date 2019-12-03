using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoffeeShakes
{
    internal class ProgramResources
    {
        public Icon CoffeeCup => Properties.Resources.ResourceManager.GetObject("CoffeeCup") as Icon;
    }
}
