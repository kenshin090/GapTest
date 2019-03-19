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
    public class UserDao : IUserDao
    {
        /// <summary>
        /// Method to create a new User
        /// </summary>
        /// <param name="entity">the new User</param>
        /// <returns>persisted User</returns>
        public User Create(User entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    entity.CreatedDate = DateTime.Now;
                    context.User.Add(entity);
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
        /// Method to delete a User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    User persisted = context.User.FirstOrDefault(p => p.Id == id);
                    context.User.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific User
        /// </summary>
        /// <param name="Id">the id of the User</param>
        /// <returns>Persisted User</returns>
        public User Get(int id)
        {
            User User = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    User = context.User.Include("Permissions").Include("Permissions.Permissions").FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return User;
        }

        /// <summary>
        /// Method for search a Users list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of Users that match with the expression</returns>
        public List<User> Search(Expression<Func<User, bool>> expression, int page = 1, int size = 10)
        {
            List<User> Users = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    Users = context.User
                        .Include("Permissions")
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
            return Users;
        }

        /// <summary>
        /// Method for update a User
        /// </summary>
        /// <param name="id">the id of the User</param>
        /// <param name="entity">the entity User</param>
        /// <returns>the User persisted</returns>
        public User Update(int idEntity, User Entity)
        {
            User persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.User.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Email = Entity.Email;
                    persisted.Password = Entity.Password;

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