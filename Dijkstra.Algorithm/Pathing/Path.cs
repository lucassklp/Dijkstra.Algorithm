using System.Collections.Generic;
using Dijkstra.Algorithm.Graphing;

namespace Dijkstra.Algorithm.Pathing
{
    public class Path
    {
        private readonly List<PathSegment> _segments;

        public Path(Node origin)
        {
            Origin = origin;
            _segments = new List<PathSegment>();
        }

        public Node Origin { get; }
        public Node Destination { get; private set; }
        public IReadOnlyList<PathSegment> Segments => _segments;

        public Path AddSegment(PathSegment segment)
        {
            Destination = segment.Destination;
            _segments.Add(segment);
            return this;
        }
    }
}