using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public struct Vector2(int x, int y)
    {
        public int x = x;
        public int y = y;

        public override readonly bool Equals(object? obj)
        {
            return obj is Vector2 vector &&
                   x == vector.x &&
                   y == vector.y;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return left.x == right.x && left.y == right.y;
        }
    }
}
