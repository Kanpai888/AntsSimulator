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

        private readonly int _numXGridBlocks = 10;
        private readonly int _numYGridBlocks = 10;

        private IList<Ant> _ants;
        private IList<FoodSource> _foodSources;
        private IList<Nest> _nests;

        private WorldGrid _worldGrid;
        
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

            _worldGrid = new WorldGrid(_numXGridBlocks, _numYGridBlocks, worldBounds);
        }

        /// <summary>
        /// Generate a world with the specified number of ants
        /// </summary>
        /// <param name="numAnts"></param>
        public void GenerateWorld(int numAnts)
        {
            // Generate the ants
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
            _worldGrid.ClearBuckets();
            foreach (Ant ant in _ants)
            {
                ant.UpdateMovement();
                _worldGrid.AddItem(ant);
            }
            
            // TODO Evaluate each individual buckets in the world grid to check 
            // if there are any possible collisions.
        }

        /// <summary>
        /// Draw the world representation onto the graphics object
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawWorld(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.IndianRed, 1))
            {
                int xFoodOffset = _foodSourceSize / 2;
                int yFoodOffset = _foodSourceSize / 2;
                foreach (FoodSource foodSource in _foodSources)
                {
                    graphics.DrawRectangle(pen, foodSource.XPos - xFoodOffset, foodSource.YPos - yFoodOffset, _foodSourceSize, _foodSourceSize);
                }
            }
            using (Pen pen = new Pen(Color.ForestGreen, 1))
            {
                // Rectangle are drawn from the edge, so we need to offset the values to make them appear even
                int xNestOffset = _nestSize / 2;
                int yNestOffset = _nestSize / 2;
                foreach (Nest nest in _nests)
                {
                    graphics.DrawRectangle(pen, nest.XPos - xNestOffset, nest.YPos - yNestOffset, _nestSize, _nestSize);
                }
            }
            using (Pen pen = new Pen(Color.CornflowerBlue, 1))
            {
                int xAntOffset = _antWidth / 2;
                int yAntOffset = _antWidth / 2;
                foreach (Ant ant in _ants)
                {
                    graphics.DrawRectangle(pen, ant.XPos - xAntOffset, ant.YPos - yAntOffset, _antWidth, _antWidth);
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
