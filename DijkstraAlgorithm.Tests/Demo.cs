using System.Linq;
using DijkstraAlgorithm.Graphing;
using DijkstraAlgorithm.Pathing;
using Xunit;

namespace DijkstraAlgorithm.Tests
{
    public class Demo
    {
        [Fact]
        public void Test1()
        {
            // Create graph
            var builder = new GraphBuilder();

            builder
                .AddNode("A")
                .AddNode("B")
                .AddNode("C")
                .AddNode("D")
                .AddNode("E");

            builder
                .AddLink("A", "B", 6)
                .AddLink("A", "D", 1);

            builder
                .AddLink("B", "A", 6)
                .AddLink("B", "C", 5)
                .AddLink("B", "D", 2)
                .AddLink("B", "E", 2);

            builder
                .AddLink("C", "B", 5)
                .AddLink("C", "E", 5);

            builder
                .AddLink("D", "A", 1)
                .AddLink("D", "B", 2)
                .AddLink("D", "E", 1);

            builder
                .AddLink("E", "B", 2)
                .AddLink("E", "C", 5)
                .AddLink("E", "D", 1);

            var graph = builder.Build();

            // Find path
            const string origin = "A", destination = "C";

            var path = graph.Dijkstra(origin, destination);

            // Assert results
            Assert.Equal(origin, path.Origin.Id);
            Assert.Equal(destination, path.Destination.Id);
            Assert.Equal(3, path.Segments.Count);
            Assert.Equal(7, path.Segments.Sum(s => s.Weight));

            Assert.Equal("A", path.Segments.ElementAt(0).Origin.Id);
            Assert.Equal(1, path.Segments.ElementAt(0).Weight);
            Assert.Equal("D", path.Segments.ElementAt(0).Destination.Id);

            Assert.Equal("D", path.Segments.ElementAt(1).Origin.Id);
            Assert.Equal(1, path.Segments.ElementAt(1).Weight);
            Assert.Equal("E", path.Segments.ElementAt(1).Destination.Id);

            Assert.Equal("E", path.Segments.ElementAt(2).Origin.Id);
            Assert.Equal(5, path.Segments.ElementAt(2).Weight);
            Assert.Equal("C", path.Segments.ElementAt(2).Destination.Id);
        }


        [Fact]
        public void Test2()
        {
            // Create graph
            var builder = new GraphBuilder();

            builder
                .AddNode("A")
                .AddNode("B")
                .AddNode("C")
                .AddNode("D")
                .AddNode("E")
                .AddNode("F");

            builder
                .AddLink("A", "B", 10)
                .AddLink("A", "C", 15)
                .AddLink("B", "D", 12)
                .AddLink("B", "F", 15)
                .AddLink("C", "E", 10)
                .AddLink("D", "F", 1)
                .AddLink("D", "E", 2);

            var graph = builder.Build();

            // Find path
            const string origin = "A", destination = "E";

            var path = graph.Dijkstra(origin, destination);

            // Assert results
            Assert.Equal(origin, path.Origin.Id);
            Assert.Equal(destination, path.Destination.Id);
            Assert.Equal(3, path.Segments.Count);
            Assert.Equal(24, path.Segments.Sum(s => s.Weight));

            Assert.Equal("A", path.Segments.ElementAt(0).Origin.Id);
            Assert.Equal(10, path.Segments.ElementAt(0).Weight);
            Assert.Equal("B", path.Segments.ElementAt(0).Destination.Id);

            Assert.Equal("B", path.Segments.ElementAt(1).Origin.Id);
            Assert.Equal(12, path.Segments.ElementAt(1).Weight);
            Assert.Equal("D", path.Segments.ElementAt(1).Destination.Id);

            Assert.Equal("D", path.Segments.ElementAt(2).Origin.Id);
            Assert.Equal(2, path.Segments.ElementAt(2).Weight);
            Assert.Equal("E", path.Segments.ElementAt(2).Destination.Id);
        }
    }
}