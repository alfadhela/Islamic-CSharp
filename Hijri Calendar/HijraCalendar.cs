using System;

namespace org.tamrah.islamic.hijri
{
	public class HijraCalendar : Calendar
	{
		internal const int CONTS_P = 191;
		internal const int CONTS_Q = 360;
		internal const int CONTS_A = 48;
		//Julian 0622-7-16 = gregorian 0759-6-11 (I think it should be 622, 7, 19)
		internal const int HIJRI_EPOCH = 227015;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * first month of the year in the Hijri calendar.
     */
		public const int MUHARRAM = 1;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * second month of the year in the Hijri calendar.
     */
		public const int SAFAR = 2;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * third month of the year in the Hijri calendars.
     */
		public const int RABI_I = 3;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * fourth month of the year in the Hijri calendar.
     */
		public const int RABI_II = 4;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * fifth month of the year in the Hijri calendar.
     */
		public const int JUMADA_I = 5;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * sixth month of the year in the Hijri calendar.
     */
		public const int JUMADA_II = 6;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * seventh month of the year in the Hijri calendar.
     */
		public const int RAJAB = 7;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * eighth month of the year in the Hijri calendar.
     */
		public const int SHAABAN = 8;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * ninth month of the year in the Hijri calendar.
     */
		public const int RAMADAN = 9;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * tenth month of the year in the Hijri calendar.
     */
		public const int SHAWWAL = 10;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * eleventh month of the year in the Hijri calendar.
     */
		public const int DHU_AL_QIDAH = 11;
		
		/**
     * Value of the {@link #MONTH} field indicating the
     * twelfth month of the year in the Hijri calendar.
     */
		public const int DHU_AL_HIJJAH = 12;
		
		/**
     * Gets a hijri calendar using the default time zone and locale. The
     * <code>HijraCalendar</code> returned is based on the current time
     * in the default time zone with the default locale.
     *
     * @return a HijraCalendar.
     */
		public static HijraCalendar getInstance(){
			return new HijraCalendar(Calendar.getInstance());
		}
		
		public HijraCalendar(Calendar calendar){
			gregorianToHijri(calendar);
		}
		/**
	 * 
	 * @param year Hijri year
	 * @param month Hijri month
	 * @param day Hijri day
	 */
		public HijraCalendar(int year, int month, int day){
			set(YEAR, year);
			set(MONTH, month);
			set(DAY_OF_MONTH, day);
			set(DAY_OF_WEEK, getHijriDayOfWeek(year, month, day));
		}
		
		public Calendar toGregorianCalendar(){
			return hijriToGregorian(get(YEAR), get(MONTH), get(DAY_OF_MONTH));
		}
		
		/**
	 * 
	 * @param year Hijri year
	 * @param month Hijri month
	 * @return the number of days in a given hijri month in a given
	 */
		internal int getHijriMonthDays(int year, int month){
			int Mc = ( year -1) *12 + month;
			if ((((Mc+ CONTS_A) * CONTS_P) % CONTS_Q)  < CONTS_P) 
				return 30;
			else
				return 29;
		}
		
		/**
	 * 
	 * @param year Hijri year
	 * @param month Hijri month
	 * @return the number of days before a given moth in a given year (0 for month=1)
	 */
		internal int getHijriDaysBeforeMonth(int year, int month){
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
		
		/**
	 * 
	 * @param year Hijri year
	 * @return the number of days in a given year
	 */
		internal int getHijriYearDays(int year){
			return getHijriDaysBeforeMonth(year,13);
		}
		
		/**
	 * 
	 * @param year Hijri year
	 * @param month Hijri month
	 * @param day Hijri day
	 * @return the day number within the year of the Islamic date (year, month, day), 1 for 1/1 in any year
	 */
		internal int getHijriDayNumber(int year, int month, int day){
			return getHijriDaysBeforeMonth(year, month) + day;
		}
		
		/**
	 * 
	 * @param year Hijri year
	 * @param month Hijri month
	 * @param day Hijri day
	 * @return absolute date of Hijri (year, month, day), eg. ramadan (9),1,1427 -> 732578
	 */
		internal int hijriToAbsolute(int year, int month, int day){
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
		
		/**
	 * Hijri date (Y,M,D) corresponding to the given absolute number of days.
	 * @param date absolute number of days
	 */
		internal void absoluteToHijri(int date){
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
					mMONTH=DHU_AL_HIJJAH;
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
		
		/**
	 * 
	 * @param year
	 * @return 1 (True) if YEAR is a Gregorian leap year
	 */
		internal int isGregorianLeapYear(int year){
			if ((year % 4) == 0 && ((year % 100) == 0 || (year % 400) == 0))
				return 1;
			return 0;
		}
		
		//Length of months (in days) in Gregorian calendar 
		int [] days_in_month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @return The last day in MONTH during YEAR
	 */
		internal int getGregorianMonthDays(int year, int month){
			if (month == 2 && isGregorianLeapYear(year) == 1)
				return 29;
			return days_in_month[month-1];
		}
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @param day
	 * @return the day number within the year of the date (year,month, day)
	 */
		internal int getGergorianDayNumber(int year, int month, int day){
			if (month<3) 
				return day + (31 * (month - 1));
			return day + (31 * (month - 1)) - 
				((month << 2) + 23) / 10 + (isGregorianLeapYear(year));
		}
		
		internal int gregorianToAbsolute(int year, int month, int day){
			int prior_years = year - 1;
			return getGergorianDayNumber (year, month, day) + 
				365 * prior_years + (prior_years >> 2) - 
					(prior_years / 100) + (prior_years / 400);
		}
		
		/**
	 * (year month day) corresponding to the absolute DATE.
		The absolute date is the number of days elapsed since the (imaginary)
		Gregorian date Sunday, December 31, 1 BC.
	 * @param date
	 */
		internal Calendar absoluteToGregorian(int date){
			Calendar calendar = Calendar.getInstance();
			int d0 = date - 1;
			int n400 = d0 / 146097;
			int d1 = d0 % 146097;
			int n100 = d1 / 36524;
			int d2 = d1 % 36524;
			int n4 = d2 / 1461;
			int d3 = d2 % 1461;
			int n1 = d3 / 365;
			//		int dd = (d3 % 365) + 1;
			int yy = ((400 * n400) + (100 * n100) + (n4 * 4) + n1);
			if ((n100 == 4) || (n1 == 4)){
				calendar.set(Calendar.YEAR, yy);
				calendar.set(Calendar.MONTH, Calendar.DECEMBER);
				calendar.set(Calendar.DAY_OF_MONTH, 31);
			}else{
				yy=yy+1;
				int mm = 1;
				while(date >= gregorianToAbsolute (yy,mm, 1)){
					mm+=1;
				}
				int d=gregorianToAbsolute (yy, mm-1, 1);
				calendar.set(Calendar.YEAR, yy);
				calendar.set(Calendar.MONTH, mm-2);
				calendar.set(Calendar.DAY_OF_MONTH, date-d+1);
			}
			return calendar;
		}
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @return the number of days in a given hijri month in a given year
	 */
		internal int getHijriMonthDays_(int year, int month){
			return hijriToAbsolute(year+month/12,month%12+1,1)-hijriToAbsolute(year,month,1);
		}
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @param day
	 * @return the day-of-the-week index of hijri (year,month,day) Date, 0 for Sunday, 1 for Monday, etc.
	 */
		internal int getHijriDayOfWeek(int year, int month, int day){
			return hijriToAbsolute(year, month, day) % 7;
		}
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @param day
	 * @return the day-of-the-week index of gregorian (year, month, day) DATE, 0 for Sunday, 1 for Monday, etc.
	 */
		internal int getGregorianDayOfWeek(int year, int month, int day){
			return gregorianToAbsolute (year,month, day) % 7;
		}
		
		/**
	 * 
	 * @param year
	 * @param month
	 * @param day
	 * @return gregorian (year, month, day) converted from Islamic Hijri calender
	 */
		public Calendar hijriToGregorian(int year, int month, int day){
			return absoluteToGregorian( hijriToAbsolute (year, month, day));
		}
		
		/**
	 * Hijri  (year, month, day) converted from gregorian calender
	 * @param year
	 * @param month
	 * @param day
	 */
		internal void gregorianToHijri(int year, int month, int day){
			absoluteToHijri(gregorianToAbsolute(year, month, day));
		}
		
		/**
	 * Hijri  (year, month, day) converted from gregorian calender
	 * @param calendar 
	 */
		internal void gregorianToHijri(Calendar calendar){
			absoluteToHijri(gregorianToAbsolute(calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH)+1, calendar.get(Calendar.DAY_OF_MONTH)));
		}
		
		
		public override void add(int field, int amount) {
			switch (field) {
			case DAY_OF_MONTH:
				Calendar calendarDAY_OF_MONTH = toGregorianCalendar();
				calendarDAY_OF_MONTH.add(DAY_OF_MONTH, amount);
				gregorianToHijri(calendarDAY_OF_MONTH);
				break;
			case DAY_OF_YEAR:
				Calendar calendarDAY_OF_YEAR = toGregorianCalendar();
				calendarDAY_OF_YEAR.add(DAY_OF_YEAR, amount);
				gregorianToHijri(calendarDAY_OF_YEAR);
				break;
			case MONTH:
				if(amount > 0){
					//plus: add more months.
					int actualAmountOfDays = 0;
					for(int i = 0; i < amount; i++){
						if(get(MONTH)+i < DHU_AL_HIJJAH)
							actualAmountOfDays += getHijriMonthDays(get(MONTH)+i, get(YEAR));
						else
							actualAmountOfDays += getHijriMonthDays((get(MONTH)+i%12), get(YEAR) + (get(MONTH)+i/12));
					}
					Calendar nextMonth = toGregorianCalendar();
					nextMonth.add(DAY_OF_YEAR, actualAmountOfDays);
					gregorianToHijri(nextMonth);
				}else if(amount < 0){
					//minus: remove months.
					int actualAmountOfDays = 0;
					for(int i = 1; i <= -amount; i++){
						if(get(MONTH)-i < 1){
							int month = (-(get(MONTH)-i%-12)) == 0?DHU_AL_HIJJAH:(-(get(MONTH)-i%-12));
							actualAmountOfDays += getHijriMonthDays(month , get(YEAR) - (get(MONTH)-i/-12));
						}else
							actualAmountOfDays += getHijriMonthDays(get(MONTH)-i, get(YEAR));
					}
					Calendar preMonth = toGregorianCalendar();
					preMonth.add(DAY_OF_YEAR, -actualAmountOfDays);
					gregorianToHijri(preMonth);
				}
				break;
			case YEAR:
				add(MONTH, amount * getActualMaximum(MONTH));
				break;
			default:
				set(field, get(field) + amount);
				break;
			}
		}
		
		
		public int getLeastMaximum(int field) {
			// TODO Auto-generated method stub
			return 0;
		}
		
		
		public override int getMaximum(int field) {
			int ret = 0;
			switch (field) {
			case DAY_OF_MONTH:
				ret = 30;
				break;
			case DAY_OF_WEEK:
				ret = 7;
				break;
			case MONTH:
				ret = 12;
				break;
			case YEAR:
				ret = 9999;
				break;
				//		case ERA:
				//			ret = AH;
				//			break;
			}
			return ret;
		}
		
		
		public override int getMinimum(int field) {
			int ret = 0;
			switch (field) {
			case DAY_OF_MONTH:
			case DAY_OF_WEEK:
			case MONTH:
				ret = 1;
				break;
			case YEAR:
				ret = 0;
				break;
				//		case ERA:
				//			ret = BH;
			}
			return ret;
		}
		
		
		public override int getActualMaximum(int field) {
			int ret = 0;
			switch (field) {
			case DAY_OF_MONTH:
				ret = getHijriMonthDays(get(MONTH), get(YEAR));
				break;
			case DAY_OF_WEEK:
				ret = 7;
				break;
			case MONTH:
				ret = 12;
				break;
			case YEAR:
				ret = 9999;
				break;
				//		case ERA:
				//			ret = AH;
				//			break;
			}
			return ret;
		}
	}
}

