using System;

namespace Dijkstra.Algorithm.Exceptions
{
    public class PathFinderException : Exception
    {
        internal PathFinderException(string message) : base(message)
        {
        }
    }
}