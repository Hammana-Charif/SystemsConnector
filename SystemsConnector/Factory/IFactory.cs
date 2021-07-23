using SystemsConnector.Adapter;
using SystemsConnector.Model;

namespace SystemsConnector.Factory
{
    /// <summary>
    /// Cadre la création d'une fabrique
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    interface IFactory<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Méthode à implémenter dans chaque fabrique
        /// </summary>
        /// <param name="systemType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        IAdapter<TEntity> Fabricate(SystemType systemType);
    }
}
