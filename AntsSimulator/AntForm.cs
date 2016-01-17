using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntsSimulator
{
    public partial class AntForm : Form
    {
        private WorldManager _worldManager;
        private const int _numOfAnts = 100;

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

        private void SetupDrawLoop()
        {
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            drawingArea.Invalidate();
        }

        private void DrawingAreaPaint(object sender, PaintEventArgs e)
        {
            _worldManager.UpdateWorld();
            _worldManager.DrawWorld(e.Graphics);
        }
    }
}
