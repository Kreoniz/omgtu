graph = [
    [0, 1, 0, 0, 1, 0, 1],
    [1, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 1, 1, 1, 0],
    [1, 0, 1, 1, 0, 1, 0],
    [1, 1, 0, 0, 1, 0, 0],
    [0, 0, 0, 1, 1, 0, 0],
    [0, 1, 1, 0, 1, 1, 1]
]

def is_valid(v, pos, path, graph):
    if graph[path[pos - 1]][v] == 0:
        return False

    if v in path:
        return False

    return True

def hamiltonian_cycle(graph, path, pos):
    if pos == len(graph) and graph[path[pos - 1]][path[0]] == 1:
        return True

    for v in range(1, len(graph)):
        if is_valid(v, pos, path, graph):
            path[pos] = v

            if hamiltonian_cycle(graph, path, pos + 1):
                return True

            path[pos] = -1

    return False

n = len(graph)
path = [-1 for _ in range(n)]

path[0] = 0

if hamiltonian_cycle(graph, path, 1):
    print("Гамильтонов путь:")
    print(path)
