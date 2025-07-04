using ShowcaseServer.Models;

namespace ShowcaseServer.Interface
{
    public interface IMail
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }
}
