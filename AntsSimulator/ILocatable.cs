namespace AntsSimulator
{
    /// <summary>
    /// Represents a object that can be placed in the world map
    /// </summary>
    public interface ILocatable
    {
        int XPos { get; }
        int YPos { get; }
    }
}