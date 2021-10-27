namespace Publisher
{
    public partial class FrmPublisher
    {
        public class DeploymentFile
        {
            public string Name { get; set; }
            public string ApiKey { get; set; }
            public string URL { get; set; }
            public string Path { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}