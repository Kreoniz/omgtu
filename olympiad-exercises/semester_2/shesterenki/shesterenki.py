filename = './tests/input_s1_01.txt';

gear_data = {}
connections = []
edges = set()

with open(filename) as f:
    n, m = [int(x) for x in f.readline().strip().split()]

    for i in range(n):
        num, n_teeth = [int(x) for x in f.readline().strip().split()]
        gear_data[num] = n_teeth

    for i in range(m):
        c = [int(x) for x in f.readline().strip().split()]
        edges |= set(c)
        connections.append(c)
        connections.append(c[::-1])

    fr, to = [int(x) for x in f.readline().strip().split()]
    st_rotate = int(f.readline().strip())

class Gear:
    def __init__(self, num, teeth, rot, rpm):
        self.num = num
        self.teeth = teeth
        self.rot = rot
        self.rpm = rpm

queue = [[Gear(fr, gear_data[fr], st_rotate, 1)]]
i = 0

passable = []

while i < len(queue):
    j = len(queue[i]) - 1
    running = True
    while running:
        pairs = [pair for pair in connections if pair[0] == queue[i][j].num]
        l = 0
        while l < len(pairs):
            if pairs[l][1] in [w.num for w in queue[i]]:
                pairs.pop(l)
            else:
                l += 1

        v = round(queue[i][j].teeth * queue[i][j].rpm / gear_data[pairs[0][1]], 3)
        new_gear = Gear(pairs[0][1], gear_data[pairs[0][1]], queue[i][j].rot * -1, v)
        queue[i].append(new_gear)
        pairs.pop(0)
        if len(pairs) > 0:
            passable.append(pairs[0][0])
            for k in range(1, len(pairs) + 1):
                v = round(
                    queue[i][j].teeth * queue[i][j].rpm / gear_data[pairs[0][1]], 3
                )
                new_gear = Gear(
                    pairs[0][1], gear_data[pairs[0][1]], queue[i][j].rot * -1, v
                )
                queue.insert(i + k, queue[i][: j + 1])
                queue[i + k].append(new_gear)

        if queue[i][-1].num == to:
            running = False
        j += 1
    i += 1

repeat_edges = []
for v in list(edges):
    count = 0
    for q in queue:
        if v in [el.num for el in q]:
            count += 1
    if count > 1:
        repeat_edges.append(v)

bad_edges = set(repeat_edges) - set(passable)

passed = True
for bv in bad_edges:
    last_wheel = 0
    for q in queue:
        bad_v = [g for g in q if g.num == bv]
        if bad_v:
            bad_v = bad_v[0]
            if last_wheel:
                if not (last_wheel.rot == bad_v.rot and last_wheel.rpm == bad_v.rpm):
                    passed = False
                    break
            last_wheel = bad_v
    if not passed:
        break

if not passed:
    print(-1)
else:
    print(1)
    print(queue[0][-1].rot)
    print(queue[0][-1].rpm)
