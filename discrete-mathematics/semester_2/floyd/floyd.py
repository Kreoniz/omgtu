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
    [1, 3],
    [1, 5],
    [2, 3],
    [2, 4],
    [4, 5],
    [4, 7],
    [5, 6],
    [7, 8],
    [6, 9],
]
Weights = [19, 35, 13, 46, 34, 23, 67, 23, 13, 64, 97]
start, fin = 1, 6
minDistances = {start: 0}
index = 0
used = [1]

start, fin = 1, 6
g = []

for i in range(1, len(Vertices) + 1):
    stroka = []
    for j in range(1, len(Vertices) + 1):
        pair = [i, j]
        if pair in Edges:
            stroka.append(Weights[Edges.index(pair)])
        else:
            stroka.append(float("inf"))
    g.append(stroka)

start_g = [x[:] for x in g]

for i in range(len(Vertices)):
    for j in range(len(Vertices)):
        print(g[i][j], end="\t")
    print("\n")

for p in range(0, len(Vertices)):
    for i in range(0, len(Vertices)):
        for j in range(0, len(Vertices)):
            if i != j:
                g[i][j] = min(g[i][j], g[i][p] + g[p][j])

print(" ")
for i in range(len(Vertices)):
    for j in range(len(Vertices)):
        print(g[i][j], end="\t")
    print("\n")

print(" ")
print(f"Путь: {start} => {fin}")
path = [fin]
result = g[start - 1][fin - 1]

while result != 0:
    for i in range(0, len(Vertices)):
        leng = 0
        pair = [i + 1, path[-1]]
        for j in range(len(Edges)):
            if Edges[j] == pair:
                leng = Weights[j]
        if start - 1 == i:
            if leng == result:
                path.append(i + 1)
                result -= leng
                break
        elif g[start - 1][i] + leng == result and leng != 0:
            path.append(i + 1)
            result -= leng
print(path)
