﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsSimulator
{
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