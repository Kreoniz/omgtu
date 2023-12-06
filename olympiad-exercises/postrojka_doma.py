print('Постройка дома')
filename = './input_s1_01.txt'

with open(filename) as f:
    X, Y, L, C1, C2, C3, C4, C5, C6 = [int(i) for i in f.readline().split(' ')]

    whole_wall = 2*X + 2*Y

    repaired_wall = 0
    rebuilt_wall = 0
    new_wall = 0

    repaired_wall = min(L, max(X, Y))
    whole_wall -= repaired_wall
    L -= repaired_wall

    rebuilt_wall = min(L, whole_wall)
    L -= rebuilt_wall
    whole_wall -= rebuilt_wall

    new_wall = whole_wall

    min_cost = repaired_wall * C1 + rebuilt_wall * (C2 + C3) + new_wall * (C4 + C5) + L * (C2 + C6)

    print(f'Минимальная сумма: {min_cost}')
