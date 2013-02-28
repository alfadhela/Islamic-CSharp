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
			calendar.add(Calendar.DATE,52);


			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));

			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));


          */
			HijriCalendar calendar = new HijriCalendar();

			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));
			calendar.add(Calendar.DATE,-18);
			Console.WriteLine (calendar.get (Calendar.YEAR) + "-" + calendar.get (Calendar.MONTH) + "-" + calendar.get (Calendar.DATE));



		}
	}
}

