using System;

namespace Planets {
    public class Vector {

        public double x = 0;
        public double y = 0;

        public Vector () { }

        public Vector (double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Vector (Vector other) {
            x = other.x;
            y = other.y;
        }

        public static Vector operator - (Vector a, Vector b) => new Vector (a.x - b.x, a.y - b.y);
        public static Vector operator + (Vector a, Vector b) => new Vector (a.x + b.x, a.y + b.y);
        public static Vector operator * (Vector a, double b) => new Vector (a.x * b, a.y * b);
        public static Vector operator / (Vector a, double b) => new Vector (a.x / b, a.y / b);


        public double Distance (Vector other) {
            return Math.Sqrt (Math.Pow (other.x - x, 2) + Math.Pow (other.y - y, 2));
        }

        public Vector Direction (Vector other) {
            return (other - this) / Distance (other);
        }

        /// <summary>
        /// Changes position to grid where starting location is top left instead of bottom left for drawing.
        /// </summary>
        /// <returns>Converted position.</returns>
        public Vector ToDrawable (int screenHeight) {
            return new Vector (x, screenHeight - y);
        }

    }
}
