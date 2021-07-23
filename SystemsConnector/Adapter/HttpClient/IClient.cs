using System.Net.Http;
using System.Threading.Tasks;

namespace SystemsConnector.Adapter.HttpClient
{
    /// <summary>
    /// Cadre la création d'un client
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    interface IClient<TEntity>
    {
        /// <summary>
        /// Récupère de la donnée depuis un système
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Get(string id);

        /// <summary>
        /// Envoi de la donnée vers un système
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Post(TEntity entity);
    }
}
