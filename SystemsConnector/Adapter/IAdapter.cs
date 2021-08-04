namespace SystemsConnector.Adapter
{
    /// <summary>
    /// Cadre les adapters
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAdapter<TEntity>
    {
        /// <summary>
        /// Méthode de fetch pour chaque adapter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(string id);

        /// <summary>
        /// Méthode de post pour chaque adapter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Create();
    }
}
