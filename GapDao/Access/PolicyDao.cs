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
    /// The access to the policy table
    /// </summary>
    public class PolicyDao : IPolicyDao
    {
        /// <summary>
        /// Method to create a new policy
        /// </summary>
        /// <param name="entity">the new policy</param>
        /// <returns>persisted policy</returns>
        public Policy Create(Policy entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.Policy.Add(entity);
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
        /// Method to delete a
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    Policy persisted = context.Policy.FirstOrDefault(p => p.Id == id);
                    context.Policy.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific policy
        /// </summary>
        /// <param name="Id">the id of the policy</param>
        /// <returns>Persisted policy</returns>
        public Policy Get(int id)
        {
            Policy policy = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policy = context.Policy.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return policy;
        }

        /// <summary>
        /// Method for search a policies list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of policies that match with the expression</returns>
        public List<Policy> Search(Expression<Func<Policy, bool>> expression, int page = 1, int size = 10)
        {
            List<Policy> policies = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policies = context.Policy
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
            return policies;
        }

        /// <summary>
        /// Method for update a policy
        /// </summary>
        /// <param name="id">the id of the policy</param>
        /// <param name="entity">the entity policy</param>
        /// <returns>the entity persisted</returns>
        public Policy Update(int idEntity, Policy Entity)
        {
            Policy persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.Policy.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Name = Entity.Name;
                    persisted.Price = Entity.Price;
                    persisted.RiskTypeId = Entity.RiskTypeId;
                    persisted.CoveragePeriod = Entity.CoveragePeriod;
                    persisted.Coverages = Entity.Coverages;
                    persisted.Description = Entity.Description;

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