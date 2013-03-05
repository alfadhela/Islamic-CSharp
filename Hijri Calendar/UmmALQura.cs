using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace org.tamrah.islamic.hijri
{
    ///<remarks> developed by Moataz AL Dawood [mtz1406@gmail.com] 7/7/2012 </remarks>
    /// <summary>
    /// 
    /// </summary>
    public class UmmALQura :Calendar
    {
		
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
		
		public  UmmALQura()
		{
			int a1 = 1;
			int a2 = 1;
			int a3 = 1;
			int a4 = 1;
			DateTime dt = DateTime.Now;
			GregorianToHijri(dt.Year, dt.Month, dt.Day, out a1, out a2, out a3,out a4);
			set (YEAR, a1);
			set (MONTH, a2);
			set (DATE, a3);
			set (DAY_OF_WEEK, a4);
		}

        public static bool GregorianToHijri(int yg, int mg, int dg, out int yh, out int mh, out int dh, out int dayweek)
        {
            
            int _yh = 0;
            int _mh = 0;
            int _dh = 0;
            int _dayweek = 0;

            int Found = G2HA(yg, mg, dg, ref _yh, ref _mh, ref _dh, ref _dayweek);


            if (Found == 1)
            {
                yh = _yh;
                mh = _mh;
                dh = _dh;
                dayweek = _dayweek;

                return true;
            }
            else
            {

                yh = 0;
                mh = 0;
                dh = 0;
                dayweek = 0;

                return false;
            }
        }

        public static bool HijriToGregorian(int yh, int mh, int dh, out int yg, out int mg, out int dg, out int dayweek)
        {
            int _yg = 0;
            int _mg = 0;
            int _dg = 0;
            int _dayweek = 0;

            int _yh = yh;
            int _mh = mh;
            int _dh = dh;

            int Found = H2GA(ref yh,ref  mh, ref dh, ref _yg, ref _mg, ref _dg, ref _dayweek);


            if (Found == 1)
            {
                yg = _yg;
                mg = _mg;
                dg = _dg;
                dayweek = _dayweek;

                return true;
            }
            else
            {
                yg = 0;
                mg = 0;
                dg = 0;
                dayweek = 0;

                return false;
            }
        }
        
/*
  CopyRight by Fayez Alhargan, 2000
  King Abdulaziz City for Science and Technology
  Computer and Electronics Research Institute
  Riyadh, Saudi Arabia
  alhargan@kacst.edu.sa
  Tel:4813770 Fax:4813764

  This is a program that computes the Hijary dates based on the moonset
  at Makkah.
  version: 1.01
  last modified 20-8-2000

*/

private static int HStartYear = 1300;
private static int HEndYear = 1600;
private static int[] MonthMap={17749
            ,12971,14647,17078,13686,17260,15189,19114,18774,13470,14685
            ,17082,13749,17322,19275,19094,17710,12973,13677,19290,18258
            ,20261,24202,19734,19030,19125,18100,19881,19346,19237,17995
            ,15003,17242,18137,17876,19877,19786,19093,17718,14709,17140
            ,18153,18132,18089,17717,12893,13501,14778,17332,19305,19242
            ,19029,17581,14941,17114,14041,20138,24212,19754,19542,17582
            ,14957,17770,19797,19786,19091,13611,14939,17722,14005,20137
            ,23890,19753,19029,17581,13677,19178,18148,20177,23970,19114
            ,18778,17114,13753,19378,18276,18121,17749,12971,13531,19130
            ,17844,19881,23890,19109,18733,12909,14573,17114,15061,19109
            ,19019,13463,14647,17078,14709,19817,19794,19605,18731,12891
            ,13531,18901,17874,19877,19786,19093,17741,15021,17322,19410
            ,19396,19337,19093,13613,13741,15210,18132,19913,19858,19110
            ,18774,12974,13677,13162,15189,19114,14669,13469,14685,12986
            ,13749,17834,15701,19098,14638,12910,13661,15066,18132,18085
            ,13643,14999,17742,15022,17836,15273,19858,19237,13899,15531
            ,17754,15189,18130,16037,20042,19093,13613,15021,17260,14169
            ,18130,18069,13613,14939,13498,14778,17332,15209,19282,19110
            ,13494,14701,17132,14041,20146,19796,19754,19030,13486,14701
            ,19818,19284,19241,14995,13611,14935,13622,15029,18090,16019
            ,19733,17963,15451,17722,14005,19890,23908,19753,19029,17581
            ,14701,19178,18152,20177,23972,19786,19050,17114,13753,19314
            ,23400,18129,18005,13483,14683,17082,13749,19881,23890,19622
            ,18766,17518,14685,17626,15061,19114,19021,13467,14647,17590
            ,14709,19818,19794,19109,18763,12971,13659,19161,17874,19909
            ,23954,19237,17749,15029,17844,19369,18338,18245,17811,15019
            ,17622,18902,17874,19365,19274,19093,17581,12637,13021,18906
            ,17844,17833,13613,12891,14519,12662,13677,19306,19146,19094
            ,17707,12635,12987,13750,19882,23444,19782,19085,17709,15005
            ,17754,14165,18249,20243,20042,19094,17750,14005,19370,23444
            };



private static short[] gmonth={31,31,28,31,30,31,30,31,31,30,31,30,31,31};/* makes it circular m[0]=m[12] & m[13]=m[1] */
private static short[] smonth={31,30,30,30,30,30,29,31,31,31,31,31,31,30}; /* makes it circular m[0]=m[12] & m[13]=m[1]  */

    //int  BH2GA(int yh,int mh,int *yg,int *mg, int *dg,int *dayweek);
    //int  G2HA(int yg,int mg, int dg,int *yh,int *mh,int *dh,int *dayweek);
    //int  H2GA(int *yh,int *mh,int *dh,int *yg,int *mg, int *dg,int *dayweek);
    //void S2G(int ys,int ms,int ds,int *yg,int *mg,int *dg);
    //void G2S(int yg,int mg,int dg,int *ys,int *ms,int *ds);


    //double GCalendarToJD(int yg,int mg, double dg );
    //double JDToGCalendar(double JD, int *yy,int *mm, int *dd);
    //int GLeapYear(int year);

    //void GDateAjust(int *yg,int *mg,int *dg);
    //int DayWeek(long JulianD);


    //double SCalendarToJD(int ys, int ms,double ds );
    //void JDToSCalendar(double JD, int *ys, int *ms,int *ds);
    //int HSLeapYear(long year);
    //void SDateAjust(int *ys,int *ms,int *ds);
    //void JDToHCalendar(double JD,int *yh,int *mh,int *dh);
    //double HCalendarToJD(int yh,int mh,int dh);
    //int HMonthLength(int yh,int mh);


    //double MSCalendarToJD(int ys, int ms,double ds );
    //void JDToMSCalendar(double JD, int *ys, int *ms,int *ds);
    //int HMSLeapYear(long year);
    //void MS2G(int ys,int ms,int ds,int *yg,int *mg,int *dg);
    //void G2MS(int ys,int ms,int ds,int *yg,int *mg,int *dg);

    //double ip(double x);
    //int mod(double x, double y);

/****************************************************************************/
/* Name:    BH2GA                                                            */
/* Type:    Procedure                                                       */
/* Purpose: Finds Gdate(year,month,day) for Hdate(year,month,day=1)  	    */
/*   Computation Based  on Store data  MonthMap                             */
/* Arguments:                                                               */
/* Input: Hijrah  date: year:yh, month:mh                                   */
/* Output: Gregorian date: year:yg, month:mg, day:dg , day of week:dayweek  */
/*       and returns flag found:1 not found:0                               */
/****************************************************************************/
 private static int  BH2GA(int yh,int mh,ref int yg,ref int mg, ref int dg,ref int dayweek)
{

  int flag,Dy,m,b;
  long JD;
  double GJD;
   /* Make sure that the date is within the range of the tables */
  if(mh<1) {mh=12;}
  if(mh>12) {mh=1;}
  if(yh<HStartYear) {yh=HStartYear;}
  if(yh>HEndYear)   {yh=HEndYear;}

   JD= Convert.ToInt64(Math.Truncate(( HCalendarToJD(yh,1,1))));  /* estimate JD of the begining of the year */
   Dy=MonthMap[yh-HStartYear]/4096;  /* Mask 1111000000000000 */
   GJD=JD-3+Dy;   /* correct the JD value from stored tables  */
   b=MonthMap[yh-HStartYear];
   b=b-Dy*4096;
   for(m=1;m<mh;m++)
   {
    flag=b%2;  /* Mask for the current month */
    if(flag == 1) Dy=30; else Dy=29;
    GJD=GJD+Dy;   /* Add the months lengths before mh */
    b=(b-flag)/2;
   }
   JDToGCalendar(GJD,ref yg,ref mg,ref dg);
   JD= Convert.ToInt64(Math.Truncate(( GJD)));
   dayweek=Convert.ToInt32((JD+1)%7);
   flag=1; /* date has been found */


 return flag;

}
/****************************************************************************/
/* Name:    HMonthLength						    */
/* Type:    Function                                                        */
/* Purpose: Obtains the month length            		     	    */
/* Arguments:                                                               */
/* Input : Hijrah  date: year:yh, month:mh                                  */
/* Output:  Month Length                                                    */
/****************************************************************************/
 private static int HMonthLength(int yh,int mh)
{
  int flag,Dy,N,m;
  if(yh<HStartYear || yh>HEndYear)
  {
   flag=0;
   Dy=0;
  }
 else
  {
    N=1;
    for(m=1;m<mh;m++)    N=2*N;

    flag=MonthMap[yh-HStartYear] & N;  /* Mask for the current month */
    if(flag == 1) Dy=30; else Dy=29;
   }

   return Dy;
}
/****************************************************************************/
/* Name:    G2HA                                                            */
/* Type:    Procedure                                                       */
/* Purpose: convert Gdate(year,month,day) to Hdate(year,month,day)          */
/* Arguments:                                                               */
/* Input: Gregorian date: year:yg, month:mg, day:dg                         */
/* Output: Hijrah  date: year:yh, month:mh, day:dh, day of week:dayweek     */
/*       and returns flag found:1 not found:0                               */
/****************************************************************************/
 private static int  G2HA(int yg,int mg, int dg,ref int yh,ref int mh,ref int dh,ref int dayweek)
{
   int  yh1=0,mh1=0,dh1=0;
   int  yh2,mh2,dh2;
   int  yg1=0,mg1=0,dg1 = 0;
   int  yg2=0,mg2=0,dg2 = 0;
   int  found;
  int flag;
  long J;
  double GJD;


   GJD=GCalendarToJD(yg,mg,dg+0.5);  /* find JD of Gdate */
   JDToHCalendar(GJD,ref yh1,ref mh1,ref dh1);  /* estimate the Hdate that correspond to the Gdate */
   found=0;flag=1;
   while( (!(found == 1)) && (flag == 1))  /* start searching for the exact Hdate */
   {
    flag=H2GA(ref yh1,ref mh1,ref dh1,ref yg1,ref mg1,ref dg1,ref dayweek);  /* compute the exact correponding Gdate for the dh1-mh1-yh1 */
    if(yg1>yg)
     {
       dh1--;
       if(dh1<1) {dh1=29+dh1;mh1--;}
     }

    if(yg1<yg)
     {
       dh1++;
       if(dh1>30) {dh1=dh1-30;mh1++;}
       if(dh1==30)
       {
	dh2=1;mh2=mh1+1;yh2=yh1;
	if(mh2>12) {yh2++;mh2=mh2-12;}
	flag=H2GA(ref yh2,ref mh2,ref dh2,ref yg2,ref mg2,ref dg2,ref dayweek);
	if(dg2==dg) {mh1++;dh1=1;}    /* check to see that if 30 is actually 1st of next month */
       }
     }

   if(yg1==yg)
   {
    if(mg1>mg)
     {
       dh1--;
       if(dh1<1) {dh1=29+dh1;mh1--;}
     }

    if(mg1<mg)
     {
       dh1++;
       if(dh1>30) {dh1=dh1-30;mh1++;}
       if(dh1==30)
       {
	dh2=1;mh2=mh1+1;yh2=yh1;
	if(mh2>12) {yh2++;mh2=mh2-12;}
	flag=H2GA(ref yh2,ref mh2,ref dh2,ref yg2,ref mg2,ref dg2,ref dayweek);
	if(dg2==dg) {mh1++;dh1=1;}    /* check to see that if 30 is actually 1st of next month */
       }
     }

    if(mg1==mg && yg1==yg)   /* if the months are equal than adjust the days */
     {
      found=1;
      if(dg1>dg)
	{dh1=dh1-(dg1-dg);found=0;}
      if(dg1<dg)
	{dh1=dh1-(dg1-dg);found=0;}
      if(dh1<1)
	{dh1=29+dh1;mh1--;}
      if(dh1>30)
	{dh1=dh1-30;mh1++;}
      if(dh1==30)
       {
	dh2=1;mh2=mh1+1;yh2=yh1;
	if(mh2>12) {yh2++;mh2=mh2-12;}
	flag=H2GA(ref yh2,ref mh2,ref dh2,ref yg2,ref mg2,ref dg2,ref dayweek);
	if(dg2==dg) {mh1++;dh1=1;}    /* check to see that if 30 is actually 1st of next month */
       }
     }
    }

    if(mh1<1) {yh1--;mh1=12+mh1;}
    if(mh1>12) {yh1++;mh1=mh1-12;}

   }
  J= Convert.ToInt64(Math.Truncate(( (GCalendarToJD(yg,mg,dg)+2))));
  dayweek=Convert.ToInt32(J%7);
  yh=yh1;
  mh=mh1;
  dh=dh1;


  return flag;



}
/****************************************************************************/
/* Name:    H2GA                                                            */
/* Type:    Procedure                                                       */
/* Purpose: convert Hdate(year,month,day) to Gdate(year,month,day)          */
/* Arguments:                                                               */
/* Input/Ouput: Hijrah  date: year:yh, month:mh, day:dh                     */
/* Output: Gregorian date: year:yg, month:mg, day:dg , day of week:dayweek  */
/*       and returns flag found:1 not found:0                               */
/* Note: The function will correct Hdate if day=30 and the month is 29 only */
/****************************************************************************/
 private static int  H2GA(ref int yh,ref int mh,ref int dh, ref int yg,ref int mg, ref int dg,ref int dayweek)
{
    int found,yh1=0,mh1=0,yg1=0,mg1=0,dg1=0,dw1=0;
	 /*find the date of the begining of the month*/
    /* make sure values are within the allowed values */
    if(dh>30) {dh=1;(mh)++;}
    if(dh<1)  {dh=1;(mh)--;}
    if(mh>12) {mh=1;(yh)++;}
    if(mh<1)  {mh=12;(yh)--;}

    found=BH2GA(yh,mh,ref yg,ref mg,ref dg,ref dayweek);
    dg=dg+dh-1;
    GDateAjust(ref yg,ref mg,ref dg);    /* Make sure that dates are within the correct values */
    dayweek=dayweek+dh-1;
    dayweek=dayweek%7;

	 /*find the date of the begining of the next month*/
   if(dh==30)
   {
    mh1=mh+1;
    yh1=yh;
    if(mh1>12) {mh1=mh1-12;yh1++;}
    found=BH2GA(yh1,mh1,ref yg1,ref mg1,ref dg1,ref dw1);
    if(dg==dg1) {yh=yh1;mh=mh1;dh=1;}  /* Make sure that the month is 30days if not make adjustment */
   }

   return found;
}
/****************************************************************************/
/* Name:    S2G                                                             */
/* Type:    Procedure                                                       */
/* Purpose: convert SHdate(year,month,day) to Gdate(year,month,day)         */
/* Arguments:                                                               */
/* Input:  Solar Hijrah  date: year:ys, month:ms, day:ds                    */
/* Output: Gregorian date: year:yg, month:mg, day:dg                        */
/****************************************************************************/
 private static void S2G(int ys,int ms,int ds,ref int yg,ref int mg,ref int dg)
{
   double SJD;
    SJD=SCalendarToJD(ys,ms,ds);
   JDToGCalendar(SJD,ref yg,ref mg,ref dg);

}
/****************************************************************************/
/* Name:    G2S                                                             */
/* Type:    Procedure                                                       */
/* Purpose: convert Gdate(year,month,day) to SHdate(year,month,day)         */
/* Arguments:                                                               */
/* Input: Gregorian date: year:yg, month:mg, day:dg                         */
/* Ouput: Solar Hijrah  date: year:ys, month:ms, day:ds                     */
/****************************************************************************/
 private static void G2S(int yg, int mg, int dg, ref int ys, ref int ms, ref int ds)
{
   double SJD;

    SJD=GCalendarToJD(yg,mg,dg+0.5);
    JDToSCalendar(SJD,ref ys,ref ms,ref ds);

}
/****************************************************************************/
/* Name:    JDToGCalendar						    */
/* Type:    Procedure                                                       */
/* Purpose: convert Julian Day  to Gdate(year,month,day)                    */
/* Arguments:                                                               */
/* Input:  The Julian Day: JD                                               */
/* Output: Gregorian date: year:yy, month:mm, day:dd                        */
/****************************************************************************/
 private static double JDToGCalendar(double JD, ref int yy, ref int mm, ref int dd)
{
double A, B, F;
int alpha, C, E;
long D, Z;

  Z = (long) Math.Floor (JD + 0.5);
  F = (JD + 0.5) - Z;
  alpha = (int)((Z - 1867216.25) / 36524.25);
  A = Z + 1 + alpha - alpha / 4;
  B = A + 1524;
  C = (int) ((B - 122.1) / 365.25);
  D = (long) (365.25 * C);
  E = (int) ((B - D) / 30.6001);
  dd = Convert.ToInt32(Math.Truncate(B - D - Math.Floor(30.6001 * E) + F));
  if (E < 14)
    mm = E - 1;
  else
    mm = E - 13;
  if (mm > 2)
    yy = C - 4716;
  else
   yy = C - 4715;

  F=F*24.0;
  return F;
}
/****************************************************************************/
/* Name:    GCalendarToJD						    */
/* Type:    Function                                                        */
/* Purpose: convert Gdate(year,month,day) to Julian Day            	    */
/* Arguments:                                                               */
/* Input : Gregorian date: year:yy, month:mm, day:dd                        */
/* Output:  The Julian Day: JD                                              */
/****************************************************************************/
 private static double GCalendarToJD(int yy, int mm, double dd)
{        /* it does not take care of 1582correction assumes correct calender from the past  */
int A, B, m, y;
double T1,T2,Tr;
  if (mm > 2) {
    y = yy;
    m = mm;
    }
  else {
    y = yy - 1;
    m = mm + 12;
    }
  A = y / 100;
  B = 2 - A + A / 4;
  T1=ip (365.25 * (y + 4716));
  T2=ip (30.6001 * (m + 1));
  Tr=T1+ T2 + dd + B - 1524.5 ;

  return Tr;
}
/****************************************************************************/
/* Name:    GLeapYear						            */
/* Type:    Function                                                        */
/* Purpose: Determines if  Gdate(year) is leap or not            	    */
/* Arguments:                                                               */
/* Input : Gregorian date: year				                    */
/* Output:  0:year not leap   1:year is leap                                */
/****************************************************************************/
 private static int GLeapYear(int year)
{

  int T;

     T=0;
     if(year%4==0) T=1; /* leap_year=1; */
     if(year%100==0)
       {
	 T=0;        /* years=100,200,300,500,... are not leap years */
	 if(year%400==0) T=1;  /*  years=400,800,1200,1600,2000,2400 are leap years */
       }

  return T;

}
/****************************************************************************/
/* Name:    GDateAjust							    */
/* Type:    Procedure                                                       */
/* Purpose: Adjust the G Dates by making sure that the month lengths        */
/*	    are correct if not so take the extra days to next month or year */
/* Arguments:                                                               */
/* Input: Gregorian date: year:yg, month:mg, day:dg                         */
/* Output: corrected Gregorian date: year:yg, month:mg, day:dg              */
/****************************************************************************/
 private static void GDateAjust(ref int yg, ref int mg, ref int dg)
{
   int dys;

   /* Make sure that dates are within the correct values */
	  /*  Underflow  */
	 if(mg<1)  /* months underflow */
	  {
	   mg=12+mg;  /* plus as the underflow months is negative */
	   yg=yg-1;
	  }

	 if(dg<1)  /* days underflow */
	  {
	   mg= mg-1;  /* month becomes the previous month */
	   dg=gmonth[mg]+dg; /* number of days of the month less the underflow days (it is plus as the sign of the day is negative) */
	   if(mg==2) dg=dg+GLeapYear(yg);
	   if(mg<1)  /* months underflow */
	    {
	     mg=12+mg;  /* plus as the underflow months is negative */
	     yg=yg-1;
	    }
	  }

	  /* Overflow  */
	 if(mg>12)  /* months */
	  {
	   mg=mg-12;
	   yg=yg+1;
	  }

	 if(mg==2)
	     dys=gmonth[mg]+GLeapYear(yg);  /* number of days in the current month */
	   else
	     dys=gmonth[mg];
	 if(dg>dys)  /* days overflow */
	  {
	     dg=dg-dys;
	     mg=mg+1;
	    if(mg==2)
	     {
	      dys=gmonth[mg]+GLeapYear(yg);  /* number of days in the current month */
	      if(dg>dys)
	       {
		dg=dg-dys;
		mg=mg+1;
	       }
	     }
	    if(mg>12)  /* months */
	    {
	     mg=mg-12;
	     yg=yg+1;
	    }

	  }


}
/*
  The day of the week is obtained as
  Dy=(Julian+1)%7
  Dy=0 Sunday
  Dy=1 Monday
  ...
  Dy=6 Saturday
*/

 private static int DayWeek(long JulianD)
{
  int Dy;
  Dy=Convert.ToInt32((JulianD+1)%7);

  return Dy;
}
/****************************************************************************/
/* Name:    HSLeapYear						            */
/* Type:    Function                                                        */
/* Purpose: Determines of  HSdate(year) is leap or not            	    */
/* Arguments:                                                               */
/* Input : Hijrah Solar date: year			                    */
/* Output:  0:year not leap   1:year is leap                                */
/****************************************************************************/
 private static int HSLeapYear(long year)
{ /* Leap year test for hijrah solar years */
  int r1,r2,r3;

  if(year==0) return 0;  /* not leap year */

  r1=mod(year,128);
  r2=mod(r1,4);


  if(r1==0) return 0;   /*  year is not leap */
  if(r2==0) return 1;   /* year is leap      */

  return 0;

}
/****************************************************************************/
/* Name:    SCalendarToJD						    */
/* Type:    Function                                                        */
/* Purpose: convert Sdate(year,month,day) to Julian Day            	    */
/* Arguments:                                                               */
/* Input : Hijrah Solar date: year:ys, month:ms, day:ds                     */
/* Output:  The Julian Day: JD                                              */
/****************************************************************************/
 private static double SCalendarToJD(int ys, int ms, double ds)
{
 /*
  Given Solar Hijrah date find  JD
 */
  int a,b,m6;
  double T1,T2 = 0,Tr;

  a=(ys-1)/128;
  b=(ys-1)/4;
  b=b-a;
  T1=(ys-1)*365.0+b+ds;
  m6=29+HSLeapYear(ys);
  if(ms<7) T2=30*(ms-1);
  if(ms==7) T2=30.0*5+m6;
  if(ms>7) T2=30.0*5+m6+31*(ms-7);
  Tr=T1+T2+1948506.0;  /*  Add JD for 23/9/622 the first Solar Hijrah date*/

  return Tr;


}
/****************************************************************************/
/* Name:    JDToSCalendar						    */
/* Type:    Procedure                                                       */
/* Purpose: convert Julian Day to Sdate(year,month,day)  		    */
/* Arguments:                                                               */
/* Input:  The Julian Day: JD                                               */
/* Output : Solar Hijrah date: year:ys, month:ms, day:ds                    */
/****************************************************************************/
 private static void JDToSCalendar(double JD, ref int ys, ref int ms, ref int ds)
{
 /*
   From JD day find Solar Hijrah date
 */
 int r1,r2,m6;
 double J,dd;

 J=JD-1948506;   /*  substract JD for 23/9/622 the first Solar Hijrah date*/
 ys = Convert.ToInt32(Math.Truncate(J / 365));
 (ys)--;
 r1=(ys-mod(ys,128))/128;  /* Find the number of non-leap years divisible by 4*/
 r2=(ys-mod(ys,4))/4;    /* Find the number of leap years */
 J=J-(r2-r1);
 ys=Convert.ToInt32(Math.Truncate(J/365));
 dd=J- ys*365.0;
 ds=Convert.ToInt32(Math.Truncate(dd));
 (ys)++;
 if(ds<1) {(ys)--;ds=ds+365;}
 ms=1;
 while(ds>30 && ms<6)
 {
   (ms)++;
   ds=ds-30;
 }
 m6=29+HSLeapYear(ys);
 if(ds>m6 && ms==6) {(ms)++;ds=ds-m6;}
 while(ds>31)
  {
   (ms)++;
   ds=ds-31;
 }
 if(ds==0) (ds)++;

}
/****************************************************************************/
/* Name:    SDateAjust							    */
/* Type:    Procedure                                                       */
/* Purpose: Adjust the S Dates by making sure that the month lengths        */
/*	    are correct if not so take the extra days to next month or year */
/* Arguments:                                                               */
/* Input: Hijrah Solar date: year:ys, month:ms, day:ds                      */
/* Output: corrected Hijrah Solar date: year:ys, month:ms, day:ds           */
/****************************************************************************/
 private static void SDateAjust(ref int ys, ref int ms, ref int ds)
{
   /*
     Adjust Solar Hijrah Dates
   */
   int dys;

   /* Make sure that dates are within the correct values */
	  /*  Underflow  */
	 if(ms<1)  /* months underflow */
	  {
	   ms=12+ms;  /* plus as the underflow months is negative */
	   ys=ys-1;
	  }

	 if(ds<1)  /* days underflow */
	  {
	   ms=ms-1;  /* month becomes the previous month */
	   ds=smonth[ms]+ds; /* number of days of the month less the underflow days (it is plus as the sign of the day is negative) */
	   if(ms==6) ds=ds+HSLeapYear(ys);
	   if(ms<1)  /* months underflow */
	    {
	     ms=12+ms;  /* plus as the underflow months is negative */
	     ys=ys-1;
	    }
	  }

	  /* Overflow  */
	 if(ms>12)  /* months */
	  {
	   ms=ms-12;
	   ys=ys+1;
	  }

	 if(ms==6)
	     dys=smonth[ms]+HSLeapYear(ys);  /* number of days in the current month */
	   else
	     dys=smonth[ms];
	 if(ds>dys)  /* days overflow */
	  {
	     ds=ds-dys;
	     ms=ms+1;
	    if(ms>12)  /* months */
	    {
	      ms=ms-12;
	      ys=ys+1;
	    }
	  }


}
/****************************************************************************/
/* Name:    HCalendarToJD						    */
/* Type:    Function                                                        */
/* Purpose: convert Hdate(year,month,day) to estimated Julian Day     	    */
/* Arguments:                                                               */
/* Input : Hijrah  date: year:yh, month:mh, day:dh                          */
/* Output:  The Estimated Julian Day: JD                                    */
/****************************************************************************/
 private static double HCalendarToJD(int yh, int mh, int dh)
{
 /*
   Estimating The JD for hijrah dates
   this is an approximate JD for the given hijrah date
 */
 double md,yd;
 md=(mh-1.0)*29.530589;
 yd=(yh-1.0)*354.367068+md+dh-1.0;
 yd=yd+1948439.0;  /*  add JD for 18/7/622 first Hijrah date */

 return yd;
}
/****************************************************************************/
/* Name:    JDToHCalendar						    */
/* Type:    Procedure                                                       */
/* Purpose: convert Julian Day to estimated Hdate(year,month,day)	    */
/* Arguments:                                                               */
/* Input:  The Julian Day: JD                                               */
/* Output : Hijrah date: year:yh, month:mh, day:dh                          */
/****************************************************************************/
 private static void JDToHCalendar(double JD, ref int yh, ref int mh, ref int dh)
{
 /*
   Estimating the hijrah dates from JD
 */
 double md,yd;

 yd=JD-1948439.0;  /*  subtract JD for 18/7/622 first Hijrah date*/
 md=mod(yd,354.367068);
 dh=mod(md+0.5,29.530589)+1;
 mh=Convert.ToInt32(Math.Truncate((md/29.530589)+1));
 yd=yd-md;
 yh = Convert.ToInt32(Math.Truncate(yd / 354.367068 + 1));
 if(dh>30) {dh=dh-30;(mh)++;}
 if(mh>12) {mh=mh-12;(yh)++;}

}
/**************************************************************************/
 private static double ip(double x)
{ /* Purpose: return the integral part of a double value.     */
  //  double  tmp;

  // modf(x, &tmp);
  //return tmp;
    double result = Math.Truncate(x);
    return result;
}
/**************************************************************************/
/*
  Name: mod
  Purpose: The mod operation for doubles  x mod y
*/
 private static int mod(double x, double y)
{
  int r;
  double d;

  d=x/y;
  r = Convert.ToInt32(Math.Truncate(d));
  if(r<0) r--;
  d=x-y*r;
  r = Convert.ToInt32(Math.Truncate(d));
 return r;
}
/**************************************************************************/
/**************************************************************************/
/**************************************************************************/
/*              Modified Solar Hijrah Years                               */
/**************************************************************************/
 private static int HMSLeapYear(long year)
{ /* Leap year test for hjirah Modified solar years */
  int Leap;

  Leap = GLeapYear(Convert.ToInt32(year + 622));  // Leap year the same time as  Gyear leaps

  return Leap;

}
 private static double MSCalendToJD(double ys, int ms, int ds)
{
 /*
  Given Solar Hijrah date find  JD
 */
  int a,b,c,m6;
  double T1,T2=0,Tr,yg;

  yg=ys+622;
  a=Convert.ToInt32(Math.Truncate((yg-1)/100));
  b=Convert.ToInt32(Math.Truncate((yg-1)/4));
  c = Convert.ToInt32(Math.Truncate((yg - 1) / 400));
  b=b+c-a-151;
  T1=(ys-1)*365.0+b+ds;
  m6=29+HMSLeapYear(Convert.ToInt64(Math.Truncate((ys))));
  if(ms<7) T2=30*(ms-1);
  if(ms==7) T2=30.0*5+m6;
  if(ms>7) T2=30.0*5+m6+31*(ms-7);
  Tr=T1+T2+1948506.0;

  return Tr;


}
 private static void JDToMSCalend(double JD, ref int ys, ref int ms, ref int ds)
{
 /*
   From JD day find Solar Hijrah date
 */
 int r1,r2,r3,m6;
 double J,dd,yg;

 J=JD-1948506;   /* substract JD for 23/9/622 */
 ys=Convert.ToInt32(Math.Truncate(J/365));
 (ys)--;
 yg=ys+622;
 r1=Convert.ToInt32(Math.Truncate((yg-mod(yg,400))/400));
 r2=Convert.ToInt32(Math.Truncate((yg-mod(yg,4))/4));
 r3=Convert.ToInt32(Math.Truncate((yg-mod(yg,100))/100));
 J=J-(r2+r1-r3)+151;   /* 151=number of leap days in 622years */
 ys = Convert.ToInt32( Math.Truncate (J / 365));//double to Int32
 dd=J-ys*365.0;
 if(dd<32) dd=dd-HMSLeapYear(ys);
 ds=(int)dd;
 (ys)++;
 if(ds<1) {(ys)--;ds=ds+365;}
 ms=1;
 while((ds)>30 && (ms)<6)
 {
   (ms)++;
   ds=ds-30;
 }
 m6=29+HMSLeapYear(ys);
 if(ds>m6 && ms==6) {(ms)++;ds=ds-m6;}
 while(ds>31 && ms>6)
  {
   (ms)++;
   ds=ds-31;
 }
 if(ds==0) (ds)++;

}
 private static void MS2G(int ys, int ms, int ds, ref int yg, ref int mg, ref int dg)
{
   double SJD;
  // int h,m,s; not used
   SJD=MSCalendToJD(ds,ms,ys);
   JDToGCalendar(SJD,ref yg,ref mg,ref dg);

}

 private static void G2MS(int yg, int mg, int dg, ref int ys, ref int ms, ref int ds)
{
   double SJD;

    SJD=GCalendarToJD(yg,mg,dg+0.5);
    JDToMSCalend(SJD,ref ys,ref ms,ref ds);

}

    }}
