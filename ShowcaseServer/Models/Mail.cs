using ShowcaseServer.Interface;
using System.Runtime.CompilerServices;

namespace ShowcaseServer.Models
{
    public class Mail : IMail
    {
        public Header Header { get; set; }
        public Body Body { get; set; }

        public Mail(Header header, Body body) 
        {
            Header = header;
            Body = body;
        }

    }
}
