using System;
using System.Collections.Generic;
using System.Drawing;

namespace AntsSimulator
{
    public class WorldManager
    {
        private IList<Ant> _ants;
        private WorldBounds _worldBounds;
        private MovementGenerator _moveGenerator;
        private Random _random;

        public WorldManager(WorldBounds worldBounds, MovementGenerator moveGenerator)
        {
            _worldBounds = worldBounds;
            _moveGenerator = moveGenerator;
            _random = new Random();
        }

        /// <summary>
        /// Generate a world with the specified number of ants
        /// </summary>
        /// <param name="numAnts"></param>
        public void GenerateWorld(int numAnts)
        {
            _ants = new List<Ant>();
            for(int i = 0; i < numAnts; i++)
            {
                Ant ant = CreateAnt();
                _ants.Add(ant);
            }
        }

        /// <summary>
        /// Update all the ants by one time step
        /// </summary>
        public void UpdateWorld()
        {
            foreach(Ant ant in _ants)
            {
                ant.UpdateMovement();
            }
        }

        /// <summary>
        /// Draw the world representation onto the graphics object
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawWorld(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.CornflowerBlue, 2))
            {
                foreach (Ant ant in _ants)
                {
                    graphics.DrawRectangle(pen, ant.XPos, ant.YPos, 2, 2);
                }
            }
        }

        /// <summary>
        /// Create an <see cref="Ant"/> that is within the confines of the world boundries
        /// </summary>
        /// <returns></returns>
        private Ant CreateAnt()
        {
            int xPos = _random.Next(0, _worldBounds.XBound + 1);
            int yPos = _random.Next(0, _worldBounds.YBound + 1);
            Ant ant = new Ant(xPos, yPos, _worldBounds, _moveGenerator);
            return ant;
        }
    }
}
