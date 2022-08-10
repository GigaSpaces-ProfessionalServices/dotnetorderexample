using System;
using System.Collections.Generic;
using System.Text;

namespace GigaSpaces.Examples.StockSba.Commons
{
    /// <summary>
    /// A central handler for reporting/logging tasks
    /// </summary>
    public class Reporter
    {
        /// <summary>
        /// Send a message to current report mechanism.
        /// </summary>
        /// <param name="message">string message</param>
        public static void Report(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// print empty line to current report mechanism.
        /// </summary>
        public static void Report()
        {
            Console.WriteLine();
        }
        /// <summary>
        /// Send a message to current report mechanism.
        /// </summary>
        /// <param name="obj">object to report</param>
        public static void Report(object obj)
        {
            Report(obj.ToString());
        }
    }
}
