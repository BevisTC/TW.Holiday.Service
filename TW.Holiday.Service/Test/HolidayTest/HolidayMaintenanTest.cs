using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Holiday.Business.UseCases;

namespace HolidayTest
{
    [TestClass]
    public class HolidayMaintenanTest
    {
        [TestMethod]
        public void Test_Holiday_Update_From_Url()
        {
            string url = "http://data.ntpc.gov.tw/api/v1/rest/datastore/382000000A-000077-002";

            HolidayMaintainer maintanier = new HolidayMaintainer();
             maintanier.AddHolidayFromUrl();

        }
    }
}
