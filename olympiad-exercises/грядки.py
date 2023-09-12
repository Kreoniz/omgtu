K = [1, 2, 3, 20]

# Формула
for i in range(len(K)):
    k = K[i]

    l = 7
    n = 5
    m = 10

    s = k*(2*l + 2*n) + (k**2 + k)*m

    print(f"{K[i]}: {s}")

print()

# Цикл
for i in range(len(K)):
    k = K[i]

    l = 7
    n = 5
    m = 10

    s = 0
    for j in range(k):
        s += 2*l + 2*n + 2*m + j*2*m

    print(f"{K[i]}: {s}")
