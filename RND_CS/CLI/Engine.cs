
namespace CLI
{
    using System;
    public class Engine : CliBase
    {
        public Engine() 
            : base()
        {
        }

        [Command(Cmd = "-sum", Description = "Sums two or more numbers")]
        public ICmdResult Sum(object[] nums)
        {
            return SafeExecute(() =>
            {
                if (nums.Length == 0)
                    return Error("Args expected.");

                double s = 0;
                foreach (var n in nums)
                    s += Convert.ToDouble(n);
                return Ok(s);
            });
        }

        [Command(Cmd = "-mul", Description = "Multiplies two or more numbers")]
        public ICmdResult Mul(object[] nums)
        {
            return SafeExecute(() =>
            {
                if (nums.Length == 0)
                    return Error("Args expected.");

                double s = 1;
                foreach (var n in nums)
                    s *= Convert.ToDouble(n);
                return Ok(s);
            });
        }

        [Command(Cmd = "-sqrt", Description = "Evaluates square root of a number")]
        public ICmdResult Sqrt(object[] nums)
        {
            return SafeExecute(() =>
            {
                if (nums.Length == 0)
                    return Error("Args expected.");

                return Ok(Math.Sqrt(Convert.ToDouble(nums[0])));
            });
        }

        [Command(Cmd = "-login", Description = "Login with user and password")]
        public ICmdResult Login(params object[] args)
        {
            return SafeExecute(() =>
            {
                if (args.Length != 2)
                    return Error("Login failed. Args expected.");

                return Ok("Login successful!");
            });
        }

        
    }
}
