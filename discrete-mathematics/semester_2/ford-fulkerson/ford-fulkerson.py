# https://en.wikipedia.org/wiki/Ford%E2%80%93Fulkerson_algorithm

graph = [
    [2, 16, 23, 8, 2],
    [38, 2, 11, 0, 30],
    [27, 35, 3, 16, 15],
    [10, 3, 7, 2, 20],
    [30, 9, 17, 23, 1]
]

def ford_fulkerson(graph, source, sink):
    parent = [-1] * len(graph)
    max_flow = 0

    while bfs(graph, source, sink, parent):
        path_flow = float('inf')
        s = sink

        while s != source:
            path_flow = min(path_flow, graph[parent[s]][s])
            s = parent[s]

        max_flow += path_flow
        v = sink

        while v != source:
            u = parent[v]
            graph[u][v] -= path_flow
            graph[v][u] += path_flow
            v = parent[v]

    return max_flow

def bfs(graph, s, t, parent):
    visited = [False] * len(graph)
    queue = []
    queue.append(s)
    visited[s] = True

    while queue:
        u = queue.pop(0)

        for v in range(len(graph)):
            if not visited[v] and graph[u][v] > 0:
                queue.append(v)
                visited[v] = True
                parent[v] = u

    return visited[t]

stream = ford_fulkerson(graph, 0, 4)

print(f'Максимальный поток: {stream}')
