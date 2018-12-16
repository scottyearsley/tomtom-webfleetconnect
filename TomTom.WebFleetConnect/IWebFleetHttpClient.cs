using System.Threading.Tasks;

namespace TomTom.WebFleetConnect
{
    public interface IWebFleetHttpClient
    {
        Task<T> Get<T>(string action, object parameters);
    }
}