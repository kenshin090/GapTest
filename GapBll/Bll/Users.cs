using GapCommon.Entities;
using GapCommon.Exceptions;
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
    public class Users : IUsers
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table User</param>
        public Users(IUserDao module, IUserTokenDao tokenModule)
        {
            this.Module = module;
            this.TokenModule = tokenModule;
        }

        public IUserDao Module { get; set; }
        public IUserTokenDao TokenModule { get; set; }

        /// <summary>
        /// Method to create a new User
        /// </summary>
        /// <param name="entity">the new User</param>
        /// <returns>persisted User</returns>
        public User Create(User entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific User
        /// </summary>
        /// <param name="Id">the id of the User</param>
        /// <returns>Persisted User</returns>
        public User Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method to logIn a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserToken LogIn(User user)
        {
            Expression<Func<User, bool>> expression = (usr => usr.Password == user.Password && usr.Email == user.Email);
            User persisted = this.Search(expression).FirstOrDefault();
            if (persisted != null)
            {
                Expression<Func<UserToken, bool>> expressionToken = (usrT => usrT.UserId == persisted.Id && usrT.ExpirationDate > DateTime.Now);
                List<UserToken> tokens = TokenModule.Search(expressionToken, 1, int.MaxValue);
                if (tokens != null && tokens.Any())
                {
                    return tokens.First();
                }
                else
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(persisted.Email + DateTime.Now.Ticks.ToString());
                    string token = System.Convert.ToBase64String(plainTextBytes);
                    return TokenModule.Create(new UserToken() { UserId = persisted.Id, ExpirationDate = DateTime.Now.AddDays(1), Token = token });
                }
            }
            else
            {
                throw new MessageException() { Code = -1, TextMessage = "Invalid user or password" };
            }
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
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a User
        /// </summary>
        /// <param name="id">the id of the User</param>
        /// <param name="entity">the entity User</param>
        /// <returns>the User persisted</returns>
        public User Update(int idEntity, User Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}