using GapCommon.Entities;
using GapCommon.Interfaces.Dao;
using GapDao.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GapDao.Access
{
    /// <summary>
    /// The access to the risk type table
    /// </summary>
    public class RiskTypeDao : IRiskTypeDao
    {
        /// <summary>
        /// Method to create a new risk type
        /// </summary>
        /// <param name="entity">the new risk type</param>
        /// <returns>persisted risk type</returns>
        public RiskType Create(RiskType entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.RiskType.Add(entity);
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
        /// Method to delete a risk type
        /// </summary>
        /// <param name="id">risk type id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    RiskType persisted = context.RiskType.FirstOrDefault(p => p.Id == id);
                    context.RiskType.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific risk type
        /// </summary>
        /// <param name="Id">the id of the risk type</param>
        /// <returns>Persisted risk type</returns>
        public RiskType Get(int id)
        {
            RiskType riskType = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    riskType = context.RiskType.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return riskType;
        }

        /// <summary>
        /// Method for search a risk type list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of risk type that match with the expression</returns>
        public List<RiskType> Search(Expression<Func<RiskType, bool>> expression, int page = 1, int size = 10)
        {
            List<RiskType> RiskTypes = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    RiskTypes = context.RiskType
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
            return RiskTypes;
        }

        /// <summary>
        /// Method for update a risk type
        /// </summary>
        /// <param name="id">the id of the risk type</param>
        /// <param name="entity">the entity risk type</param>
        /// <returns>the risk type persisted</returns>
        public RiskType Update(int idEntity, RiskType Entity)
        {
            RiskType persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.RiskType.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Name = Entity.Name;

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