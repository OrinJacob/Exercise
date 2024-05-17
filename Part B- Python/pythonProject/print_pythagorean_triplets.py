import math


def pythagorean_triplet_by_sum(sum: int):
    if not isinstance(sum, int):
        raise TypeError("The parameter 'sum' must be an integer.")

    for i in range(1, sum - 1):
        a = i
        for j in range(a + 1, sum):
            b = j
            c = math.sqrt(math.pow(a, 2) + math.pow(b, 2))
            if c % 1 == 0 and a + b + c == sum:
                print(f'{a} < {b} < {int(c)}')
