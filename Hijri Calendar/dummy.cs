using System;
using org.tamrah.islamic.hijri;

namespace HijraCalendar
{
	public class dummy
	{

		public static void Main ()
		{
		
			/*
			Calendar calendar = Calendar.getInstance ();


			calendar.set (Calendar.YEAR, datetime.Year);
			calendar.set (Calendar.MONTH, datetime.Month);
			calendar.set (Calendar.DATE, datetime.Day);

			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));
         */

			HijriCalendar calendar = new HijriCalendar();

			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));


		}
	}
}

