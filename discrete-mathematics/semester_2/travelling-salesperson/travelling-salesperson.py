import itertools

def tsp(graph):
    n = len(graph)
    min_distance = float('inf')
    best_path = None

    for path in itertools.permutations(range(1, n)):
        current_distance = 0
        current_city = 0

        for next_city in path:
            current_distance += graph[current_city][next_city]
            current_city = next_city

        current_distance += graph[current_city][0]  # Return to starting city

        if current_distance < min_distance:
            min_distance = current_distance
            best_path = (0,) + path

    return min_distance, best_path

graph = [
    [0, 41, 17, 23, 32],
    [13, 0, 45, 12, 37],
    [80, 45, 0, 50, 64],
    [23, 12, 50, 0, 67],
    [32, 37, 64, 67, 0]
]

min_distance, best_path = tsp(graph)
print(f"Minimum distance: {min_distance}")
print(f"Best path: {best_path}")
