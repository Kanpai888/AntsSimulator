namespace AntsSimulator
{
    public class Nest
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
