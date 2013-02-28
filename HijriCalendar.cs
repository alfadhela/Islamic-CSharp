using System;

namespace org.tamrah.islamic.hijri
{
	public class HijriCalendar :Calendar
	{
		public const int CONTS_P = 191;
		public const int CONTS_Q = 360;
		public const int CONTS_A = 48;
		//Julian 0622-7-16 = gregorian 0759-6-11 (I think it should be 622, 7, 19)
		public const int HIJRI_EPOCH = 227015;
		
		//	public static HijraCalendar getInstance(){
		//	return new HijraCalendar(Calendar.getInstance());
		
		
		public HijriCalendar ()
		{
			DateTime datetime = DateTime.Now;
			gregorianToHijri (datetime.Year,datetime.Month,datetime.Day);
		    
		}

		
		/*
		public HijriCalendar	(Calendar calendar)
		{
			gregorianToHijri (calendar.get(YEAR),calendar.get(MONTH),calendar.get(DATE));

		} 
		*/

		protected void gregorianToHijri(int year, int month, int day){
			absoluteToHijri(gregorianToAbsolute(year, month, day));
		}
		
		protected int gregorianToAbsolute(int year, int month, int day){
			int prior_years = year - 1;
			return getGergorianDayNumber (year, month, day) + 
				365 * prior_years + (prior_years >> 2) - 
					(prior_years / 100) + (prior_years / 400);
		}
		protected void absoluteToHijri(int date){
			if(date < HIJRI_EPOCH) //pre-Islamic date
				return;
			int Mc = (date-HIJRI_EPOCH+1)*CONTS_Q/(29*CONTS_Q+CONTS_P);
			int mYEAR = Mc/12+1;
			int mMONTH = (Mc%12)+1;
			// consistency check
			int d = hijriToAbsolute(mYEAR,mMONTH,1); //TODO: this is an expensive call
			if (date < d){ // go one month back if needed
				mMONTH-=1;
				if (mMONTH==0){
					mYEAR-=1;
					mMONTH=12;
				}
				int monthDays = getHijriMonthDays(mYEAR,mMONTH);
				d-=monthDays; // this call is fast
			}
			//
			int mDAY = 1 + date - d;
			set(YEAR, mYEAR);
			set(MONTH, mMONTH);
			set(DAY_OF_MONTH, mDAY);
			set(DAY_OF_WEEK, getHijriDayOfWeek(mYEAR, mMONTH, mDAY));
		}
		
		protected int hijriToAbsolute(int year, int month, int day){
			int Mc = (year - 1) * 12;
			// day count=days before Hijra plus (...)
			int dc = HIJRI_EPOCH;
			// plus days in the years before till first multiples of q plus (...)
			Mc-=Mc % CONTS_Q;
			int y = year - Mc/12;
			dc += (Mc*29) + (Mc*CONTS_P/CONTS_Q);
			// plus those after the multiples plus (...)
			for (int i = 1; i < y; i++)
				dc += getHijriYearDays(i);
			// plus days from the begining of that year
			dc += getHijriDayNumber (year, month, day) - 1;
			return dc;
			
		}
		
		protected int getHijriYearDays(int year){
			return getHijriDaysBeforeMonth(year,13);
		}
		protected int getHijriDaysBeforeMonth(int year, int month){
			int Mc = ( year -1) *12 + 1 + CONTS_A;
			int McM = Mc * CONTS_P;
			int sum = 0;
			for (int i = 1; i < month; i++) {
				if ((McM % CONTS_Q)  < CONTS_P)
					sum+=30;
				else
					sum+=29;
				McM+=CONTS_P;
			}
			return sum;
		}
		public int getHijriDayNumber(int year, int month, int day){
			return getHijriDaysBeforeMonth(year, month) + day;
		}
		
		protected int getHijriDayOfWeek(int year, int month, int day){
			return hijriToAbsolute(year, month, day) % 7;
		}
		
		protected int getHijriMonthDays(int year, int month){
			int Mc = ( year -1) *12 + month;
			if ((((Mc+ CONTS_A) * CONTS_P) % CONTS_Q)  < CONTS_P) 
				return 30;
			else
				return 29;
		}
		
		protected int getGergorianDayNumber(int year, int month, int day){
			if (month<3) 
				return day + (31 * (month - 1));
			return day + (31 * (month - 1)) - 
				((month << 2) + 23) / 10 + (isGregorianLeapYear(year));
		}
		
		protected int isGregorianLeapYear(int year){
			if ((year % 4) == 0 && ((year % 100) == 0 || (year % 400) == 0))
				return 1;
			return 0;
		}
	}
}


		
