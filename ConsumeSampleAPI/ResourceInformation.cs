namespace ConsumeSampleAPI.Resource
{
    public class ResourceInformation
    {
        public int id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string[] types { get; set; }
        public string[] topics { get; set; }
        public string[] levels { get; set; }
    }
}
