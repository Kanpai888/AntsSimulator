namespace AntsSimulator
{
    /// <summary>
    /// Represents the boundries of the world. Note that this is not necissarily a one to one
    /// mapping with the pixels on screen.
    /// </summary>
    public class WorldBounds
    {
        public int XBound { get; private set; }
        public int YBound { get; private set; }

        public WorldBounds(int xBound, int yBound)
        {
            XBound = xBound;
            YBound = yBound;
        }
    }
}
