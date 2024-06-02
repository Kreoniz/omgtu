filename = './tests/input_s1_01.txt';

with open(filename) as f:
    words = []
    while True:
        a = f.readline().strip()
        if a == '':
            break
        else:
            words.append(a[0]+a[-1])

def recursive_search(curr, paths, ans, is_top_level=True):
    if curr[0][0] == curr[-1][-1]:
        n = min(paths.count(i) for i in curr) + 1
        if n > 0:
            curr *= n
        tmp = []

        for i in curr:
            tmp += [i] * (paths.count(i) - n)
            paths = tmp
        ans.append(curr)

    p = list(set([i for i in paths if i[0] == curr[-1][-1]]))

    if len(p) == 0:
        if is_top_level:
            ans.sort(key=lambda x: len(x), reverse=True)
            return len(ans[0]), ans[0]
        return

    for i in p:
        a = [i for i in curr]
        a.append(i)
        b = [i for i in paths]
        b.remove(i)
        recursive_search(a, b, ans, False)

    if is_top_level:
        ans.sort(key = lambda x: len(x), reverse=True)
        return len(ans[0]), ans[0]

ans = []

running = True

while running:
    max_len = 0
    max_path = []

    for i in list(set(words)):
        k = [j for j in words]
        k.remove(i)
        result = recursive_search([i], k, [])

        if result is not None:
            if result[0] > max_len:
                max_len, max_path = result[0], result[1]

    if max_len == 0:
        print(len(ans))
        for i in ans:
            print(i)
        running = False

    if running:
        ans.append(max_len)
        for i in max_path:
            words.remove(i)
