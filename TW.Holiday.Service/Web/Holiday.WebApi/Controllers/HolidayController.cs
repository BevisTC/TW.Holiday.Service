using Binodata.EF.Repo.DataAccess;
using Binodata.EF.Repo.UnitOfWork;
using Binodata.Utility.Component.AdapterModel;
using Holiday.Business.DataAccess;
using Holiday.Business.DataValue;
using Holiday.Business.UseCases;
using Holiday.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Holiday.WebApi.Controllers
{
    public class HolidayController : ApiController
    {
        [HttpPost]
        [Route("api/Holiday/CheckDateisHoliday")]
        public IHttpActionResult CheckDateIsHoliday([FromBody]DateModel  value)
        {
            DateTime time = value.Time;
            IUnitOfWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<HolidayEntities>();

            IGenericDataAccess<TWHoliday> dataAccess = new GenericDataAccess<TWHoliday>(unitOfWork);
            HolidayMaintainer maintanier = new HolidayMaintainer(dataAccess);
            bool result =  maintanier.CheckDateIsHoliday(time);
            var resp =  new RespModel() { IsHoliday = result};

            return Json(resp);
        }
    }

    public class DateModel
    {
        public DateTime  Time { get; set; }
    }

    public class RespModel {

        public bool IsHoliday { get; set; }
    }
}
