using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CommonLib
{
    public class AsyncDemo
    {
        ILogger _logger;
        public AsyncDemo(ILogger logger)
        {
            _logger = logger;
        }
        public async Task LongTask()
        {
            Task<bool> blnIsLeapYear = TaskOfTResultReturning_AsyncMethod();

            for (int i = 0; i <= 10000; i++)
            {
                // Do other work that does not rely on blnIsLeapYear before awaiting 
            }

            bool isLeapYear = await TaskOfTResultReturning_AsyncMethod();
            _logger.LogDebug($"{DateTime.Now.Year} {(isLeapYear ? " is " : "  is not  ")} a leap year");

            Task taskReturnMethhod = TaskReturning_AsyncMethod();

            for (int i = 0; i <= 10000; i++)
            {
                // Do other work that does not rely on taskReturnMethhod before awaiting 
            }

            await taskReturnMethhod;
        }
        async Task<bool> TaskOfTResultReturning_AsyncMethod()
        {
            return await Task.FromResult<bool>(DateTime.IsLeapYear(DateTime.Now.Year));
        }

        async Task TaskReturning_AsyncMethod()
        {
            await Task.Delay(5000);
            _logger.LogDebug("5 second delay");
        }
    }
}
