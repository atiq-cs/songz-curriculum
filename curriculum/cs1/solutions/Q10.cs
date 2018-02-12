using System;
using System.Threading.Tasks;

namespace solutions {
  /// <summary>
  /// A class that either starts an asynchronous operation directly or 
  /// uses timers to start an asynchronous operation indirectly.
  /// The class uses a supplied TaskScheduler or a supplied ITimer.
  /// </summary>
  public class SystemUnderTestTaskSchedulerTimer {
    private readonly TaskScheduler taskScheduler;
    private readonly ITimer timer;
    private bool throwExceptionFlag;
    private readonly Object lockObject = new Object();

    public SystemUnderTestTaskSchedulerTimer(TaskScheduler taskScheduler)
    {
      this.taskScheduler = taskScheduler;
    }

    public SystemUnderTestTaskSchedulerTimer(ITimer timer)
    {
      this.timer = timer;
      this.Message = "Init";
    }

    /// <summary>
    /// Start asynchronus operation with supplied TaskScheduler
    /// </summary>
    public void StartAsynchronousOperation()
    {
      // here goes any initialization
      this.Message = "Init";

      Task task1 = Task.Factory.StartNew(
        () =>
        {
          if (throwExceptionFlag) { throw new Exception(); }
          Message += " Work1";
        },
        System.Threading.CancellationToken.None,
        TaskCreationOptions.None,
        taskScheduler);
      task1.ContinueWith((t) => { Message += " Work2"; }, taskScheduler);
    }

    public void ExecuteFunctionOnDelay(int a, Action handler) {
      StartRecurring(a, handler);
    }

    private void StartRecurring(int seconds, Action handler) {
      timer.StartTimer(() => {
          lock (lockObject) {
            if (throwExceptionFlag) {
              throw new Exception();
            }
            handler();
          }
        },
        new TimeSpan(0, 0, 0, seconds));
    }

    public void StopRecurring()
    {
      timer.StopTimer();
    }

    public string Message { get; set; }

    public void PrepareToThrowException()
    {
      throwExceptionFlag = true;
    }
  }
}
