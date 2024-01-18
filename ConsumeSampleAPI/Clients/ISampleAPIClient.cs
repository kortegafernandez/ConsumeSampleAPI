namespace ConsumeSampleAPI.Clients
{
    public interface ISampleAPIClient
    {
        Task<IEnumerable<string>> GetUniqueTopicsAsync();
    }
}
