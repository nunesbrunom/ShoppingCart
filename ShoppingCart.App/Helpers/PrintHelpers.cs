﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Helpers
{
    public static class PrintHelpers
    {
        public static bool IsConsoleOutput = false;

        public static void WriteLine(string text)
        {
            if (IsConsoleOutput)
                System.Console.WriteLine(text);
            else
                Trace.WriteLine(text);
        }

        /// <summary>
        /// Formats the reference to XXX-XXX format
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public static string PrintReference(int reference)
        {
            return string.Format("{0:000-000}", reference);
        }
    }
}
