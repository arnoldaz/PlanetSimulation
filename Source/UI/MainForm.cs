using System;
using System.Windows.Forms;

namespace Planets {
    public partial class MainForm : Form {

        private readonly GameLoop m_gameLoop = new GameLoop ();
        private readonly Timer m_graphicsTimer = new Timer { Interval = 1000 / GameLoop.FPS };

        public MainForm () {
            InitializeComponent ();
            StartGameLoop ();
        }

        private void StartGameLoop () {
            m_gameLoop.Start ();

            m_graphicsTimer.Tick += GraphicsTimer_Tick;
            m_graphicsTimer.Start ();
        }

        private void PictureBox_Paint (object sender, PaintEventArgs e) {
            m_gameLoop.Draw (e.Graphics);
        }

        private void GraphicsTimer_Tick (object sender, EventArgs e) {
            PictureBox.Invalidate (); 
        }
    }
}
