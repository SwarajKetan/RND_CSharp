using System;
using System.Collections.Generic;
using System.Text;

namespace SecretBox
{
    public class Secret
    {
        public Secret()
        {
            Contents = new List<Content>();
        }
        public string Accessor { get; set; } // facebook.com        
        public List<Content> Contents { get; set; }

    }
}
