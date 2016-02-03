namespace AntsSimulator
{
    /// <summary>
    /// Represents an ant's nest
    /// </summary>
    public class Nest : ILocatable
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }

        public Nest(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
