graph = {
    1: [(2, 35), (3, 46), (5, 97)],
    2: [(3, 13), (4, 34)],
    3: [(4, 13)],
    4: [(5, 23), (7, 67)],
    5: [(6, 23)],
    6: [(9, 64)],
    7: [(8, 13)],
    8: [],
    9: [],
}

def get_path(start, end, prev):
    path = []
    current = end
    while current is not None:
        path.append(current)
        current = prev[current]
    path.reverse()
    return path

def bellman_ford(graph, start):
    dist = {}
    prev = {}

    for vertex in graph:
        dist[vertex] = float('inf')
        prev[vertex] = None
    dist[start] = 0

    for i in range(len(graph) - 1):
        for u in graph:
            for v, w in graph[u]:
                if dist[u] + w < dist[v]:
                    dist[v] = dist[u] + w
                    prev[v] = u

    return dist, prev

start = 1
dist, prev = bellman_ford(graph, start)

for vertex in dist:
    print(f'{start} -> {vertex}:')
    print(f'Вес: {dist[vertex]}')
    path = get_path(start, vertex, prev)
    print(f'Путь: {" -> ".join([str(i) for i in path])}')
    print()
