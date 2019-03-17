namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to expand behavior create
    /// </summary>
    /// <typeparam name="T">the type to expand</typeparam>
    public interface ICreable<T>
    {
        /// <summary>
        /// Method to create a new entity
        /// </summary>
        /// <param name="entity">the entity</param>
        /// <returns>Persisted entity</returns>
        T Create(T entity);
    }
}