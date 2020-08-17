
namespace TinyRunner
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class TinyRunner
    {
        public static void Attach<T>(T program, params string[] args)
            where T : class, new()
        {
            Stopwatch sw = new Stopwatch();
            var runables = program.GetType().Assembly.GetExportedTypes()
                .Where(x => x.BaseType == typeof(Runner))
                .Where(x => x.GetCustomAttributes(false).OfType<SkipAttribute>().Any() == false);

            foreach (var r in runables)
            {
                var o = (Runner)Activator.CreateInstance(r);
                try
                {
                    o.PrintLine($">>>>>>>>>> :  {r.Name}\n", ConsoleColor.Cyan);
                    sw.Start();
                    o?.Run(args);
                }
                catch (Exception ex)
                {
                    o.PrintLine($"\t{ex.Message}", ConsoleColor.Red);
                }
                finally
                {
                    sw.Stop();
                    o.PrintLine($"\n<<<<<<<<<< :  {r.Name} ~ {sw.ElapsedMilliseconds} ms \n", ConsoleColor.Cyan);
                }
            }
        }

    }
}
