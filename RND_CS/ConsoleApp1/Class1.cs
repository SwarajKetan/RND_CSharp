using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Class1
    {
        public Class1()
        {

        }

        

        public async Task<T> CallAsync<T>(Func<T> func, int millisecondsTimeout)
        {
            var cancellationTokenSource = new CancellationTokenSource(millisecondsTimeout);
            var token = cancellationTokenSource.Token;
            return await Task.Run<T>(func, token);
        }
    }
}
