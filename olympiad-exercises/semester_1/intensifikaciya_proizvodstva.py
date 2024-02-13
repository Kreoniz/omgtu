filename = "input_s1_01.txt"

month = {
        1: 31,
        2: 28,
        3: 31,
        4: 30,
        5: 31,
        6: 30,
        7: 31,
        8: 31,
        9: 30,
        10: 31,
        11: 30,
        12: 31,
        }

sdays = 0
edays = 0
with open(filename, "rt") as f:
    sdate = [int(n) for n in f.readline().strip().split(".")]
    edate = [int(n) for n in f.readline().strip().split(".")]
    gain = int(f.readline().strip())

sleapyears = (sdate[2] - (sdate[2] % 4)) / 4
syears = sdate[2] - sleapyears
sdays += (sleapyears * 366) + (syears * 365)
eleapyears = (edate[2] - (edate[2] % 4)) / 4
eyears = edate[2] - eleapyears
edays += (eleapyears * 366) + (eyears * 365)

for m in range(1, sdate[1]):
    sdays += month[m]

for m in range(1, edate[1]):
    edays += month[m]

sdays += sdate[0]
edays += edate[0]

days = edays - sdays + 1
products = int((gain + days - 1 + gain) / 2 * days)
print(products)
