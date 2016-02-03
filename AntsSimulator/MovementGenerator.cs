using System;

namespace AntsSimulator
{
    /// <summary>
    /// Generates the next <see cref="Movement"/>
    /// </summary>
    public class MovementGenerator
    {
        private readonly int _moveMinVal = 1;
        private readonly int _moveMaxVal = 9;

        private Random _random;

        public MovementGenerator(Random random)
        {
            _random = random;
        }

        /// <summary>
        /// Returns a random <see cref="Movement"/>
        /// </summary>
        /// <returns></returns>
        public Movement NextMove()
        {
            int movementVal = _random.Next(_moveMinVal, _moveMaxVal);
            return (Movement)movementVal;
        }
    }
}
