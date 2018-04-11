using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class BoardGameException : Exception
    {
        public BoardGameException()
        {

        }

        public BoardGameException(string message)
            : base(message)
        {

        }

        public BoardGameException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
