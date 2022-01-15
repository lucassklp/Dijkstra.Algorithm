using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgorithm.Graphing
{
    public class Graph
    {
        private readonly List<Node> _nodes;

        private Graph()
        {
            _nodes = new List<Node>();
        }

        public IReadOnlyList<Node> Nodes => _nodes;

        internal static Graph Create()
        {
            return new Graph();
        }

        public Node GetNode(string id) => Nodes.Single(node => node.Id == id);

        internal void Add(Node node)
        {
            _nodes.Add(node);
        }
    }
}