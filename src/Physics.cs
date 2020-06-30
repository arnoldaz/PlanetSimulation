using System;

namespace Planets {
    public static class Physics {

        public const double GRAVITATIONAL_CONSTANT = 6.674080e-11;

        public static double GravitationForce (double m1, double m2, double dist) {
            return GRAVITATIONAL_CONSTANT * m1 * m2 / Math.Pow (dist, 2);
        }

    }
}
