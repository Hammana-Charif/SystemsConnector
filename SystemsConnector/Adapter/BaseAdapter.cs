namespace SystemsConnector.Adapter
{
    /// <summary>
    /// Défini le comportement et les méthodes d'un adapter via l'héritage
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseAdapter<TEntity> : IAdapter<TEntity>
    {
        /// <summary>
        /// Fetch un objet depuis une datasource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        abstract public TEntity Get(string id);

        /// <summary>
        /// Post un objet vers une datasource
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        abstract public TEntity Create();
    }
}
