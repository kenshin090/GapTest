namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to extend the behavior of repository
    /// </summary>
    /// <typeparam name="T">the entity type</typeparam>
    public interface IRepository<T> : ICreable<T>,
                                      IUpdateable<T>,
                                      ISearcheable<T>,
                                      IObtainable<T>,
                                      IDeleteable
    {
    }
}