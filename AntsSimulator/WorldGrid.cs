namespace AntsSimulator
{
    /// <summary>
    /// Representation of the world in a grid that contains <see cref="GridBucket"/> elements. Each grid element contains
    /// a reference to a <see cref="ILocatable"/> that may be visible given the maximum view distance. This allows us to
    /// heavily optimiste for object collisions to try avoid needing to do a N^2 search.
    /// </summary>
    public class WorldGrid
    {
        private readonly int _numXBlocks;
        private readonly int _numYBlocks;
        private readonly float _xBlockWidth;
        private readonly float _yBlockHeight;
        private readonly int _maxViewDistance;
        private GridBucket[,] _buckets;

        // TODO Make WorldGrid implement IEnumberable<T> instead of expose through property?
        public GridBucket[,] WorldBuckets { get { return _buckets; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xBlocks">Number of x blocks to represent the world</param>
        /// <param name="yBlocks">Number of y blocks to represent the world</param>
        /// <param name="bounds">World boundries</param>
        /// <param name="maxViewDistance">Max viewing distance</param>
        public WorldGrid(int xBlocks, int yBlocks, WorldBounds bounds, int maxViewDistance)
        {
            _numXBlocks = xBlocks;
            _numYBlocks = yBlocks;
            _xBlockWidth = (float)bounds.XBound / (float)xBlocks;
            _yBlockHeight = (float)bounds.YBound / (float)yBlocks;
            _maxViewDistance = maxViewDistance;

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
        /// Adds the specified <see cref="ILocatable"/> to any <see cref="GridBucket"/> that could
        /// potentially be visible given the max view distance.
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

            // TODO calculate if the item could be visible from anothing grid bucket and 
            // add it to the coresponding buckets.            
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
