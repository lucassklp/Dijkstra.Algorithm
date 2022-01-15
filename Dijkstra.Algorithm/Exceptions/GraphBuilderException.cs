using System;

namespace Dijkstra.Algorithm.Exceptions
{
    public class GraphBuilderException : Exception
    {
        internal GraphBuilderException(string message) : base(message)
        {
        }
    }
}