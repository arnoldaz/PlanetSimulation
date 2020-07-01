using System;
using System.Collections.Generic;
using System.Drawing;

namespace Planets {
    public static class PlanetConfigurations {

        /// <summary>
        /// Gets premade planet configuration.
        /// </summary>
        /// <param name="id">Configuration Id.</param>
        /// <returns>List of planets.</returns>
        public static List<Planet> GetPlanetConfiguration (int id) {
            switch (id) {

                // Two same mass planets that spin around each other.
                case 0:
                    return new List<Planet> {
                        new Planet (
                            mass: 1e17,
                            radius: 20,
                            position: new Vector (500, 300),
                            initialVelocity: new Vector (0, 130),
                            color: Color.Yellow
                        ),
                        new Planet (
                            mass: 1e17,
                            radius: 20,
                            position: new Vector (700, 300),
                            initialVelocity: new Vector (0, -130),
                            color: Color.Blue
                        ),
                    };

                // Two heavier planets spin around each other and third lighter spins around them.
                case 1:
                    return new List<Planet> {
                        new Planet (
                            mass: 1e17,
                            radius: 20,
                            position: new Vector (500, 300),
                            initialVelocity: new Vector (0, 130),
                            color: Color.Yellow
                        ),
                        new Planet (
                            mass: 1e17,
                            radius: 20,
                            position: new Vector (700, 300),
                            initialVelocity: new Vector (0, -130),
                            color: Color.Blue
                        ),
                        new Planet (
                            mass: 1e15,
                            radius: 15,
                            position: new Vector (1000, 300),
                            initialVelocity: new Vector (0, 150),
                            color: Color.Orange
                        ),
                    };

                default:
                    throw new ArgumentOutOfRangeException ($"Given id: {id} is out of range.");
            }
        }
    }
}
