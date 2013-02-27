using System;

namespace org.tamrah.islamic.hijri
{
	public class Calendar
	{
		//
		public readonly static int ERA = 0;
		//
		public readonly static int YEAR = 1;
		//Can be one of (JANUARY.....DECEMBER)
		public readonly static int MONTH = 2;
		public readonly static int WEEK_OF_YEAR = 3;
		public readonly static int WEEK_OF_MONTH = 4;
		//DAY
		public readonly static int DATE = 5;
		//DAY
		public readonly static int DAY_OF_MONTH = 5;
		//
		public readonly static int DAY_OF_YEAR = 6;
		// Can be one of (SUNDAY, MONDAY......SATURDAY)
		public readonly static int DAY_OF_WEEK = 7;
		//
		public readonly static int DAY_OF_WEEK_IN_MONTH = 8;
		//
		public readonly static int AM_PM = 9;
		//
		public readonly static int HOUR = 10;
		//
		public readonly static int HOUR_OF_DAY = 11;
		//
		public readonly static int MINUTE = 12;
		//
		public readonly static int SECOND = 13;
		//
		public readonly static int MILLISECOND = 14;
		// +3, +4 ...etc
		public readonly static int ZONE_OFFSET = 15;
		//
		public readonly static int DST_OFFSET = 16;
		//
		public readonly static int FIELD_COUNT = 17;

		//Used to store Date ERA, YEAR, MONTH ..... DST_OFFSET
		private int[] values = new int[FIELD_COUNT];

		//ERAs
		public readonly static int BC = 0;
		public readonly static int AD = 1;

		//DAYS
		public readonly static int SUNDAY = 1;
		public readonly static int MONDAY = 2;
		public readonly static int TUESDAY = 3;
		public readonly static int WEDNESDAY = 4;
		public readonly static int THURSDAY = 5;
		public readonly static int FRIDAY = 6;
		public readonly static int SATURDAY = 7;

		//MONTHS
		public readonly static int JANUARY = 0;
		public readonly static int FEBRUARY = 1;
		public readonly static int MARCH = 2;
		public readonly static int APRIL = 3;
		public readonly static int MAY = 4;
		public readonly static int JUNE = 5;
		public readonly static int JULY = 6;
		public readonly static int AUGUST = 7;
		public readonly static int SEPTEMBER = 8;
		public readonly static int OCTOBER = 9;
		public readonly static int NOVEMBER = 10;
		public readonly static int DECEMBER = 11;

		//
		public readonly static int AM = 0;
		public readonly static int PM = 1;
		protected Calendar ()
		{
		}	
		public static Calendar getInstance ()
		{
			Calendar calendar = new Calendar() ;
			//
			DateTime dateTime = DateTime.Now;
			//
			if(dateTime.Year > 0)
				calendar.set(ERA, AD);
			else
				calendar.set(ERA, BC);
			//
			calendar.set(YEAR, dateTime.Year);
			//
			calendar.set(MONTH, dateTime.Month - 1);
			//
			calendar.set(DATE, dateTime.Day);
			//
			calendar.set(DAY_OF_MONTH, dateTime.Day);
			//DAY_OF_YEAR

			//
			calendar.set(DAY_OF_WEEK, getDayOfWeek(dateTime.DayOfWeek));
			//
			//calendar.set();
			//
			calendar.set(MINUTE, dateTime.Minute);
			calendar.set(SECOND, dateTime.Second);
			calendar.set(MILLISECOND, dateTime.Millisecond);

			return calendar;
		}
		//

		public DateTime getTime() {
			return DateTime.Now;
		}
		public void setTime (DateTime DateTime)
		{
	//		setTimeInMillis (DateTime.Millisecond ());
		}

		public int get (int field)
		{
			if(field >= FIELD_COUNT)
				throw new Exception();
			return values[field];
		}

		public void set (int field, int value)
		{
			if(field >= FIELD_COUNT)
				throw new Exception();
			values[field] = value;
		}

		//
		private static int getDayOfWeek (DayOfWeek DayOfWeek)
		{
			switch (DayOfWeek) {
			case System.DayOfWeek.Sunday:
				return SUNDAY;
			case System.DayOfWeek.Monday:
				return MONDAY;
			case System.DayOfWeek.Tuesday:
				return TUESDAY;
			case System.DayOfWeek.Wednesday:
				return WEDNESDAY;
			case System.DayOfWeek.Thursday:
				return THURSDAY;
			case System.DayOfWeek.Friday:
				return FRIDAY;
			default:
				return SATURDAY;
			}
		}
	}
}

