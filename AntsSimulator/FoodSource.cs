namespace AntsSimulator
{
    public class FoodSource
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
