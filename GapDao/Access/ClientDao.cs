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
    /// <summary>
    /// The access to the client table
    /// </summary>
    public class ClientDao : IClientDao
    {
        /// <summary>
        /// Method to create a new client
        /// </summary>
        /// <param name="entity">the new client</param>
        /// <returns>persisted client</returns>
        public Client Create(Client entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.Client.Add(entity);
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
        /// Method to delete a client
        /// </summary>
        /// <param name="id">client id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    Client persisted = context.Client.FirstOrDefault(p => p.Id == id);
                    context.Client.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific client
        /// </summary>
        /// <param name="Id">the id of the client</param>
        /// <returns>Persisted client</returns>
        public Client Get(int id)
        {
            Client client = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    client = context.Client.Include("Policies").Include("Policies.Policy").FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }

        /// <summary>
        /// Method for search a clients list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of clients that match with the expression</returns>
        public List<Client> Search(Expression<Func<Client, bool>> expression, int page = 1, int size = 10)
        {
            List<Client> clients = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    clients = context.Client
                        .Include("Policies")
                        .Include("Policies.Policy")
                        .Include("Policies.Policy.Coverages")
                        .Include("Policies.Policy.Coverages.CoverageType")
                        .Include("Policies.Policy.RiskType")
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
            return clients;
        }

        /// <summary>
        /// Method for update a client
        /// </summary>
        /// <param name="id">the id of the client</param>
        /// <param name="entity">the entity client</param>
        /// <returns>the client persisted</returns>
        public Client Update(int idEntity, Client Entity)
        {
            Client persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.Client.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Address = Entity.Address;
                    persisted.Email = Entity.Email;
                    persisted.LastName = Entity.LastName;
                    persisted.Name = Entity.Name;
                    persisted.NUIP = Entity.NUIP;
                    persisted.Phone = Entity.Phone;
                    persisted.Policies = Entity.Policies;

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