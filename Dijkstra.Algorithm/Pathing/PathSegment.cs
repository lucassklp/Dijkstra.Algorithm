using Dijkstra.Algorithm.Graphing;

namespace Dijkstra.Algorithm.Pathing
{
    public class PathSegment
    {
        public PathSegment(Node origin, Node destination, double weight)
        {
            Weight = weight;
            Origin = origin;
            Destination = destination;
        }

        public Node Origin { get; }
        public Node Destination { get; }
        public double Weight { get; }

    }
}