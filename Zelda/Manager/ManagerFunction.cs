using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zelda.Manager
{
    public static class ManagerFunction
    {
        private static readonly Random _rnd = new Random();

        public static int Random(int min, int max)
        {
            return _rnd.Next(min, max+1);
        }
    }
}
