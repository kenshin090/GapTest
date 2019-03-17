namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to expand behavior delete
    /// </summary>
    public interface IDeleteable
    {
        /// <summary>
        /// Method to delete a entity
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <returns>rows afected</returns>
        int Delete(int id);
    }
}