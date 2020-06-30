using System;
using System.Drawing;
using System.Collections.Generic;
using Planets.src;

namespace Planets {
    public class Game : IDrawable {

        public const int SCREEN_WIDTH = 1350;
        public const int SCREEN_HEIGHT = 729;

        public List<Planet> planets = new List<Planet> ();

        public Game () {
            planets = PlanetConfigurations.GetPlanetConfiguration (2);

            // To create brush and set current velocity to initial.
            planets.ForEach (x => x.Init ());
        }

        public void Update (TimeSpan gameTime) {
            planets.ForEach (x => x.UpdateVelocity (gameTime, planets));
            planets.ForEach (x => x.UpdatePosition (gameTime));
        }

        public void Draw (Graphics graphics) {
            planets.ForEach (x => x.DrawTrail (graphics));
            planets.ForEach (x => x.Draw (graphics));
        }
    }
}
