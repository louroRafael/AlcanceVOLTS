namespace AlcanceVOLTS.Domain.Infra.Settings
{
    public class AppSettings
    {
        public TokenSettings TokenSettings { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public string Url { get; set; }
    }
}
