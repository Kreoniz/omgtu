filename = 'input_s1_16.txt'

hierarchy = {}
name = None

with open(filename, 'rt') as f:
    i = 0
    line = f.readline().strip()
    current_commander_code = None

    while line != 'END':
        code = line[:4]
        if len(line) > len(code):
            name = line[5:]

        info = {
            'name': None,
            'subordinate_codes': [],
        }

        if (code not in hierarchy):
            hierarchy[code] = info

        if i % 2 == 0:
            current_commander_code = code
        else:
            hierarchy[current_commander_code]['subordinate_codes'].append(code)

        if name:
            hierarchy[code]['name'] = name
            name = None

        i += 1
        line = f.readline().strip()

    name = f.readline().strip()

code = None
for c in hierarchy:
    if (hierarchy[c]['name'] == name):
        code = c
        break

def getSubordinates(code):
    subordinates = []
    for c in hierarchy[code]['subordinate_codes']:
         subordinates.append([c, hierarchy[c]['name']])
         subordinates += getSubordinates(c)

    return subordinates

subordinates = sorted(getSubordinates(code))

if subordinates:
    for code, name in subordinates:
        if name:
            print(code, name)
        else:
            print(code, 'Unknown Name')
else:
    print('None')
