using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using solutions;

namespace tests {
  [TestClass]
  public class TestWorkshop1 {
    [TestMethod]
    public void TestAdd() {
      // Test against a list of values
      List<int> inputValuesArg1 = new List<int> { 1, 2, 3, 5 };
      List<int> inputValuesArg2 = new List<int> { 6, 7, 8, 9 };
      List<int> expectedValues  = new List<int> { 7, 9, 11, 14 };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValuesArg1.Count; i++) {
        int input1 = inputValuesArg1[i];
        int input2 = inputValuesArg2[i];
        int expected = expectedValues[i];
        int actual = workshop.Add(input1, input2);
        Assert.AreEqual(expected, actual, "func Add failed for " + input1 + ", " + input2);
      }
    }

    [TestMethod]
    public void TestPrintStr() {
      // Test against a list of pairs of number and string
      List<int> inputValuesArg1 = new List<int> { 0, 1, 2, 3, 5 };
      List<string> inputValuesArg2 = new List<string> { "joe", "tom", "abc", "joe", "hi" };
      List<string> expectedValues = new List<string> { "", "tom", "abcabc", "joejoejoe", "hihihihihi" };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValuesArg1.Count; i++) {
        int n = inputValuesArg1[i];
        string str = inputValuesArg2[i];
        string expected = expectedValues[i];
        string actual = workshop.PrintStr(n, str);
        Assert.AreEqual(expected, actual, "func PrintStr failed for " + n + ", " + str);
      }
    }

    [TestMethod]
    public void TestDivisorSum() {
      List<int> inputValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
        12, 13, 14, 17, 18, 21, 28, 97, 100 };
      List<int> expectedValues = new List<int> { 0, 0, 0, 2, 0, 5, 0, 6, 3, 7, 0,
        15, 0, 9, 0, 20, 10, 27, 0, 116 };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValues.Count; i++) {
        int input = inputValues[i];
        int expected = expectedValues[i];
        int actual = workshop.GetDivisorsSum(input);
        Assert.AreEqual(expected, actual, "func getDivisorsSum failed for " + input);
      }
    }

    [TestMethod]
    public void TestPrimality() {
      List<int> inputValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
        12, 13, 14, 17, 18, 21, 28, 97, 100 };
      List<bool> expectedValues = new List<bool> { false, true, true, false,
        true, false, true, false, false, false, true, false, true, false, true,
        false, false, false, true, false };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValues.Count; i++) {
        int input = inputValues[i];
        bool expected = expectedValues[i];
        bool actual = workshop.IsPrime(input);
        Assert.AreEqual(expected, actual, "func isPrime failed for " + input);
      }
    }

    [TestMethod]
    public void TestGCD() {
      List<int> inputValuesArg1 = new List<int> { 30, 30, 10, 15 };
      List<int> inputValuesArg2 = new List<int> { 45, 43, 10, 5 };
      List<int> expectedValues  = new List<int> { 15, 1, 10, 5 };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValuesArg1.Count; i++) {
        int input1 = inputValuesArg1[i];
        int input2 = inputValuesArg2[i];
        int expected = expectedValues[i];
        int actual = workshop.GCD(input1, input2);
        Assert.AreEqual(expected, actual, "func gcd failed for " + input1 + ", " + input2);
      }
    }

    [TestMethod]
    public void TestGetNextMultipleOfSeven() {
      List<int> inputValues = new List<int> { 1, 14, 21, 28 };
      List<int> expectedValues = new List<int> { 7, 21, 28, 35 };

      Workshop1 workshop = new Workshop1();

      for (int i = 0; i < inputValues.Count; i++) {
        int input = inputValues[i];
        int expected = expectedValues[i];
        int actual = workshop.GetNextMultipleOfSeven(input);
        Assert.AreEqual(expected, actual, "func find7m failed for " + input);
      }
    }
  }
}
