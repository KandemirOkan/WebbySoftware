using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebbySoftware
{
    public class ValidationUtilities
    {
        public static bool IsIntegerValid(int value)
        {
            return int.TryParse(value.ToString(), out _);
        }
    }
}