using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Santra : do not touch this code
/// </summary>
namespace ProgramRunner
{
    public sealed class RunThisAttribute : Attribute { }
    public abstract class Runnable
    {
        public abstract void Run(string[] args);
    }
}
