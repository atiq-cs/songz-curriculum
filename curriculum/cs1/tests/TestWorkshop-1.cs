using System;
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
  }
}
