using System;
using System.Collections.Generic;
using GapCommon.Entities;
using GapCommon.Exceptions;
using GapCommon.Interfaces.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GapUnitTest.Policies
{
    [TestClass]
    public class PoliciesUnitTest
    {
        [TestMethod]
        public void CreatePolicy()
        {
            ///Arange
            var mockPolicy = new Mock<IPolicyDao>();

            List<PoliciesCoverages> coverages = new List<PoliciesCoverages>();

            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 1, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 2, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 3, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 4, Percentage = 7 });

            Policy entity = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 1,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coverages
            };

            List<PoliciesCoverages> coveragesPersisted = new List<PoliciesCoverages>();

            coveragesPersisted.Add(new PoliciesCoverages() { Id = 1, CoverageTypeId = 1, Percentage = 7 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 2, CoverageTypeId = 2, Percentage = 7 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 3, CoverageTypeId = 3, Percentage = 7 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 4, CoverageTypeId = 4, Percentage = 7 });

            Policy entityPersisted = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 1,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coveragesPersisted,
                Id = 1
            };

            mockPolicy.Setup(fnl => fnl.Create(entity)).Returns(entityPersisted);

            GapBll.Bll.Policies policies = new GapBll.Bll.Policies(mockPolicy.Object);

            ///Act
            var policiesResult = policies.Create(entity);

            ///Assert
            Assert.AreEqual(1, policiesResult.Id);
            Assert.AreEqual(4, policiesResult.Coverages.Count);
            Assert.AreEqual(entity.Name, policiesResult.Name);
            Assert.AreEqual(entity.Description, policiesResult.Description);
            Assert.AreEqual(entity.Price, policiesResult.Price);
        }

        [TestMethod]
        public void CreatePolicyHighRiskLessThanFive()
        {
            ///Arange
            var mockPolicy = new Mock<IPolicyDao>();

            List<PoliciesCoverages> coverages = new List<PoliciesCoverages>();

            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 1, Percentage = 5 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 2, Percentage = 4 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 3, Percentage = 3 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 4, Percentage = 2 });

            Policy entity = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 4,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coverages
            };

            List<PoliciesCoverages> coveragesPersisted = new List<PoliciesCoverages>();

            coveragesPersisted.Add(new PoliciesCoverages() { Id = 1, CoverageTypeId = 1, Percentage = 5 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 2, CoverageTypeId = 2, Percentage = 4 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 3, CoverageTypeId = 3, Percentage = 3 });
            coveragesPersisted.Add(new PoliciesCoverages() { Id = 4, CoverageTypeId = 4, Percentage = 2 });

            Policy entityPersisted = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 1,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coveragesPersisted,
                Id = 1
            };

            mockPolicy.Setup(fnl => fnl.Create(entity)).Returns(entityPersisted);

            GapBll.Bll.Policies policies = new GapBll.Bll.Policies(mockPolicy.Object);

            ///Act
            var policiesResult = policies.Create(entity);

            ///Assert
            Assert.AreEqual(1, policiesResult.Id);
            Assert.AreEqual(4, policiesResult.Coverages.Count);
            Assert.AreEqual(entity.Name, policiesResult.Name);
            Assert.AreEqual(entity.Description, policiesResult.Description);
            Assert.AreEqual(entity.Price, policiesResult.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(MessageException), "The policy accept high percentages")]
        public void CreatePolicyHighRiskMoreThanFive()
        {
            ///Arange
            var mockPolicy = new Mock<IPolicyDao>();

            List<PoliciesCoverages> coverages = new List<PoliciesCoverages>();

            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 1, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 2, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 3, Percentage = 7 });
            coverages.Add(new PoliciesCoverages() { CoverageTypeId = 4, Percentage = 7 });

            Policy entity = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 4,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coverages
            };

            mockPolicy.Setup(fnl => fnl.Create(entity)).Returns(((Policy)null));

            GapBll.Bll.Policies policies = new GapBll.Bll.Policies(mockPolicy.Object);

            ///Act
            var policiesResult = policies.Create(entity);
        }

        [TestMethod]
        [ExpectedException(typeof(MessageException), "The policy accept high percentages")]
        public void CreatePolicyWithOutCoverages()
        {
            ///Arange
            var mockPolicy = new Mock<IPolicyDao>();

            List<PoliciesCoverages> coverages = new List<PoliciesCoverages>();

            Policy entity = new Policy()
            {
                Name = "Todo riesgo",
                Description = "Esta es una poliza todo riesgo",
                Price = 1000000,
                RiskTypeId = 4,
                CoveragePeriod = 24,
                StartDatePolicy = DateTime.Now,
                Coverages = coverages
            };

            mockPolicy.Setup(fnl => fnl.Create(entity)).Returns(((Policy)null));

            GapBll.Bll.Policies policies = new GapBll.Bll.Policies(mockPolicy.Object);

            ///Act
            var policiesResult = policies.Create(entity);
        }
    }
}