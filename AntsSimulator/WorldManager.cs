using System;
using System.Collections.Generic;
using System.Drawing;

namespace AntsSimulator
{
    public class WorldManager
    {
        private const int _antWidth = 2;
        private const int _nestSize = 20;
        private const int _foodSourceSize = 20;

        private IList<Ant> _ants;
        private IList<FoodSource> _foodSources;
        private IList<Nest> _nests;

        private WorldBounds _worldBounds;
        private MovementGenerator _moveGenerator;
        private Random _random;

        public WorldManager(WorldBounds worldBounds, MovementGenerator moveGenerator)
        {
            _worldBounds = worldBounds; 
            _moveGenerator = moveGenerator;

            _random = new Random();
            _ants = new List<Ant>();
            _foodSources = new List<FoodSource>();
            _nests = new List<Nest>();
        }

        /// <summary>
        /// Generate a world with the specified number of ants
        /// </summary>
        /// <param name="numAnts"></param>
        public void GenerateWorld(int numAnts)
        {
            _ants.Clear();

            for(int i = 0; i < numAnts; i++)
            {
                Ant ant = CreateAnt();
                _ants.Add(ant);
            }
        }

        public void AddFoodSource(FoodSource source)
        {
            _foodSources.Add(source);
        }

        public void AddNest(Nest nest)
        {
            _nests.Add(nest);
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
            using (Pen pen = new Pen(Color.IndianRed, 1))
            {
                foreach (FoodSource foodSource in _foodSources)
                {
                    graphics.DrawRectangle(pen, foodSource.XPos, foodSource.YPos, _foodSourceSize, _foodSourceSize);
                }
            }
            using (Pen pen = new Pen(Color.ForestGreen, 1))
            {
                foreach (Nest nest in _nests)
                {
                    graphics.DrawRectangle(pen, nest.XPos, nest.YPos, _nestSize, _nestSize);
                }
            }
            using (Pen pen = new Pen(Color.CornflowerBlue, 1))
            {
                foreach (Ant ant in _ants)
                {
                    graphics.DrawRectangle(pen, ant.XPos, ant.YPos, _antWidth, _antWidth);
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
