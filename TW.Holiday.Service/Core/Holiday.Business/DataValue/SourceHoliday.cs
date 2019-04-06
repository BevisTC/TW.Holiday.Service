using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.Business.DataValue
{
    public class SourceHoliday
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonProperty(PropertyName = "resource_id")]
        public string ResourceId { get; set; }

        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public List<HolidayField> HolidayFields { get; set; }

        [JsonProperty(PropertyName = "records")]
        public List<HolidayRecord> HolidayRecords { get; set; }

        public Result()
        {
            this.HolidayFields = new List<HolidayField>();
            this.HolidayRecords = new List<HolidayRecord>();
        }
    }

    public class HolidayRecord
    {
        [JsonProperty(PropertyName = "date")]
        public string DateStr { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "isHoliday")]
        public string IsHoliday { get; set; }

        [JsonProperty(PropertyName = "holidayCategory")]
        public string HolidayCategory { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }

    public class HolidayField
    {

        [JsonProperty(PropertyName = "type")]
        public string FieldType { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string FeildId { get; set; }


  
    }
}
