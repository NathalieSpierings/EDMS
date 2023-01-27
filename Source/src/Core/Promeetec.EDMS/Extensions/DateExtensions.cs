namespace Promeetec.EDMS.Portaal.Core.Extensions;

public static class DateExtensions
{
    /// <summary>
    /// Gets the months between.
    /// </summary>
    /// <param name="from">From.</param>
    /// <param name="to">To.</param>
    public static int GetMonthsBetween(DateTime from, DateTime to)
    {
        if (from > to) return GetMonthsBetween(to, from);

        var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

        if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            return monthDiff - 1;

        return monthDiff;
    }


    /// <summary>
    /// Gets the first day of the month.
    /// </summary>
    /// <param name="date">The date.</param>
    public static DateTime GetFirstDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    /// <summary>
    /// Gets the last day of the month.
    /// </summary>
    /// <param name="date">The date.</param>
    public static DateTime GetLastDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.GetDaysInMonth());
    }

    /// <summary>
    /// Gets the total days in a month.
    /// </summary>
    /// <param name="date">The date.</param>
    public static int GetDaysInMonth(this DateTime date)
    {
        return DateTime.DaysInMonth(date.Year, date.Month);
    }

    /// <summary>
    /// Gets the dates between a given date range.
    /// </summary>
    /// <param name="startDate">The date1.</param>
    /// <param name="endDate">The date2.</param>
    public static IEnumerable<DateTime> GetDatesBetweenRange(DateTime startDate, DateTime endDate)
    {
        while (startDate <= endDate)
        {
            yield return startDate;
            startDate = startDate.AddMonths(1);
        }

        if (startDate > endDate && startDate.Month == endDate.Month)
        {
            // Include the last month
            yield return startDate;
        }
    }

    /// <summary>
    /// Gets the first day of quarter.
    /// </summary>
    /// <param name="originalDate">The original date.</param>
    /// <returns>The first day of a quarter date.</returns>
    public static DateTime GetFirstDayOfQuarter(this DateTime originalDate)
    {
        return AddQuarters(new DateTime(originalDate.Year, 1, 1), GetCurrentQuarter(originalDate) - 1);
    }

    /// <summary>
    /// Gets the first day of quarter.
    /// </summary>
    /// <param name="quarter">The quarter.</param>
    /// <param name="quarterYear">The quarter year.</param>
    /// <returns>The first day of a quarter date.</returns>
    public static DateTime GetFirstDayOfQuarterByQuarterNumber(this int quarter, int quarterYear = default)
    {
        var year = DateTime.Now.Year;

        if (quarterYear != default)
            year = quarterYear;

        DateTime quarterStartDate = DateTime.MinValue;
        switch (quarter)
        {
            case 1:
                quarterStartDate = GetFirstDayOfQuarter(new DateTime(year, 1, 1));
                break;
            case 2:
                quarterStartDate = GetFirstDayOfQuarter(new DateTime(year, 4, 1));
                break;
            case 3:
                quarterStartDate = GetFirstDayOfQuarter(new DateTime(year, 7, 1));
                break;
            case 4:
                quarterStartDate = GetFirstDayOfQuarter(new DateTime(year, 10, 1));
                break;
        }

        return quarterStartDate;
    }


    /// <summary>
    /// Gets the last day of quarter.
    /// </summary>
    /// <param name="originalDate">The original date.</param>
    /// <returns>The last day of a quarter date.</returns>
    public static DateTime GetLastDayOfQuarter(this DateTime originalDate)
    {
        return AddQuarters(new DateTime(originalDate.Year, 1, 1), GetCurrentQuarter(originalDate)).AddDays(-1);
    }

    /// <summary>
    /// Adds quarters.
    /// </summary>
    /// <param name="originalDate">The original date.</param>
    /// <param name="quarters">The quarters.</param>
    /// <returns>The quarter date.</returns>
    public static DateTime AddQuarters(this DateTime originalDate, int quarters)
    {
        return originalDate.AddMonths(quarters * 3);
    }


    /// <summary>
    /// Gets the current quarter.
    /// </summary>
    /// <param name="fromDate">From date.</param>
    /// <returns>The current quarter date.</returns>
    public static int GetCurrentQuarter(this DateTime fromDate)
    {
        int month = fromDate.Month - 1;
        int month2 = Math.Abs(month / 3) + 1;
        return month2;
    }


    /// <summary>
    /// Gets the periods for the given date.
    /// </summary>
    /// <param name="today">The today date.</param>
    /// <param name="aantalTeTonenKwartalen">The total quartals to show. More than 4 will show quarters of newxt year.</param>
    /// <returns>The periods.</returns>
    public static Dictionary<string, string> GetPeriods(this DateTime today, int aantalTeTonenKwartalen = 7)
    {
        var periods = new Dictionary<string, string>();
        var total = aantalTeTonenKwartalen;
        var currentYear = today.Year;
        var currentQuarter = (today.Month + 2) / 3;
        var nextQuarter = currentQuarter + 1;
        var year = currentYear;

        for (var i = 0; i < total; i++)
        {
            if (nextQuarter == 0)
            {
                nextQuarter = 4;
                year -= 1;
            }

            if (nextQuarter == 5)
            {
                nextQuarter = 1;
                year += 1;
            }

            periods.Add($"{year}-Q{nextQuarter}", $"{year}-Q{nextQuarter}");
            nextQuarter--;
        }

        return periods;
    }


    /// <summary>
    /// Gets the quartals display names for the given date.
    /// </summary>
    /// <param name="today">The today date.</param>
    /// <param name="quartersToShow">The total quartersto show. More than 4 will show quarters of last year.</param>
    /// <returns>The periods.</returns>
    public static Dictionary<string, string> GetListOfQuarters(this DateTime today, int quartersToShow = 3)
    {
        var periods = new Dictionary<string, string>();
        var total = quartersToShow;
        var currentYear = today.Year;
        var currentQuarter = (today.Month + 2) / 3;
        var prevQuarter = currentQuarter - 1;
        var year = currentYear;

        periods.Add($"{year}-Q{currentQuarter}", $"{year}-Q{currentQuarter}");

        for (var i = 0; i < total; i++)
        {
            if (prevQuarter == 0)
            {
                prevQuarter = 4;
                year -= 1;
            }

            periods.Add($"{year}-Q{prevQuarter}", $"{year}-Q{prevQuarter}");
            prevQuarter--;
        }

        return periods;
    }

}