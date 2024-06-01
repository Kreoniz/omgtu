filename = "./tests/input_s1_01.txt"

with open(filename) as f:
    line = f.readline().split()

words_number = len(line)
converted = [''] * words_number
count = words_number - (words_number % 2) - 1
flag = False

for i in line:
    word = i
    k = len(i) - 1
    new_word = [''] * len(i)
    if (len(i) % 2) != 0: word = word[::-1]
    for j in range(len(i)):
        new_word[k] = word[0]
        word = word.replace(word[0], '', 1)
        word = word[::-1]
        k -= 1
    converted[count] = ''.join(new_word)

    if not flag:
        count -= 2
    else:
        count += 2

    if count < 0:
        count = 0
        flag = True

print(' '.join(converted))
