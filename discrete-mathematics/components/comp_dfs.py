# [vertex1, vertex2]
graph = [
        [0, 1],
        [0, 2],
        [2, 1],

        [4, 3],
        [3, 5],
        [5, 8],
        [9, 3],
        [9, 7],
        [7, 6],

        [10, 11],
        [10, 12],
        [10, 13],
        [10, 14],
        [10, 15],
]

def getVertices(graph):
    vertices = set()

    for node in graph:
        vertices.add(node[0])
        vertices.add(node[1])

    return sorted(list(vertices))

def getComponents(graph):
    components = []

    vacant = getVertices(graph)

    graph_copy = graph.copy()

    while len(vacant) > 0:
        cur_comp = set()
        cur_comp.add(vacant.pop(0))
        for node in graph_copy:
            if node[0] in cur_comp or node[1] in cur_comp:
                cur_comp.add(node[0])
                cur_comp.add(node[1])

                if node[0] in vacant:
                    vacant.remove(node[0])
                if node[1] in vacant:
                    vacant.remove(node[1])

        components.append(cur_comp)

        graph_copy = [node for node in graph_copy if node[0] not in cur_comp and node[1] not in cur_comp]

    return components

print(getComponents(graph))
