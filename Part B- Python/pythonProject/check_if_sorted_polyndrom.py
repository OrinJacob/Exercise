import math


def is_sorted_polyndrom(st: str) -> bool:
    if not isinstance(st, str):
        raise TypeError("The parameter 'st' must be a string.")

    if len(st) == 0 or len(st) == 1:
        return True

    half_st = st[:math.ceil(len(st) / 2)]
    is_sorted = all(half_st[i] <= half_st[i + 1] for i in range(len(half_st) - 1))

    if not is_sorted:
        return False

    for c in range(len(half_st)):
        if st[c] != st[len(st) - 1 - c]:
            return False

    return True
