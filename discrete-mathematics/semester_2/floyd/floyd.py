def get_vertices(graph):
    vertices = set()
    for node in graph:
        vertices.add(node[0])
        vertices.add(node[1])

    return vertices


def floyd_algorithm(graph):
    n = len(get_vertices(graph))
    dist = [[float('inf')] * n for _ in range(n)]

    for i in range(len(dist)):
        dist[i][i] = 0

    for u, v, w in graph:
        dist[u][v] = w
        dist[v][u] = w

    for k in range(n):
        for i in range(n):
            for j in range(n):
                dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j])

    return dist

graph = [
    (0, 1, 19),
    (1, 2, 35),
    (2, 3, 13),
    (1, 3, 46),
    (2, 4, 34),
    (4, 5, 23),
    (4, 7, 67),
    (5, 6, 23),
    (7, 8, 13),
    (6, 9, 64),
    (1, 5, 97),
]

distances = floyd_algorithm(graph)

print('Вершины:', end='\t')
for i in range(len(distances[0])):
    print(f'{i}', end="\t")

print()
print()

for i in range(len(distances)):
    print(f'Вершина {i}:', end='\t')
    for j in range(len(distances[i])):
        print(f'{distances[i][j]}', end="\t")

    print()
