using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Utils {
    public class Logger {

        public static LogLevel logLevel = LogLevel.DEBUG;

        public static void info(String text) {
            Console.WriteLine($"[INFO] {text}");
        }

        public static void debug(String text) {
            if(logLevel.Equals(LogLevel.DEBUG))
                Console.WriteLine($"[DEBUG] {text}");
        }

        public static void error(String text) {
            Console.WriteLine($"[ERROR] {text}");
        }

        public enum LogLevel{
            INFO,
            DEBUG,
        }
    }
}
