using Binodata.EF.Repo.DataAccess;
using Binodata.EF.Repo.UnitOfWork;
using Holiday.Business.DataAccess;
using Holiday.Business.DataValue;
using Holiday.Business.UseCases;
using Holiday.DB.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.Holiday.Update.Batch
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start update holiday");

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Source/Holiday.json");

            ISourceGraber<SourceHoliday> sourceGraber = new FileSourceGraber<SourceHoliday>(filePath);

            IUnitOfWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<HolidayEntities>();

            IGenericDataAccess<TWHoliday> dataAccess = new GenericDataAccess<TWHoliday>(unitOfWork);
            HolidayMaintainer maintanier = new HolidayMaintainer(sourceGraber, dataAccess);
            var source = maintanier.AddHolidayFromSource();

            if (source) {
                Console.WriteLine("Update Holiday success");
            }

            Console.WriteLine("Update Holiday fail");

        }
    }
}
