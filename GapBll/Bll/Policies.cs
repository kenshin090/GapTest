using GapCommon.Entities;
using GapCommon.Enum;
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
    public class Policies : IPolicies
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table PoliciesCoverages</param>
        public Policies(IPolicyDao module)
        {
            this.Module = module;
        }

        private IPolicyDao Module { get; set; }

        /// <summary>
        /// Method to create a new policy
        /// </summary>
        /// <param name="entity">the new policy</param>
        /// <returns>persisted policy</returns>
        public Policy Create(Policy entity)
        {
            ValidateCoverages(entity);
            ValidateRiskType(entity);
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a policy
        /// </summary>
        /// <param name="id">policy id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method to return a persisted policy
        /// </summary>
        /// <param name="id">policy id</param>
        /// <returns>persisted policy</returns>
        public Policy Get(int id)
        {
            return Module.Get(id);
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
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method to update a policy
        /// </summary>
        /// <param name="idEntity">policy id</param>
        /// <param name="Entity">policy updated</param>
        /// <returns>persited policy</returns>
        public Policy Update(int idEntity, Policy Entity)
        {
            return Module.Update(idEntity, Entity);
        }

        /// <summary>
        /// method to validate if a policy have coverates
        /// </summary>
        /// <param name="entity"></param>
        private void ValidateCoverages(Policy entity)
        {
            if (entity.Coverages == null || !entity.Coverages.Any())
            {
                throw new MessageException() { Code = 400, TextMessage = "The policy haven't coverages" };
            }
        }

        /// <summary>
        /// Method to validate the risk type
        /// </summary>
        /// <param name="entity"></param>
        private void ValidateRiskType(Policy entity)
        {
            if (entity.RiskTypeId == (int)RiskTypeEnum.High)
            {
                entity.Coverages.ForEach(cv =>
                {
                    if (cv.Percentage > 5)
                    {
                        throw new MessageException() { Code = 400, TextMessage = "The policy have the a coverage with a percentage higher that 5 and the risk type is high " };
                    }
                }
                );
            }
        }
    }
}