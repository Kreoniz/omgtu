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
    components = [set()]

    vacant = getVertices(graph)

    components[0].add(graph[0][0])
    components[0].add(graph[0][1])

    vacant.remove(graph[0][0])
    vacant.remove(graph[0][1])

    while len(vacant) > 0:
        for node in graph:
            for i in range(len(components)):
                comp = components[i]
                if node[0] in comp or node[1] in comp:
                    comp.add(node[0])
                    comp.add(node[1])

                    if node[0] in vacant:
                        vacant.remove(node[0])
                    if node[1] in vacant:
                        vacant.remove(node[1])

                else:
                    if i == len(components) - 1:
                        c = set()
                        c.add(node[0])
                        c.add(node[1])
                        components.append(c)

                    if node[0] in vacant:
                        vacant.remove(node[0])
                    if node[1] in vacant:
                        vacant.remove(node[1])

    return components

print(getComponents(graph))
