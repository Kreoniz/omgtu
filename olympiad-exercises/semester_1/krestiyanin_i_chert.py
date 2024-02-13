MaxN = int(input())

combos = 0
for n in range(1, MaxN + 1):
    for i in range(2, 18):
        if n % (2 ** i - 1) == 0:
            combos += 1

print(MaxN + combos)
