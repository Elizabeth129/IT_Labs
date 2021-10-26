using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_IT_API.Models
{
    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
        public Link() { }
        public Link(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }
    }

    public class LinkResourceBase
    {
        public LinkResourceBase()
        {
        }
        public List<Link> Links { get; set; } = new List<Link>();
    }
    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        public List<T> Value { get; set; } = new List<T>();
        public LinkCollectionWrapper()
        {
        }
        public LinkCollectionWrapper(List<T> value)
        {
            Value = value;
        }
    }
}
