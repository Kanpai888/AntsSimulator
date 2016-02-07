
using System;
using System.Collections.Generic;

namespace AntsSimulator
{
    /// <summary>
    /// Represents an ant
    /// </summary>
    public class Ant : ILocatable
    {
        private MovementGenerator _moveGenerator;
        private WorldBounds _boundry;

        public int XPos { get; private set; }
        public int YPos { get; private set; }

        /// <summary>
        /// The closest known food source to this ant. If no food sources are known, then this returns null
        /// </summary>
        public FoodSource KnownFoodSource { get; private set; }
        /// <summary>
        /// The closest known nest to this ant. If no food sources are known, then this returns null
        /// </summary>
        public Nest KnownNest { get; private set; }

        public Ant(int startX, int startY, WorldBounds worldBounds, MovementGenerator moveGenerator)
        {
            XPos = startX;
            YPos = startY;
            _boundry = worldBounds;
            _moveGenerator = moveGenerator;
        }

        public void EvaluateSurroundings(IEnumerable<ILocatable> items)
        {
            foreach(ILocatable seenItem in items)
            {
                if (seenItem is FoodSource)
                {
                    
                }
                else if (seenItem is Nest)
                {

                }
                else if (seenItem is Ant)
                {

                }

            }
        }

        private bool IsCloser(ILocatable current, ILocatable target)
        {
            return true;
        }

        /// <summary>
        /// Returns the distance between this ant and the <see cref="ILocatable"/> item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private float GetDistance(ILocatable target)
        {
            // Use pythagora
            float xOffset = (float)XPos - (float)target.XPos;
            float yOffset = (float)YPos - (float)target.YPos;

            float xOffsetSquared = xOffset * xOffset;
            float yOffsetSquared = yOffset * yOffset;

            float distance = (float)Math.Sqrt(xOffset + yOffset);

            return distance;
        }

        /// <summary>
        /// Move the ant in any direction by 1 step
        /// </summary>
        public void UpdateMovement()
        {
            int nextXPos, nextYPos;

            do
            {
                nextXPos = XPos;
                nextYPos = YPos;

                Movement nextMove = _moveGenerator.NextMove();

                switch (nextMove)
                {
                    case Movement.NorthWest:
                        nextXPos--;
                        nextYPos--;
                        break;
                    case Movement.North:
                        nextYPos--;
                        break;
                    case Movement.NorthEast:
                        nextXPos++;
                        nextYPos--;
                        break;
                    case Movement.West:
                        nextXPos--;
                        break;
                    case Movement.East:
                        nextXPos++;
                        break;
                    case Movement.SouthWest:
                        nextXPos--;
                        nextYPos++;
                        break;
                    case Movement.South:
                        nextYPos++;
                        break;
                    case Movement.SouthEast:
                        nextXPos++;
                        nextYPos++;
                        break;
                    default:
                        break;
                }
            }
            while (nextXPos < 0 || nextXPos > _boundry.XBound || nextYPos < 0 || nextYPos > _boundry.YBound);

            XPos = nextXPos;
            YPos = nextYPos;
        }
    }
}
