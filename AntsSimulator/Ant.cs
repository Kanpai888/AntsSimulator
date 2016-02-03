
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

        public Ant(int startX, int startY, WorldBounds worldBounds, MovementGenerator moveGenerator)
        {
            XPos = startX;
            YPos = startY;
            _boundry = worldBounds;
            _moveGenerator = moveGenerator;
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
