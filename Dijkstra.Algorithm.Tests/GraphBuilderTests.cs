using Dijkstra.Algorithm.Graphing;
using Dijkstra.Algorithm.Pathing;
using System;
using Xunit;

namespace Dijkstra.Algorithm.Tests
{
    public class GraphBuilderTests
    {
        [Fact]
        public void TestRemoveNode()
        {
            var builder = new GraphBuilder();

            builder.AddNode("A")
                .AddNode("B")
                .AddNode("C");

            builder.AddBidirectionalLink("A", "B", 70);
            builder.AddBidirectionalLink("A", "C", 300);
            builder.AddBidirectionalLink("B", "C", 50);

            builder.RemoveNode("B");

            var graph = builder.Build();
            graph.Dijkstra("A", "C");

            Assert.Throws<InvalidOperationException>(() => graph.GetNode("B"));
            Assert.Equal("A", graph.GetNode("A").Id);
            Assert.Equal("C", graph.GetNode("C").Id);

            Assert.Equal(1, graph.GetNode("A").Links.Count);
            Assert.Equal(1, graph.GetNode("C").Links.Count);

            Assert.Equal("C", graph.GetNode("A").Links[0].Destination.Id);
            Assert.Equal("A", graph.GetNode("C").Links[0].Destination.Id);
        }
    }
}
