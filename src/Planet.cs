using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Planets {

    public interface IDrawable {
        void Draw (Graphics graphics);
    }

    public interface ISpaceBody {
        double Mass { get; set; }
        double Radius { get; set; }
        Vector Position { get; set; }
        Vector InitialVelocity { get; set; }
    }

    public class Planet : IDrawable, ISpaceBody {

        private Brush m_brush;
        private Pen m_pen;
        private Vector m_currentVelocity;
        private List<Vector> m_previousPositions = new List<Vector> ();

        public Color Color { get; set; } = Color.Black;
        public double Mass { get; set; } = 0;
        public double Radius { get; set; } = 0;
        public Vector Position { get; set; } = new Vector ();
        public Vector InitialVelocity { get; set; } = new Vector ();

        public void Init () {
            m_brush = new SolidBrush (Color);
            m_pen = new Pen (Color.White);

            m_previousPositions.Add (new Vector (Position));
            m_currentVelocity = InitialVelocity;
        }

        public void DrawTrail (Graphics graphics) {
            var drawablePreviousPositions = m_previousPositions.Select (x => x.ToDrawable (Game.SCREEN_HEIGHT));
            var drawablePosition = Position.ToDrawable (Game.SCREEN_HEIGHT);

            var path = new GraphicsPath ();
            path.AddLines (drawablePreviousPositions.Select (x => new PointF ((float)x.x, (float)x.y)).ToArray ());
            graphics.DrawPath (m_pen, path);

            m_previousPositions.Add (new Vector (Position));
        }

        public void Draw (Graphics graphics) {
            var drawablePosition = Position.ToDrawable (Game.SCREEN_HEIGHT);

            graphics.FillEllipse (
                m_brush,
                (float)(drawablePosition.x - Radius),
                (float)(drawablePosition.y - Radius),
                (float)(Radius * 2),
                (float)(Radius * 2)
            );
        }

        public void UpdateVelocity (TimeSpan gameTime, List<Planet> spaceBodies) {
            spaceBodies.Where (x => x != this).ToList ()
                .ForEach (otherBody => {
                    var direction = Position.Direction (otherBody.Position);
                    var force = Physics.GravitationForce (Mass, otherBody.Mass, Position.Distance (otherBody.Position));
                    var directedForce = direction * force;
                    var acceleration = directedForce / Mass;

                    m_currentVelocity += acceleration * gameTime.TotalSeconds;
                });
        }

        public void UpdatePosition (TimeSpan gameTime) {
            Position.x += m_currentVelocity.x * gameTime.TotalSeconds;
            Position.y += m_currentVelocity.y * gameTime.TotalSeconds;
        }

    }
}
