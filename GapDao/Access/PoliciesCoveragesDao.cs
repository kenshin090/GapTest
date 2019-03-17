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
    /// The access to the policies coverage type table
    /// </summary>
    public class PoliciesCoveragesDao : IPoliciesCoveragesDao
    {
        /// <summary>
        /// Method to create a new policy coverage
        /// </summary>
        /// <param name="entity">the new policy coverage</param>
        /// <returns>persisted policy coverage</returns>
        public PoliciesCoverages Create(PoliciesCoverages entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.PoliciesCoverages.Add(entity);
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
        /// Method to delete a policy coverage
        /// </summary>
        /// <param name="id">policy coverage id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    PoliciesCoverages persisted = context.PoliciesCoverages.FirstOrDefault(p => p.Id == id);
                    context.PoliciesCoverages.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific policies coverages
        /// </summary>
        /// <param name="Id">the id of the policies coverages</param>
        /// <returns>Persisted policies coverages</returns>
        public PoliciesCoverages Get(int id)
        {
            PoliciesCoverages policiesCoverages = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policiesCoverages = context.PoliciesCoverages.Include("CoverageType").FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return policiesCoverages;
        }

        /// <summary>
        /// Method for search a policies coverages list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of policies coverages that match with the expression</returns>

        public List<PoliciesCoverages> Search(Expression<Func<PoliciesCoverages, bool>> expression, int page = 1, int size = 10)
        {
            List<PoliciesCoverages> policiesCoverages = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    policiesCoverages = context.PoliciesCoverages
                        .Include("CoverageType")
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
            return policiesCoverages;
        }

        /// <summary>
        /// Method for update a policy coverage
        /// </summary>
        /// <param name="id">the id of the policy coverage</param>
        /// <param name="entity">the entity policy coverage</param>
        /// <returns>the policy coverage persisted</returns>
        public PoliciesCoverages Update(int idEntity, PoliciesCoverages Entity)
        {
            PoliciesCoverages persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.PoliciesCoverages.FirstOrDefault(p => p.Id == idEntity);
                    persisted.CoverageTypeId = Entity.CoverageTypeId;
                    persisted.Percentage = Entity.Percentage;
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