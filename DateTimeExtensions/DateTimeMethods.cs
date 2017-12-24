using System;
using System.Linq;

namespace DateTimeExtensions
{
    public static class DateTimeMethods
    {
        public static bool IsGreaterThan(this DateTime reference, DateTime target)
        {
            return reference.Ticks > target.Ticks;
        }

        public static bool IsLowerThan(this DateTime reference, DateTime target)
        {
            return reference.Ticks < target.Ticks;
        }

        public static bool IsBetween(this DateTime reference, DateTime targetOne, DateTime targetTwo)
        {
            var dates = (new[] { targetOne, targetTwo })
                .OrderBy(_ => _);

            return dates.First().IsLowerThan(reference) && (dates.Last().Ticks.Equals(reference.Ticks) || dates.Last().IsGreaterThan(reference));
        }
    }
}
