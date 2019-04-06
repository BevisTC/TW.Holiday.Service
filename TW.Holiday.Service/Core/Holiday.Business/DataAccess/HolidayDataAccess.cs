using Binodata.EF.Repo;
using Binodata.EF.Repo.DataAccess;
using Binodata.EF.Repo.UnitOfWork;
using Holiday.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.Business.DataAccess
{
    public class HolidayDataAccess
    {
        public void Add(TWHoliday holiday)
        {
            IUnitOfWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<HolidayEntities>();
            IGenericDataAccess<TWHoliday> dataAccess = new GenericDataAccess<TWHoliday>(unitOfWork);

            dataAccess.Add(holiday);



        }
    }
}
