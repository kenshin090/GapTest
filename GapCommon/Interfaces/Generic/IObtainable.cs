using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Interfaces.Generic
{
    /// <summary>
    /// Interface to expand behavior get
    /// </summary>
    /// <typeparam name="T">the entity type</typeparam>
    public interface IObtainable<T>
    {
        /// <summary>
        /// Method to get an entity
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>persisted entity</returns>
        T Get(int id);
    }
}