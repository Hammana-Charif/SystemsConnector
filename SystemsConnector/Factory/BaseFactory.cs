﻿using SystemsConnector.Adapter;
using SystemsConnector.Model;

namespace SystemsConnector.Factory
{
    /// <summary>
    /// Défini l'entité sur laquelle est créé l'adapter et implémente les méthodes requises
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    abstract class BaseFactory<TEntity> : IFactory<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Renvoi un adapter en fonction du SystemType
        /// </summary>
        /// <param name="systemType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        abstract public IAdapter<TEntity> Fabricate(SystemType systemType);
    }
}
