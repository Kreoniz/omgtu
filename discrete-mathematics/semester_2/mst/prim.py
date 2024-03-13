import heapq

# [weight, point1, point2]
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

def getAdjacencyList(graph):
    vertices = getVertices(graph)
    vertexCount = len(vertices)

    # list of [cost, node]
    adj = { vertex:[] for vertex in vertices}
    for i in range(len(graph)):
        weight, x1, y1 = graph[i]
        adj[x1].append([weight, y1])
        adj[y1].append([weight, x1])

    return adj

def primsAlgorithm(graph):
    adj = getAdjacencyList(graph)
    vertexCount = len(getVertices(graph))

    result = 0
    visited = set()
    # [cost, node]
    minHeap = [[0, graph[0][1]]]

    while len(visited) < vertexCount:
        cost, node = heapq.heappop(minHeap)
        if node in visited:
            continue
        result += cost
        visited.add(node)
        for neighbourCost, neighbour in adj[node]:
            if neighbour not in visited:
                heapq.heappush(minHeap, [neighbourCost, neighbour])

    return result

print(primsAlgorithm(graph)) # 133
