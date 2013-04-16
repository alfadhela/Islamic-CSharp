using System;
using org.tamrah.islamic.hijri;

namespace HijraCalendar
{
	public class dummy
	{

		public static void Main ()
		{
			/*
			String[] weekDays = {"SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT"};

			Calendar calendar = Calendar.getInstance ();

			Console.WriteLine ( weekDays[calendar.get (Calendar.DAY_OF_WEEK)] + ", " +calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));

			calendar.add(Calendar.DATE,3);
			Console.WriteLine ( weekDays[calendar.get (Calendar.DAY_OF_WEEK)] + ", " +calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));

			Console.WriteLine ("Hijra Calendar");

			org.tamrah.islamic.hijri.HijraCalendar hCalendar = org.tamrah.islamic.hijri.HijraCalendar.getInstance();

			Console.WriteLine ( weekDays[hCalendar.get (Calendar.DAY_OF_WEEK)] + ", " + hCalendar.get (Calendar.YEAR) + "-" + hCalendar.get (Calendar.MONTH) + "-" + hCalendar.get (Calendar.DATE));
			hCalendar.add(Calendar.DATE,-18);
			Console.WriteLine ( weekDays[hCalendar.get (Calendar.DAY_OF_WEEK)] + ", " +hCalendar.get (Calendar.YEAR) + "-" + hCalendar.get (Calendar.MONTH) + "-" + hCalendar.get (Calendar.DATE));



			org.tamrah.islamic.hijri.UmmALQura UmmALQuraCalendar = org.tamrah.islamic.hijri.UmmALQura.getInstance();
			Console.WriteLine ("UmmALQura Calendar");
			Console.WriteLine ( weekDays[UmmALQuraCalendar.get (Calendar.DAY_OF_WEEK)] + ", " + UmmALQuraCalendar.get (Calendar.YEAR) + "-" + UmmALQuraCalendar.get (Calendar.MONTH) + "-" + UmmALQuraCalendar.get (Calendar.DATE));

			UmmALQuraCalendar.add (Calendar.DATE, 3);
			Console.WriteLine ( weekDays[UmmALQuraCalendar.get (Calendar.DAY_OF_WEEK)] + ", " + UmmALQuraCalendar.get (Calendar.YEAR) + "-" + UmmALQuraCalendar.get (Calendar.MONTH) + "-" + UmmALQuraCalendar.get (Calendar.DATE));

			*/

			org.tamrah.islamic.Pray.PrayTime p = new org.tamrah.islamic.Pray.PrayTime();
			double lo = 25;
			double la = 55;
			int y = 0 , m = 0 , d = 0 , tz = 0;
			
			DateTime cc = DateTime.Now;
			y = cc.Year;
			m = cc.Month;
			d = cc.Day;
			tz = TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime (y,m,d)).Hours;
			String [] s ;
			
			p.setCalcMethod ( 2 );
			p . setAsrMethod ( 0 );
			s = p . getDatePrayerTimes ( y , m , d , lo , la , tz );
			for(int i = 0 ; i < s.Length ; ++i )
			{
				Console . WriteLine ( s [ i ] );
			}
				
		}
	}
	
	
}

