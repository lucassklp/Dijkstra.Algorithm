using System;

namespace Dijkstra.Algorithm.Exceptions
{
    public class NoPathFoundException : Exception
    {
        internal NoPathFoundException(string message) : base(message)
        {
        }
    }
}