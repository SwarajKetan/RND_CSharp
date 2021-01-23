using System;
using System.Collections.Generic;
using System.Text;

namespace SecretBox
{
    public interface ICrypto
    {
        string Encrypt(string text, string key = "");
        string Decrypt(string cipher, string key = "");
    }
}
