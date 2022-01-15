using System.Linq;
using DijkstraAlgorithm.Graphing;
using DijkstraAlgorithm.Pathing;
using Xunit;

namespace DijkstraAlgorithm.Tests
{
    public class BiDirectionalTests
    {
        private readonly Graph _graph;

        public BiDirectionalTests()
        {
            var builder = new GraphBuilder();

            builder
                .AddNode("A")
                .AddNode("B")
                .AddNode("C")
                .AddNode("D")
                .AddNode("E");

            builder
                .AddBidirectionalLink("A", "B", 6)
                .AddBidirectionalLink("A", "D", 1);

            builder
                .AddBidirectionalLink("B", "C", 5)
                .AddBidirectionalLink("B", "D", 2)
                .AddBidirectionalLink("B", "E", 2);

            builder
                .AddBidirectionalLink("C", "E", 5);

            builder
                .AddBidirectionalLink("D", "E", 1);

            _graph = builder.Build();
        }

        [Theory]
        [InlineData("A", "B", 3.0d)]
        [InlineData("A", "C", 7.0d)]
        [InlineData("A", "D", 1.0d)]
        [InlineData("A", "E", 2.0d)]
        [InlineData("B", "A", 3.0d)]
        [InlineData("B", "C", 5.0d)]
        [InlineData("B", "D", 2.0d)]
        [InlineData("B", "E", 2.0d)]
        [InlineData("C", "A", 7.0d)]
        [InlineData("C", "B", 5.0d)]
        [InlineData("C", "D", 6.0d)]
        [InlineData("C", "E", 5.0d)]
        [InlineData("D", "A", 1.0d)]
        [InlineData("D", "B", 2.0d)]
        [InlineData("D", "C", 6.0d)]
        [InlineData("D", "E", 1.0d)]
        [InlineData("E", "A", 2.0d)]
        [InlineData("E", "B", 2.0d)]
        [InlineData("E", "C", 5.0d)]
        [InlineData("E", "D", 1.0d)]
        public void Test(string origin, string destination, double weight)
        {
            var path = _graph.Dijkstra(origin, destination);

            Assert.Equal(path.Origin.Id, origin);
            Assert.Equal(path.Destination.Id, destination);
            Assert.Equal(path.Segments.Sum(s => s.Weight), weight);
        }
    }
}