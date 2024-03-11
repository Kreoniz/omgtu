filename = './tests/input_s1_01.txt'

with open(filename, 'rt') as f:
    running_sum = [0, 1]

    count = f.readline()
    for i in range(int(count)):
        operation, number = f.readline().strip().split()

        if number != 'x':
            if operation == '+':
                running_sum[0] += int(number)
            elif operation == '-':
                running_sum[0] -= int(number)
            elif operation == '*':
                running_sum[0] *= int(number)
                running_sum[1] *= int(number)
        elif number == 'x':
            if operation == '+':
                running_sum[1] += 1
            elif operation == '-':
                running_sum[1] -= 1

    result = int(f.readline())

answer = (result - running_sum[0]) / running_sum[1]

print(answer)
