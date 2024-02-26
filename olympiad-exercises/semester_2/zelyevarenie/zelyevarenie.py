filename = './tests/input1.txt'

with open(filename, 'rt') as f:
    commands = [line.strip() for line in f.readlines()]

results = []

actions = {
        'MIX': 'MX',
        'WATER': 'WT',
        'DUST': 'DT',
        'FIRE': 'FR',
        }

for i, command in enumerate(commands):
    action, *ingredients = command.split(' ')

    ingredient = ''
    for item in ingredients:
        if item.isdigit():
            ingredient += results[int(item) - 1]
        else:
            ingredient += item

    ingredient = actions[action] + ingredient + actions[action][::-1]
    results.append(ingredient)

print(results[-1])
