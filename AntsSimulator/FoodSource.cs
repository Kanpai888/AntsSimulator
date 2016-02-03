namespace AntsSimulator
{
    /// <summary>
    /// Represents a food source
    /// </summary>
    public class FoodSource : ILocatable
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }

        public FoodSource(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
