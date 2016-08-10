using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Helpers
{
    public static class OutputHelper
    {
        public static bool IsConsoleOutput = false;

        public static void WriteLine(string text)
        {
            if (IsConsoleOutput)
                System.Console.WriteLine(text);
            else
                Trace.WriteLine(text);
        }
    }
}
