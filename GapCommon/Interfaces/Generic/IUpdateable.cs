using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to expand behavior update
    /// </summary>
    /// <typeparam name="T">the type to inherit</typeparam>
    public interface IUpdateable<T>
    {
        /// <summary>
        /// Method to update a entity
        /// </summary>
        /// <param name="idEntity">id of the entity</param>
        /// <param name="Entity">entity updated</param>
        /// <returns>persisted entity</returns>
        T Update(int idEntity, T Entity);
    }
}