namespace ProgramRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            TinyRunner.TinyRunner.Attach(new Program(), args);
        }
    }
}
