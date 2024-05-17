import mpmath


def reverse_n_pi_digits(n: int) -> str:
    mpmath.mp.dps = n
    reversed_n_pi_digits = ' '.join(str(mpmath.pi).replace('.', '')[::-1])
    return reversed_n_pi_digits
