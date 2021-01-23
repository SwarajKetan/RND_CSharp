using System;

namespace SecretBox
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Text;

    public class Engine : CliBase
    {
        
        private string db = "vault";
        private string key = "f3c61f4028dc4cb69b5f0aa99bec0bd7";
        private string valueSalt = "51a06d7d256d42ce987b634d5a54c4a7";

        private Dictionary<string, string> secrets = new Dictionary<string, string>();

        private string DbPath
        {
            get
            {
                return base.GetDbPath() + "\\" + db;
            }
        }
        public Engine()
            : base(new Algorithms.AesOperation())
        {
        }

        [Command(Cmd = "-setup", Description = "Setup one time")]
        public ICmdResult Setup(object[] args)
        {
            return SafeExecute(() =>
            {

                if (!File.Exists(DbPath))
                {
                    base.SetupMeta((string)args[0]);
                    return Ok("Setup completed. Please restart");
                }

                return Ok("Setup completed");
            });
        }

        [Command(Cmd = "-get", Description = "sbox -get\n\tsbox -get <accessor>\n\tsbox -get <accessor> -unlock <unlock code>")]
        public ICmdResult Get(object[] args)
        {
            return SafeExecute(() =>
            {
                if (!File.Exists(DbPath))
                {
                    return Setup(new string[] { Environment.CurrentDirectory });
                }

                bool plainTextMode = false;
                StringBuilder sb = new StringBuilder();
                
                var secs = DeserializeSecrets();
                foreach(var sec in secs)
                {
                    sb.AppendLine();
                    sb.AppendLine(sec.Accessor);
                    sb.AppendLine("----------------------------------------------------------------------------");
                    int padLen = sec.Contents.Max(x => x.Key.Length) + 5;
                    foreach(var c in sec.Contents)
                    {
                        string val = plainTextMode ? crypto.Decrypt(c.Value, valueSalt) : "*****************";
                        sb.AppendLine($"{c.Key.PadRight(padLen)}: { val}");
                    }
                }
                sb.AppendLine("----------------------------------------------------------------------------");
                return Ok(sb.ToString());
            });
        }

        [Command(Cmd = "-set", Description = "Sets a secret")]
        public ICmdResult Set(object[] args)
        {
            return SafeExecute(() =>
            {
                if (args.Length < 3) throw new Exception("Invalid args");

                //var secrets = new Dictionary<string, string>();
                string accessor = (string)args[args.Length - 1];
                // sbox -set facebook /website "www.facebook.com" /pwd "123" 

                var secrets = DeserializeSecrets().ToDictionary(x => x.Accessor, y => y);                
                Secret sec = secrets.ContainsKey(accessor) ? secrets[accessor] : new Secret() { Accessor = accessor };
                var contents = sec.Contents.ToDictionary(k => k.Key, v => v);

                object val = null;
                for (int j = 0; j < args.Length - 1; j++)
                {
                    string k = args[j].ToString();
                    if (k.Length > 0 && k[0] == '/')
                    {
                        if (!contents.ContainsKey(k))
                        {
                            contents.Add(k, null);
                        }

                        contents[k] = new Content
                        {
                            Key = k,
                            Value = crypto.Encrypt(Convert.ToString(val), valueSalt)
                        };
                        val = null;
                    }
                    else
                    {
                        val = args[j].ToString();
                    }
                }

                sec.Contents = contents.Values.ToList();

                List<Secret> secretObjects = secrets.Values.ToList();
                string serialized = JsonConvert.SerializeObject(secretObjects);
                string cipher = crypto.Encrypt(serialized, key);

                if(Save(cipher).Code == ResultCode.Ok)
                {
                    return Ok("Set completed");
                }
                return Ok("Failed to save changes.");
            });
        }

        //[Command(Cmd = "-save", Description = "Saves changes")]
        public ICmdResult Save(string content)
        {
            return SafeExecute(() =>
            {
                File.WriteAllText(DbPath, content);
                return Ok("Commit completed");
            });
        }

        private List<Secret> DeserializeSecrets()
        {
            string cipher = File.ReadAllText(DbPath);
            List<Secret> secrets = JsonConvert.DeserializeObject<List<Secret>>(crypto.Decrypt(cipher, key));
            return secrets;
        }

        private string SerializeSecrets(List<Secret> secrets)
        {
            var serialized = JsonConvert.SerializeObject(secrets);
            return serialized;
        }


        //private Secret ReadArgs(object[] args)
        //{
        //    // position 0 : 
        //}
    }
}
