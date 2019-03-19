using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using GapCommon.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapBll.Bll
{
    public class UserTokens : IUserTokens
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table User</param>
        public UserTokens(IUserTokenDao module)
        {
            this.Module = module;
        }

        public IUserTokenDao Module { get; set; }

        /// <summary>
        /// Method to create a new UserToken
        /// </summary>
        /// <param name="entity">the new UserToken</param>
        /// <returns>persisted UserToken</returns>
        public UserToken Create(UserToken entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a UserToken
        /// </summary>
        /// <param name="id">UserToken id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific UserToken
        /// </summary>
        /// <param name="Id">the id of the UserToken</param>
        /// <returns>Persisted UserToken</returns>
        public UserToken Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a UserTokens list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of UserTokens that match with the expression</returns>
        public List<UserToken> Search(Expression<Func<UserToken, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a UserToken
        /// </summary>
        /// <param name="id">the id of the UserToken</param>
        /// <param name="entity">the entity UserToken</param>
        /// <returns>the UserToken persisted</returns>
        public UserToken Update(int idEntity, UserToken Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}