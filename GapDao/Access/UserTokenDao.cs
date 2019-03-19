using GapCommon.Entities;
using GapCommon.Interfaces.Dao;
using GapDao.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapDao.Access
{
    public class UserTokenDao : IUserTokenDao
    {
        /// <summary>
        /// Method to create a new UserToken
        /// </summary>
        /// <param name="entity">the new UserToken</param>
        /// <returns>persisted UserToken</returns>
        public UserToken Create(UserToken entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.UserToken.Add(entity);
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to delete a UserToken
        /// </summary>
        /// <param name="id">UserToken id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    UserToken persisted = context.UserToken.FirstOrDefault(p => p.Id == id);
                    context.UserToken.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific UserToken
        /// </summary>
        /// <param name="Id">the id of the UserToken</param>
        /// <returns>Persisted UserToken</returns>
        public UserToken Get(int id)
        {
            UserToken UserToken = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    UserToken = context.UserToken.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserToken;
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
            List<UserToken> UserTokens = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    UserTokens = context.UserToken
                        .Where(expression)
                        .OrderBy(sl => sl.Id)
                        .Take(size)
                        .Skip((page - 1) * size)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserTokens;
        }

        /// <summary>
        /// Method for update a UserToken
        /// </summary>
        /// <param name="id">the id of the UserToken</param>
        /// <param name="entity">the entity UserToken</param>
        /// <returns>the UserToken persisted</returns>
        public UserToken Update(int idEntity, UserToken Entity)
        {
            UserToken persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.UserToken.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Token = Entity.Token;
                    persisted.ExpirationDate = Entity.ExpirationDate;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return persisted;
        }
    }
}