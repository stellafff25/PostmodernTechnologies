import pytest
from Lab1 import gcd, reverse_words, is_prime

def test_gcd_extended():
    assert gcd(48, 18) == 6
    assert gcd(101, 103) == 1
    assert gcd(56, 98) == 14

def test_reverse_words():
    assert reverse_words("hello world") == "olleh dlrow"
    assert reverse_words("Python is great") == "nohtyP si taerg"

def test_is_prime():
    assert is_prime(19) is True
    assert is_prime(2) is True
    assert is_prime(18) is False
    assert is_prime(1) is False