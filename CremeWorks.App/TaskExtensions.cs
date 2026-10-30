using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CremeWorks.App;
public static class TaskExtensions
{
    /// <summary>
    /// Starts a task nobody waits for. Use this instead of an <c>async void</c> method, so that a failing
    /// task gets reported instead of tearing down the whole application on an unhandled exception.
    /// </summary>
    public static void FireAndForget(this Task task) => task.ContinueWith(
        static t => Debug.WriteLine("Unobserved error in a background task: " + t.Exception),
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
}
