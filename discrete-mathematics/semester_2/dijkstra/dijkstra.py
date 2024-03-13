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

def getVertices(graph):
    vertices = set()
    for node in graph:
        vertices.add(node[0])
        vertices.add(node[1])

    return list(vertices)

print(getVertices(graph));

def dijkstra(graph, source, dest):
    vertices = {v: {'dist': float('inf'), 'prev': None, 'exp': False} for v in getVertices(graph)}

    print(vertices)

    while vertices[dest]['exp'] == False:
        v = 

    return [source, dest]

print()
print(dijkstra(graph, 1, 7))
