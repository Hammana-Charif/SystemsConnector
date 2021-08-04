using System.Net.Http;
using System.Threading.Tasks;

namespace SystemsConnector.Adapter.HttpClient
{
    /// <summary>
    /// Défini le comportement et les méthodes d'un client via l'héritage
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseClient<TEntity> : IClient<TEntity>
    {
        private readonly string _baseUrl;
        private readonly string _token;

        protected string BaseUrl
        {
            get => _baseUrl;
        }

        protected string Token
        {
            get => _token;
        }

        /// <summary>
        /// Surcharge du constructeur qui permet de renseigner la base url et l'endpoint à l'instanciation d'un client
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="endPoint"></param>
        protected BaseClient(string baseUrl, string endPoint)
        {
            _baseUrl = baseUrl;
            _token = endPoint;
        }

        /// <summary>
        /// Surcharge du constructeur qui permet de renseigner seulement la base url
        /// </summary>
        /// <param name="baseUrl"></param>
        protected BaseClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Fetch un objet depuis une datasource
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        abstract public Task<HttpResponseMessage> Get(string id);

        /// <summary>
        /// Post un objet vers une datasource
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        abstract public Task<HttpResponseMessage> Post(TEntity entity);
    }
}
