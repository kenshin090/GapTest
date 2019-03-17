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
    /// The access to the coverage type table
    /// </summary>
    public class CoverageTypeDao : ICoverageTypeDao
    {
        /// <summary>
        /// Method to create a new coverage type
        /// </summary>
        /// <param name="entity">the new coverage type</param>
        /// <returns>persisted coverage type</returns>
        public CoverageType Create(CoverageType entity)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    context.CoverageType.Add(entity);
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
        /// Method to delete a coverage type
        /// </summary>
        /// <param name="id">coverage type id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            try
            {
                using (GapContext context = new GapContext())
                {
                    CoverageType persisted = context.CoverageType.FirstOrDefault(p => p.Id == id);
                    context.CoverageType.Remove(persisted);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for return a specific coverage type
        /// </summary>
        /// <param name="Id">the id of the coverage type</param>
        /// <returns>Persisted coverage type</returns>
        public CoverageType Get(int id)
        {
            CoverageType coverageType = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    coverageType = context.CoverageType.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coverageType;
        }

        /// <summary>
        /// Method for search a coverage types list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of coverage types that match with the expression</returns>
        public List<CoverageType> Search(Expression<Func<CoverageType, bool>> expression, int page = 1, int size = 10)
        {
            List<CoverageType> coverageTypes = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    coverageTypes = context.CoverageType
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
            return coverageTypes;
        }

        /// <summary>
        /// Method for update a coverage type
        /// </summary>
        /// <param name="id">the id of the coverage type</param>
        /// <param name="entity">the entity coverage type</param>
        /// <returns>the coverage type persisted</returns>
        public CoverageType Update(int idEntity, CoverageType Entity)
        {
            CoverageType persisted = null;
            try
            {
                using (GapContext context = new GapContext())
                {
                    persisted = context.CoverageType.FirstOrDefault(p => p.Id == idEntity);
                    persisted.Coverage = Entity.Coverage;

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