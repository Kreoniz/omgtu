from math import floor

n = int(input())


def selection(num):
    if num == 3:
        return 1
    elif num < 3:
        return 0
    else:
        ceven = floor(num / 2)
        codd = floor(num / 2) + (num % 2)
        return selection(ceven) + selection(codd)


print(selection(n))
