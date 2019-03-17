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
    /// The access to the policy client table
    /// </summary>
    public class PolicyClientDao : IPolicyClientDao
    {
        /// <summary>
        /// Method to create a new policy client
        /// </summary>
        /// <param name="entity">the new policy client</param>
        /// <returns>persisted policy client</returns>
        public PolicyClient Create(PolicyClient entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.PolicyClient.Add(entity);
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
        /// Method to delete a policy client
        /// </summary>
        /// <param name="id">policy client id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    PolicyClient persisted = context.PolicyClient.FirstOrDefault(p => p.Id == id);
                    context.PolicyClient.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific policy client
        /// </summary>
        /// <param name="Id">the id of the policy client</param>
        /// <returns>Persisted policy client</returns>
        public PolicyClient Get(int id)
        {
            PolicyClient policyClient = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policyClient = context.PolicyClient.Include("Client").Include("Policy").FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return policyClient;
        }

        /// <summary>
        /// Method for search a Policy Client list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of Policy Client  that match with the expression</returns>
        public List<PolicyClient> Search(Expression<Func<PolicyClient, bool>> expression, int page = 1, int size = 10)
        {
            List<PolicyClient> policyClientList = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policyClientList = context.PolicyClient
                        .Include("Client").Include("Policy")
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
            return policyClientList;
        }

        /// <summary>
        /// Method for update a policy client
        /// </summary>
        /// <param name="idEntity">the id of the policy client</param>
        /// <param name="entity">the entity policy client</param>
        /// <returns>the policy client persisted</returns>
        public PolicyClient Update(int idEntity, PolicyClient Entity)
        {
            PolicyClient persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.PolicyClient.FirstOrDefault(p => p.Id == idEntity);
                    persisted.ClientId = Entity.ClientId;
                    persisted.PolicyId = Entity.PolicyId;

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