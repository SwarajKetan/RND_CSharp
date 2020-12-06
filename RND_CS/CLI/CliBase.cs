

namespace CLI
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Linq;
    using System.Runtime.CompilerServices;

    #region Enum
    public enum ResultCode
    {
        Ok = 200,
        Warning = 300,
        Error = 400
    }
    #endregion

    #region Interface
    public interface ICmdResult
    {
        string Stub { get; set; }
        ResultCode Code { get; set; }
        object Result { get; set; }
    }
    #endregion

    #region Abstract base
    public abstract class CliBase
    {
        public CliBase()
        {
            On = true;
        }
        public class CommandAttribute : Attribute
        {
            public string Cmd { get; set; }
            public string Description { get; set; }
        }

        private class CmdResult : ICmdResult
        {
            public CmdResult(ResultCode code, object data, string stub)
            {
                Code = code;
                Result = data;
                Stub = stub;
            }
            public ResultCode Code { get; set; }
            public object Result { get; set; }
            public string Stub { get; set; }
        }
        public bool On { get; set; }

        protected ICmdResult Ok(object r, [CallerMemberName] string caller = "") => new CmdResult(ResultCode.Ok, r, caller);

        protected ICmdResult Error(object r, [CallerMemberName] string caller = "") => new CmdResult(ResultCode.Error, r, caller);

        protected ICmdResult Warning(object r, [CallerMemberName] string caller = "") => new CmdResult(ResultCode.Warning, r, caller);

        public virtual Dictionary<string, MethodInfo> GetMethodMap()
        {
            Dictionary<string, MethodInfo> map = new Dictionary<string, MethodInfo>();
            foreach (var m in typeof(Engine).GetMethods())
            {
                var ca = m.GetCustomAttribute<CommandAttribute>();
                if (ca != null)
                {
                    map.Add(ca.Cmd, m);
                }
            }
            return map;
        }

        [Command(Cmd = "-help", Description = "Returns all commands available.")]
        public virtual ICmdResult Help(params object[] p)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var m in this.GetType().GetMethods())
            {
                var attr = m.GetCustomAttributes(true).OfType<CommandAttribute>().FirstOrDefault();
                if (attr != null)
                    sb.AppendLine($"{attr.Cmd}\t: {attr.Description}");
            }
            return Ok(sb.ToString());
        }

        [Command(Cmd = "-exit", Description = "Exits the application.")]
        public virtual ICmdResult Exit(params object[] p)
        {
            On = false;
            return Ok("Press any key to exit");
        }

        public virtual ICmdResult SafeExecute(Func<ICmdResult> func, [CallerMemberName] string caller = "")
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return Error(ex.Message, caller);
            }
        }
    }
    #endregion
}
