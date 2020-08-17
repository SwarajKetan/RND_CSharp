using System;

namespace TinyRunner
{
    public sealed class InfoAttribute : Attribute
    {
        public InfoAttribute()
        {

        }

        public InfoAttribute(params string[] tags)
        {
            HashTags = tags;
        }
        public string Comment { get; set; }
        public string ProblemLink { get; set; }
        public string[] HashTags { get; set; }
    }
}
