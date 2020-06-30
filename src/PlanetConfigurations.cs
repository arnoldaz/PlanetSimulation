using System;
using System.Collections.Generic;
using System.Drawing;

namespace Planets.src {
    public static class PlanetConfigurations {

        public static List<Planet> GetPlanetConfiguration (int id) {
            switch (id) {

                // Two same mass planets that spin around each other.
                case 1:
                    return new List<Planet> {
                        new Planet {
                            Mass = 1e17,
                            Radius = 20,
                            Position = new Vector (500, 300),
                            InitialVelocity = new Vector (0, 130),
                            Color = Color.Yellow
                        },
                        new Planet {
                            Mass = 1e17,
                            Radius = 20,
                            Position = new Vector (700, 300),
                            InitialVelocity = new Vector (0, -130),
                            Color = Color.Blue
                        },
                    };

                // Two heavier planets spin around each other and third lighter spins around them.
                case 2:
                    return new List<Planet> {
                        new Planet {
                            Mass = 1e17,
                            Radius = 20,
                            Position = new Vector (500, 300),
                            InitialVelocity = new Vector (0, 130),
                            Color = Color.Yellow
                        },
                        new Planet {
                            Mass = 1e17,
                            Radius = 20,
                            Position = new Vector (700, 300),
                            InitialVelocity = new Vector (0, -130),
                            Color = Color.Blue
                        },
                        new Planet {
                            Mass = 1e15,
                            Radius = 15,
                            Position = new Vector (1000, 300),
                            InitialVelocity = new Vector (0, 150),
                            Color = Color.Orange
                        },
                    };
                default:
                    throw new ArgumentOutOfRangeException ($"Given id: {id} is out of range.");
            }
        }

    }
}
