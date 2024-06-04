# https://en.wikipedia.org/wiki/Lee_algorithm
from collections import deque
from pprint import pprint


matrix = [
    [' ', '|', ' ', ' ', ' ', ' ', ' '],
    [' ', '|', ' ', '|', '|', '|', ' '],
    [' ', '|', ' ', '|', ' ', ' ', ' '],
    [' ', '|', ' ', '|', ' ', '|', '|'],
    [' ', '|', ' ', '|', ' ', ' ', ' '],
    [' ', '|', ' ', '|', ' ', ' ', ' '],
    [' ', '|', ' ', '|', '|', '|', ' '],
    [' ', '|', ' ', '|', ' ', ' ', ' '],
    [' ', '|', ' ', '|', ' ', '|', '|'],
    [' ', '|', ' ', '|', ' ', '|', ' '],
    [' ', ' ', ' ', '|', ' ', ' ', ' '],

]

def find_path(matrix, start, end):
    rows, cols = len(matrix), len(matrix[0])
    directions = [(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1)]
    queue = deque([(start, 0)])
    matrix[start[0]][start[1]] = 0

    while queue:
        (x, y), dist = queue.popleft()

        if (x, y) == end:
            return dist, reconstruct_path(matrix, start, end)

        for dx, dy in directions:
            nx, ny = x + dx, y + dy

            if 0 <= nx < rows and 0 <= ny < cols and matrix[nx][ny] == ' ':
                matrix[nx][ny] = dist + 1
                queue.append(((nx, ny), dist + 1))

    return None, []


def reconstruct_path(matrix, start, end):
    path = []
    x, y = end
    end_value = matrix[end[0]][end[1]]
    directions = [(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1)]

    while (x, y) != start:
        path.append((x, y))
        for dx, dy in directions:
            nx, ny = x + dx, y + dy
            if 0 <= nx < len(matrix) and 0 <= ny < len(matrix[0]) and matrix[nx][ny] == end_value - 1:
                x, y = nx, ny
                end_value -= 1
                break

    path.append(start)
    path.reverse()
    return path


start = (0, 0)
end = (10, 6)

print(f'Путь из {start} в {end}:')
print('Матрица:')
pprint(matrix)
print()

steps, path = find_path(matrix, start, end)

if steps:
    print(f'Количество шагов: {steps}')
    print('Путь:')
    pprint(path)
else:
    print('Пути нет')

