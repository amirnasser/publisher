namespace Publisher
{
    using System.Collections.Generic;

    public partial class FrmPublisher
    {
        public class Data
        {
            public string Message { get; set; }
            public List<string> Files { get; set; }
            public string Lastfile { get; set; }
        }
    }
}