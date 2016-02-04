namespace AntsSimulator
{
    /// <summary>
    /// Representation of the world in a grid that contains <see cref="GridBucket"/> elements. Each grid element contains
    /// a reference to a <see cref="ILocatable"/> that are within its bounds. This allows us to
    /// heavily optimiste for object collisions to try avoid needing to do a N^2 search.
    /// </summary>
    public class WorldGrid
    {
        private readonly int _numXBlocks;
        private readonly int _numYBlocks;
        private readonly float _xBlockWidth;
        private readonly float _yBlockHeight;
        private GridBucket[,] _buckets;

        // TODO Make WorldGrid implement IEnumberable<T> instead of expose through property?
        public GridBucket[,] WorldBuckets { get { return _buckets; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xBlocks">Number of x blocks to represent the world</param>
        /// <param name="yBlocks">Number of y blocks to represent the world</param>
        /// <param name="bounds">World boundries</param>
        public WorldGrid(int xBlocks, int yBlocks, WorldBounds bounds)
        {
            _numXBlocks = xBlocks;
            _numYBlocks = yBlocks;
            _xBlockWidth = (float)bounds.XBound / (float)xBlocks;
            _yBlockHeight = (float)bounds.YBound / (float)yBlocks;

            _buckets = new GridBucket[_numXBlocks, _numYBlocks];

            // Initiliase the buckets
            for (int x = 0; x < _numXBlocks; x++)
            {
                for (int y = 0; y < _numYBlocks; y++)
                {
                    GridBucket bucket = new GridBucket();
                    _buckets[x, y] = bucket;
                }
            }
        }

        /// <summary>
        /// Adds the specified <see cref="ILocatable"/> to the <see cref="GridBucket"/> that covers
        /// its current location
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ILocatable item)
        {
            int x = (int)(item.XPos / _xBlockWidth);
            int y = (int)(item.YPos / _yBlockHeight);

            // Ensure we clamp the ceiling value
            if (x == _numXBlocks) { x--; }
            if (y == _numYBlocks) { y--; }

            _buckets[x, y].Add(item);       
        }

        /// <summary>
        /// Clears all the elements in the world buckets
        /// </summary>
        public void ClearBuckets()
        {
            foreach (GridBucket bucket in _buckets)
            {
                bucket.Clear();
            }
        }
    }
}
