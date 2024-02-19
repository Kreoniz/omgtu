graph = [
    [15, 1, 2],
    [14, 1, 5],
    [23, 1, 4],
    [19, 2, 3],
    [16, 2, 4],
    [15, 2, 5],
    [14, 3, 5],
    [26, 3, 6],
    [25, 4, 5],
    [23, 4, 7],
    [20, 4, 8],
    [24, 5, 6],
    [27, 5, 8],
    [18, 5, 9],
    [14, 7, 8],
    [18, 8, 9],
]

def getVertices(graph):
    vertices = []
    for node in graph:
        if (node[1] not in vertices):
            vertices.append(node[1])
        if (node[2] not in vertices):
            vertices.append(node[2])

    return vertices

def kruskalsAlgorithm(graph):
    result = 0
    union = []

    graph = sorted(graph, key=lambda node: node[0])

    union.append(graph[0][1])
    union.append(graph[0][2])
    result += graph[0][0]

    while len(union) < len(getVertices(graph)):
        for node in graph:
            if node[1] in union and node[2] not in union:
                union.append(node[2])
                result += node[0]
                break
            if node[1] not in union and node[2] in union:
                union.append(node[1])
                result += node[0]
                break

    return result

print(kruskalsAlgorithm(graph)) # 133
