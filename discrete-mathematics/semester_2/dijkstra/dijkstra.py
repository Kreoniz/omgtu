graph = [
    [0, 1, 19],
    [1, 2, 35],
    [2, 3, 13],
    [1, 3, 46],
    [2, 4, 34],
    [4, 5, 23],
    [4, 7, 67],
    [5, 6, 23],
    [7, 8, 13],
    [6, 9, 64],
    [1, 5, 97],
]

print(graph)

Vertices = [1, 2, 3, 4, 5, 6, 7, 8, 9]
Edges = [
    [0, 1],
    [1, 2],
    [2, 3],
    [1, 3],
    [2, 4],
    [4, 5],
    [4, 7],
    [5, 6],
    [7, 8],
    [6, 9],
    [1, 5],
]
Weights = [19, 35, 13, 46, 34, 23, 67, 23, 13, 64, 97]
start, fin = 1, 6
s = [start]
minDistances = {start: 0}
index = 0
used = [1]

for i in range(len(Edges)):
    if Edges[i][0] == start:
        minDistances[Edges[i][1]] = Weights[i]
        used.append(Edges[i][1])

for i in Vertices:
    if used.count(i) == 0:
        minDistances[i] = float("inf")

while True:
    currentElement = s[index]
    possibleVertices = []
    possibleWeights = []

    for i in range(len(Edges)):
        if Edges[i][0] == currentElement:
            possibleVertices.append(Edges[i][1])
            possibleWeights.append(Weights[i])

    for i in possibleVertices:
        if s.count(i) == 0:
            value = min(
                minDistances[i],
                minDistances[currentElement]
                + possibleWeights[possibleVertices.index(i)],
            )
            minDistances[i] = value

    minWeights = float("inf")
    for key, value in minDistances.items():
        if s.count(key) == 0:
            if value < minWeights:
                minWeights = value
                minEdges = key
    if minEdges != fin:
        s.append(minEdges)
        index += 1
    else:
        minDistances[minEdges] = minDistances[minEdges] + possibleWeights.index(
            min(possibleWeights)
        )
        break

result = minDistances[fin]

path = [fin]

for i in range(0, len(Vertices)):
    leng = 0
    pair = [Vertices[i], path[-1]]
    for j in range(len(Edges)):
        if Edges[j] == pair:
            leng = Weights[j]
            break
    if minDistances[Vertices[i]] + leng == result:
        path.append(Vertices[i])
        result -= leng
path.append(start)

print(f"Самый короткий путь: {result}")
print(f"Маршрут самого короткого пути: {path}")
print(f"Коротчайшие пути для каждой вершины из вершины {start}: {minDistances}")
