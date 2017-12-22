namespace Pdc.Net.Service.Client
{
    public interface IClientProvider
    {
        object GetClient();

        object GetClient(string configurationName);
    }
}