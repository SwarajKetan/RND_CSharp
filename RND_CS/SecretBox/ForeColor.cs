using System;
using System.Collections.Generic;
using System.Text;

namespace SecretBox
{
    public class ForeColor : IDisposable
    {
        //private ConsoleColor _foreColor;
        public ForeColor(ConsoleColor foreColor)
        {
            Console.ForegroundColor = foreColor;
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Console.ResetColor();
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
