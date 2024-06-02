filename = './tests/input_s1_01.txt'

with open(filename) as file:
    n = int(file.readline().strip())
    words = [file.readline().strip() for _ in range(n)]
    f = int(file.readline().strip())
    restrictions_start = [file.readline().strip() for _ in range(f)]
    l = int(file.readline().strip())
    restrictions_end = [file.readline().strip() for _ in range(f)]

filtered_start = []
for i in restrictions_start:
    for j in range(1, int(i[2:]) + 1):
        filtered_start.append(i[0])

filtered_end = []
for i in restrictions_end:
    for j in range(1, int(i[2:]) + 1):
        filtered_end.append(i[0])

desires = 0
for i in words:
    if ((i[0] in filtered_start) and (i[-1] in filtered_end)):
        desires += 1
        filtered_start.remove(i[0])
        filtered_end.remove(i[-1])

print(desires)
