using System;
using System.Drawing;
using System.Collections.Generic;

namespace Planets {
    public class Game : IDrawable {

        public const double GRAVITATIONAL_CONSTANT = 6.674080e-11;

        private readonly List<Planet> m_planets;

        public Game () {
            m_planets = PlanetConfigurations.GetPlanetConfiguration (1);
        }

        public void Update (TimeSpan gameTime) {
            m_planets.ForEach (x => x.UpdateVelocity (gameTime, m_planets));
            m_planets.ForEach (x => x.UpdatePosition (gameTime));
        }

        public void Draw (Graphics graphics) {
            m_planets.ForEach (x => x.DrawTrail (graphics));
            m_planets.ForEach (x => x.Draw (graphics));
        }
    }
}
