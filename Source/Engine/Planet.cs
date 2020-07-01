using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Planets {

    public class Planet : IDrawable {

        private readonly double m_mass;
        private readonly double m_radius;

        private readonly List<Vector> m_previousPositions = new List<Vector> ();
        private Vector m_currentPosition;
        private Vector m_currentVelocity;

        private readonly Brush m_planetBrush;
        private readonly Pen m_trailPen = new Pen (Color.White);

        /// <summary>
        /// Planet constructor.
        /// </summary>
        /// <param name="mass">Planet mass in kg.</param>
        /// <param name="radius">Planet radius in pixels.</param>
        /// <param name="position">Coordinates of planet center.</param>
        /// <param name="initialVelocity">Force and direction of initial velocity.</param>
        /// <param name="color">Planet color.</param>
        public Planet (double mass, double radius, Vector position, Vector initialVelocity, Color color) {
            m_mass = mass;
            m_radius = radius;
            m_currentPosition = position;
            m_currentVelocity = initialVelocity;
            m_planetBrush = new SolidBrush (color);
            m_previousPositions.Add (position);
        }

        /// <summary>
        /// Draws trail from all of previous planet positions.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        public void DrawTrail (Graphics graphics) {
            var drawablePreviousPositions = m_previousPositions.Select (x => x.ToDrawable (GameLoop.SCREEN_HEIGHT));
            var drawablePosition = m_currentPosition.ToDrawable (GameLoop.SCREEN_HEIGHT);

            var path = new GraphicsPath ();
            path.AddLines (drawablePreviousPositions.Select (pos => new PointF ((float)pos.x, (float)pos.y)).ToArray ());
            graphics.DrawPath (m_trailPen, path);

            m_previousPositions.Add (new Vector (m_currentPosition));
        }

        /// <summary>
        /// Draws planet at current position.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        public void Draw (Graphics graphics) {
            var drawablePosition = m_currentPosition.ToDrawable (GameLoop.SCREEN_HEIGHT);

            graphics.FillEllipse (
                m_planetBrush,
                (float)(drawablePosition.x - m_radius),
                (float)(drawablePosition.y - m_radius),
                (float)(m_radius * 2),
                (float)(m_radius * 2)
            );
        }

        /// <summary>
        /// Update planet velocity using all other planets.
        /// </summary>
        /// <param name="gameTime">Passed time from previous frame.</param>
        /// <param name="planets">All planets.</param>
        public void UpdateVelocity (TimeSpan gameTime, List<Planet> planets) {
            planets.Where (x => x != this).ToList ()
                .ForEach (otherPlanet => {
                    var direction = m_currentPosition.Direction (otherPlanet.m_currentPosition);
                    var force = Game.GRAVITATIONAL_CONSTANT * m_mass * otherPlanet.m_mass / Math.Pow (m_currentPosition.Distance (otherPlanet.m_currentPosition), 2);
                    var directedForce = direction * force;
                    var acceleration = directedForce / m_mass;

                    m_currentVelocity += acceleration * gameTime.TotalSeconds;
                });
        }

        /// <summary>
        /// Update planet position using current velocity.
        /// </summary>
        /// <param name="gameTime">Passed time from previous frame.</param>
        public void UpdatePosition (TimeSpan gameTime) {
            m_currentPosition += m_currentVelocity * gameTime.TotalSeconds;
        }
    }
}
