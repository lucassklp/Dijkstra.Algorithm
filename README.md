# Dijkstra Algorithm

> Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a graph. [wikipedia](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm)

This is a fork of [agabani's dijkstra C# implementation](https://github.com/agabani/DijkstraAlgorithm) and I have to thanks him. I did nothing but improve his good work and publish on Nuget.

## Installation

If you are using Package Manager:

```bash
Install-Package Dijkstra.Algorithm -Version 1.0.2
```

If you are using .NET CLI

```bash
dotnet add package Dijkstra.Algorithm --version 1.0.2
```

## Example Usage

``` csharp
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
Assert.Equal(path.Origin.Id, origin);
Assert.Equal(path.Destination.Id, destination);
Assert.Equal(path.Segments.Count, 3);
Assert.Equal(path.Segments.Sum(s => s.Weight), 7);

Assert.Equal(path.Segments.ElementAt(0).Origin.Id, "A");
Assert.Equal(path.Segments.ElementAt(0).Weight, 1);
Assert.Equal(path.Segments.ElementAt(0).Destination.Id, "D");

Assert.Equal(path.Segments.ElementAt(1).Origin.Id, "D");
Assert.Equal(path.Segments.ElementAt(1).Weight, 1);
Assert.Equal(path.Segments.ElementAt(1).Destination.Id, "E");

Assert.Equal(path.Segments.ElementAt(2).Origin.Id, "E");
Assert.Equal(path.Segments.ElementAt(2).Weight, 5);
Assert.Equal(path.Segments.ElementAt(2).Destination.Id, "C");
```
