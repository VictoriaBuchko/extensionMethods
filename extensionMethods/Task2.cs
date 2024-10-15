using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensionMethods
{
    internal static class Task2
    {
        public static int[] Filter(this int[] arr, Predicate<int> predicate)
        {
            return Array.FindAll(arr, predicate);
        }
    }
}
