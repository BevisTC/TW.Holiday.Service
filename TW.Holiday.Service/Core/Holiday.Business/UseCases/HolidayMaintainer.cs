using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binodata.EF.Repo.DataAccess;
using Holiday.Business.DataAccess;
using Holiday.DB.EF;
using Holiday.Business.DataValue;

namespace Holiday.Business.UseCases
{
    public class HolidayMaintainer
    {
        private IGenericDataAccess<TWHoliday> dataAccess;
        private ISourceGraber<SourceHoliday> sourceGraber;


        public HolidayMaintainer(ISourceGraber<SourceHoliday> sourceGraber, IGenericDataAccess<TWHoliday> dataAccess)
        {
            this.sourceGraber = sourceGraber;
            this.dataAccess = dataAccess;
        }

        public HolidayMaintainer(IGenericDataAccess<TWHoliday> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public bool CheckDateIsHoliday(DateTime time)
        {
            TWHoliday twHoliday = GetHolidyDataByTime(time);

            if (twHoliday == null)
            {
                return false;
            }
            else
            {
                return twHoliday.IsHoliday;
            }

        }

        private TWHoliday GetHolidyDataByTime(DateTime time)
        {
            return this.dataAccess.QueryByCondition(x => x.Year == time.Year && x.Month == time.Month && x.Day == time.Day).FirstOrDefault();
        }

        public bool AddHolidayFromSource()
        {
            SourceHoliday source = this.sourceGraber.GetSource();

            foreach (var item in source.Result.HolidayRecords)
            {
                DateTime time = Convert.ToDateTime(item.DateStr);

                TWHoliday twHoliday = GetHolidyDataByTime(time);

                if (twHoliday == null)
                {
                    TWHoliday holiday = new TWHoliday();
                    holiday.Description = item.Description;
                    holiday.IsHoliday = item.IsHoliday.Equals("是") ? true : false;
                    holiday.Category = item.HolidayCategory;
                    holiday.Year = time.Year;
                    holiday.Month = time.Month;
                    holiday.Day = time.Day;
                    this.dataAccess.Add(holiday);
                }

            }
            return true;

        }
    }
}
