using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Triangle
{
    public class Coordinate
    {
        public int X { get;}
        public int Y { get; }

        public int Value { get; }

        public Coordinate(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}   
