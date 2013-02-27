using System;

namespace org.tamrah.islamic.hijri
{
	public abstract class Calendar
	{
		//
		public const int ERA = 0;
		//
		public const int YEAR = 1;
		//Can be one of (JANUARY.....DECEMBER)
		public const int MONTH = 2;
		public const int WEEK_OF_YEAR = 3;
		public const int WEEK_OF_MONTH = 4;
		//DAY
		public const int DATE = 5;
		//DAY
		public const int DAY_OF_MONTH = 5;
		//
		public const int DAY_OF_YEAR = 6;
		// Can be one of (SUNDAY, MONDAY......SATURDAY)
		public const int DAY_OF_WEEK = 7;
		//
		public const int DAY_OF_WEEK_IN_MONTH = 8;
		//
		public const int AM_PM = 9;
		//
		public const int HOUR = 10;
		//
		public const int HOUR_OF_DAY = 11;
		//
		public const int MINUTE = 12;
		//
		public const int SECOND = 13;
		//
		public const int MILLISECOND = 14;
		// +3, +4 ...etc
		public const int ZONE_OFFSET = 15;
		//
		public const int DST_OFFSET = 16;
		//
		public const int FIELD_COUNT = 17;

		//Used to store Date ERA, YEAR, MONTH ..... DST_OFFSET
		internal int[] values = new int[FIELD_COUNT];

		//ERAs
		public const int BC = 0;
		public const int AD = 1;

		//DAYS
		public const int SUNDAY = 1;
		public const int MONDAY = 2;
		public const int TUESDAY = 3;
		public const int WEDNESDAY = 4;
		public const int THURSDAY = 5;
		public const int FRIDAY = 6;
		public const int SATURDAY = 7;

		//MONTHS
		public const int JANUARY = 0;
		public const int FEBRUARY = 1;
		public const int MARCH = 2;
		public const int APRIL = 3;
		public const int MAY = 4;
		public const int JUNE = 5;
		public const int JULY = 6;
		public const int AUGUST = 7;
		public const int SEPTEMBER = 8;
		public const int OCTOBER = 9;
		public const int NOVEMBER = 10;
		public const int DECEMBER = 11;

		//
		public const int AM = 0;
		public const int PM = 1;
		
		internal Calendar ()
		{
		}	
		public static Calendar getInstance()
		{
			return new GregorianCalendar();
		}
		//

		public DateTime getTime() {
			return Convert.ToDateTime(get (MILLISECOND));
		}
		public void setTime (DateTime DateTime)
		{
			set(MILLISECOND, DateTime.Millisecond);
		}

		public virtual void add(int field, int amount){

		}

		public int get(int field)
		{
			if(field >= FIELD_COUNT)
				throw new Exception();
			return values[field];
		}

		public void set(int field, int value)
		{
			if(field >= FIELD_COUNT)
				throw new Exception();
			values[field] = value;
		}

		public virtual int getMaximum(int field)
		{
			return 0;
		}

		public virtual int getMinimum(int field)
		{
			return 0;
		}

		public virtual int getActualMaximum(int field)
		{
			return 0;
		}

		//
		internal static int getDayOfWeek (DayOfWeek DayOfWeek)
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

