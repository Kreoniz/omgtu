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
start = 1
s = [start]
n = len(Vertices)
distances = []

for i in range(0, n):
    if i + 1 == start:
        distances.append(0)
    else:
        distances.append(float("inf"))

for i in range(0, n - 1):
    if distances[i] != float("inf"):
        current_distance = distances[i]
        u = i + 1
        for j in range(0, len(Edges)):
            if Edges[j][0] == u:
                v = Edges[j][1]
                additional_distance = Weights[j]
                if distances[v - 1] > current_distance + additional_distance:
                    distances[v - 1] = current_distance + additional_distance

        distances_backup = distances

    else:
        print(distances)
        for finish in range(1, n + 1):
            if finish != start:
                path = [finish]
                result = distances[finish - 1]
                while result != 0:
                    for i in range(0, len(Vertices)):
                        leng = 0
                        pair = [Vertices[i], path[-1]]
                        for j in range(len(Edges)):
                            if Edges[j] == pair:
                                leng = Weights[j]
                                break
                        if distances[Vertices[i] - 1] + leng == result:
                            path.append(Vertices[i])
                            result -= leng
                print(f'ANswer:{finish}:\t{path}')
