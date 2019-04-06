using Binodata.EF.Repo.DataAccess;
using Binodata.EF.Repo.UnitOfWork;
using Holiday.Business.DataAccess;
using Holiday.Business.DataValue;
using Holiday.Business.UseCases;
using Holiday.DB.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HolidayTest
{
    [TestClass]
    public class HolidayMaintenanTest
    {
        [TestMethod]
        public void Test_Holiday_Update_From_Url()
        {
            string url = "http://data.ntpc.gov.tw/api/v1/rest/datastore/382000000A-000077-002";

            ISourceGraber<SourceHoliday> sourceGraber = new HttpSourceGraber<SourceHoliday>(url);
            IUnitOfWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<HolidayEntities>();

            IGenericDataAccess<TWHoliday> dataAccess = new GenericDataAccess<TWHoliday>(unitOfWork);
            HolidayMaintainer maintanier = new HolidayMaintainer(sourceGraber, dataAccess);
            var source = maintanier.AddHolidayFromSource();

            Assert.AreEqual(true, source);
        }

        [TestMethod]
        public void Test_Holiday_Update_From_File()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Source/Holiday.json");

            ISourceGraber<SourceHoliday> sourceGraber = new FileSourceGraber<SourceHoliday>(filePath);

            IUnitOfWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<HolidayEntities>();

            IGenericDataAccess<TWHoliday> dataAccess = new GenericDataAccess<TWHoliday>(unitOfWork);
            HolidayMaintainer maintanier = new HolidayMaintainer(sourceGraber, dataAccess);
            var source = maintanier.AddHolidayFromSource();

            Assert.AreEqual(true, source);
        }
    }
}