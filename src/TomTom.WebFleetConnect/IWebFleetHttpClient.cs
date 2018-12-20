using System.Threading.Tasks;
using TomTom.WebFleetConnect.Models;

namespace TomTom.WebFleetConnect
{
    public interface IWebFleetHttpClient
    {
        Task<T> Get<T>(string action, ApiParameters parameters = null);
    }
}