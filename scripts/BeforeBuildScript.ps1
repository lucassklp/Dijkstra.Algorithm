function UpdateVersion ($path) {
    $file = Get-Item $path
    $xml = [xml](Get-Content $file)
    $node = $xml.Project.PropertyGroup
    $node.Version = "$env:APPVEYOR_BUILD_VERSION"
    $xml.Save($file.FullName)
}

UpdateVersion ('.\Dijkstra.Algorithm\Dijkstra.Algorithm.csproj')

dotnet restore
