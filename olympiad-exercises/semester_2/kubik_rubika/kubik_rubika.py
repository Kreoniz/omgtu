filename = './tests/input_s1_01.txt'

with open(filename) as file:
    def rotate(primary, secondary, steps, lower_bound, upper_bound):
        while steps != 0:
            if primary == lower_bound and secondary == lower_bound:
                secondary += 1
            elif primary == upper_bound and secondary == upper_bound:
                secondary -= 1
            elif primary == lower_bound and secondary == upper_bound:
                primary += 1
            elif primary == upper_bound and secondary == lower_bound:
                primary -= 1
            elif primary == lower_bound and secondary < upper_bound:
                secondary += 1
            elif secondary == upper_bound and primary < upper_bound:
                primary += 1
            elif primary == upper_bound and secondary > lower_bound:
                secondary -= 1
            elif secondary == lower_bound and primary > lower_bound:
                primary -= 1
            steps -= 1
        return primary, secondary

    n, m = map(int, file.readline().split())
    coord_x, coord_y, coord_z = map(int, file.readline().split())
    center = (n - 1) / 2 + 1

    for _ in range(m):
        axis, row, direction = file.readline().split()
        row = int(row)
        direction = int(direction)

        if axis == 'X' and coord_x == row:
            max_distance = max(abs(coord_y - center), abs(coord_z - center))
            if max_distance == 0:
                continue
            steps = int(max_distance / 0.5)
            lower_bound, upper_bound = center - max_distance, center + max_distance
            if direction == 1:
                coord_y, coord_z = rotate(coord_y, coord_z, steps, lower_bound, upper_bound)
            else:
                coord_z, coord_y = rotate(coord_z, coord_y, steps, lower_bound, upper_bound)

        elif axis == 'Y' and coord_y == row:
            max_distance = max(abs(coord_x - center), abs(coord_z - center))
            if max_distance == 0:
                continue
            steps = int(max_distance / 0.5)
            lower_bound, upper_bound = center - max_distance, center + max_distance
            if direction == 1:
                coord_x, coord_z = rotate(coord_x, coord_z, steps, lower_bound, upper_bound)
            else:
                coord_z, coord_x = rotate(coord_z, coord_x, steps, lower_bound, upper_bound)

        elif axis == 'Z' and coord_z == row:
            max_distance = max(abs(coord_x - center), abs(coord_y - center))
            if max_distance == 0:
                continue
            steps = int(max_distance / 0.5)
            lower_bound, upper_bound = center - max_distance, center + max_distance
            if direction == 1:
                coord_x, coord_y = rotate(coord_x, coord_y, steps, lower_bound, upper_bound)
            else:
                coord_y, coord_x = rotate(coord_y, coord_x, steps, lower_bound, upper_bound)

    print(coord_x, coord_y, coord_z)
