using System;

namespace N5.UserPermissions.Common.LocalConvertUTC
{
    public class DateUtcToLocal
    {
        public DateTime DateTimeUtc { get; set; }
        public string SystemTimeZoneId { get; set; }

        public DateUtcToLocal()
        {

        }

        public DateUtcToLocal(DateTime dateTimeUtc, string systemTimeZoneId = "SA Pacific Standard Time")
        {
            this.DateTimeUtc = dateTimeUtc;
            this.SystemTimeZoneId = systemTimeZoneId;
        }

        public DateTime ToDateLocal()
        {
            return TimeZoneInfo.ConvertTime(this.DateTimeUtc, TimeZoneInfo.FindSystemTimeZoneById(this.SystemTimeZoneId));
        }

        /*SA Pacific Standard Time -> Peru*/
    }
}
