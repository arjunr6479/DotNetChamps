namespace WebApplication1.Repositories
{
    public interface IDemoRepository
    {
        public Task<string> GetApiData(string endpointUrl, string token);
        public Task<string> PostApiData(string endpointUrl, string token, string jsonData);

    }
}
