using System;

namespace solutions {
  public class Workshop1 {
    /*
     * 1.1. (sum2)
     * takes in 2 numbers, and returns their sum.
     */
    public int Add(int a, int b) {
      return a + b;
    }

    /*
     * 6.1 a (getDivisorsSum) - Get sum of divisors
     * takes in a number, returns sum of all the divisors (except 1 or itself)
     *  i.e., getDivisors(6) -> 5 because 2+3
	   * ITS: returns biggest divisor that is not itself.
     */
    public int GetDivisorsSum(int n) {
      int sum = 0;
      int root = (int) Math.Sqrt(n);
      for (int i = 2; i <= root; i++)
        if (n % i == 0)
          sum += i + n / i;
      return sum > 1 && n == root * root? (sum - root) : sum;
    }

    /*
     * 6.1 b (isPrime) - Primality Test
     * takes in a number, returns if number is prime
     * Questions:
     *  What do with negative numbers or 0?
     */
    public bool IsPrime(int n) {
      if (n <= 1)
        return false;
      if (n == 2)
        return true;
      if (n % 2 == 0)
        return false;
      for (int i = 3; i <= Math.Sqrt(n); i+=2)
        if (n % i == 0)
          return false;
      return true;
    }

    /*
     * 7.1 (gcd)
     * given two numbers find their greatest common divisor
     */
    public int GCD(int a, int b) {
      return b == 0 ? a : GCD(b, a % b);
    }
  }
}
