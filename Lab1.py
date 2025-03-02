def gcd(a, b):
    while b:
        a, b = b, a % b
    return a

def reverse_words(s):
    return " ".join(word[::-1] for word in s.split())