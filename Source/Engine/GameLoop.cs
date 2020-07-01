using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Planets {

    public interface IDrawable {
        void Draw (Graphics graphics);
    }

    public class GameLoop : IDrawable {

        private readonly Game m_game = new Game ();
        private bool m_running = false;

        public const int SCREEN_WIDTH = 1350;
        public const int SCREEN_HEIGHT = 729;
        public const int FPS = 144;

        public async void Start () {
            m_running = true;

            var previousGameTime = DateTime.Now;

            while (m_running) {
                var gameTime = DateTime.Now - previousGameTime;
                previousGameTime += gameTime;
                m_game.Update (gameTime);
                await Task.Delay (1000 / FPS);
            }
        }

        public void Stop () {
            m_running = false;
        }

        public void Draw (Graphics graphics) {
            m_game.Draw (graphics);
        }
    }
}
