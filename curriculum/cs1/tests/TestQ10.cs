using Microsoft.VisualStudio.TestTools.UnitTesting;
using solutions;

namespace tests {
  [TestClass]
  public class TestQ10 {
    /// <summary>
    /// VeryFastAndReliableTestWithTimer
    /// Reference for this test implementation with Async support
    /// https://msdn.microsoft.com/en-us/magazine/dn818494.aspx
    /// </summary>
    [TestMethod]
    public void TestTestFunctionOnDelayWithTimerSynchronously() {
      // Setup
      var dt = new DeterministicTimer();
      var sut = new SystemUnderTestTaskSchedulerTimer(dt);

      // Execute
      sut.ExecuteFunctionOnDelay(5, () => {
          sut.Message += " Counter5";
        }
      );

      // max 4s before assert
      for (int i=0; i<5; i++) {
        Assert.AreEqual("Init", sut.Message);
        dt.ElapseSeconds(1);
      }

      // time 5s has elapsed
      sut.StopRecurring();
      Assert.AreEqual("Init Counter5", sut.Message);

      // Similarly Execute for 10s
      sut.ExecuteFunctionOnDelay(10, () => {
          sut.Message += " Counter10";
        }
      );

      // max 9s before assert
      for (int i = 0; i < 10; i++) {
        Assert.AreEqual("Init Counter5", sut.Message);
        dt.ElapseSeconds(1);
      }

      // time 10s has elapsed
      sut.StopRecurring();
      // Assert that outcome of two executions of the recurring operation is ok.
      Assert.AreEqual("Init Counter5 Counter10", sut.Message);
    }
  }
}
