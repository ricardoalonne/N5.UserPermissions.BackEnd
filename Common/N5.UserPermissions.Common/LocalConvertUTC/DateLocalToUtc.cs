using System;

namespace N5.UserPermissions.Common.LocalConvertUTC
{
    public class DateLocalToUtc
    {
        public DateTime DateTime { get; set; }

        public DateLocalToUtc()
        {

        }

        public DateLocalToUtc(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        public DateTime ToDateUtc()
        {
            return this.DateTime.ToUniversalTime();
        }
    }
}
