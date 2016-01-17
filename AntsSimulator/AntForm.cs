using System;
using System.Windows.Forms;

namespace AntsSimulator
{
    public partial class AntForm : Form
    {
        private WorldManager _worldManager;
        private const int _numOfAnts = 100;
        private const int _updateIntervalMills = 50;

        public AntForm()
        {
            InitializeComponent();

            // Assume 1 to 1 pixel mapping for now
            WorldBounds bounds = new WorldBounds(drawingArea.Size.Width, drawingArea.Size.Height);
            MovementGenerator moveGenerator = new MovementGenerator(new Random());
            _worldManager = new WorldManager(bounds, moveGenerator);
            _worldManager.GenerateWorld(_numOfAnts);

            SetupDrawLoop();
        }

        /// <summary>
        /// Setups the timer that triggers the update loop
        /// </summary>
        private void SetupDrawLoop()
        {
            Timer timer = new Timer();
            timer.Interval = _updateIntervalMills;
            timer.Tick += TimerTick;
            timer.Start();
        }

        /// <summary>
        /// Invalidate the panel to cause a redraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            drawingArea.Invalidate();
        }

        /// <summary>
        /// Update the world and draw it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingAreaPaint(object sender, PaintEventArgs e)
        {
            _worldManager.UpdateWorld();
            _worldManager.DrawWorld(e.Graphics);
        }
    }
}
