﻿using Microsoft.Xna.Framework;
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
            return _rnd.Next(min, max + 1);
        }

        public static double Distance(Vector2 positionOne, Vector2 positionTwo)
        {
            var x = Math.Pow(positionOne.X - positionTwo.X, 2);
            var y = Math.Pow(positionOne.Y - positionTwo.Y, 2);
            return Math.Sqrt(x + y);
        }
    }
}

    
