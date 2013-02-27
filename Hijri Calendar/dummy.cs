using System;
using org.tamrah.islamic.hijri;

namespace HijraCalendar
{
	public class dummy
	{

		public static void Main ()
		{
			Calendar calendar = Calendar.getInstance();
			Console.WriteLine(calendar.get(Calendar.YEAR) + "-" + calendar.get(Calendar.MONTH) + "-" + calendar.get(Calendar.DATE));

			calendar.set(Calendar.YEAR, 2012);
			Console.WriteLine(calendar.get(Calendar.YEAR) + "-" + calendar.get(Calendar.MONTH) + "-" + calendar.get(Calendar.DATE));

			calendar.add(Calendar.MONTH, -5);
			Console.WriteLine(calendar.get(Calendar.YEAR) + "-" + calendar.get(Calendar.MONTH) + "-" + calendar.get(Calendar.DATE));
		}
	}
}

