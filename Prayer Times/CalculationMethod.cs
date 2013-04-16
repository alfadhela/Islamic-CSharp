using System;

namespace org.tamrah.islamic.pray
{
	public class  CalculationMethod
	{

		public enum  CalculationMethodM {Jafari,Karachi,ISNA,MWL,Makkah,Egypt,Custom,Tehran};


		//private enum Jafari;
		/*
		public enum Jafari     = 0;    // Ithna Ashari
		public enum Karachi    = 1;    // University of Islamic Sciences, Karachi
		public enum ISNA       = 2;    // Islamic Society of North America (ISNA)
		public enum MWL        = 3;    // Muslim World League (MWL)
		public enum Makkah     = 4;    // Umm al-Qura, Makkah
		public enum Egypt      = 5;    // Egyptian General Authority of Survey
		public enum Custom     = 6;    // Custom Setting
		public  static int Tehran     = 7;    // Institute of Geophysics, University of Tehran
        */
		// Custom Setting
			private int id;
			private CalculationMethod(int id) {
				this.id = id;
			}
			public int getId() {
				return id;
			}
	    	public static CalculationMethodM get(int id){
				switch (id) {
				case 0:
				return CalculationMethodM.Jafari;
				case 1:
				return CalculationMethodM.Karachi;
				case 2:
				return CalculationMethodM.ISNA;
				case 3:
				return CalculationMethodM.MWL;
				case 4:
				return CalculationMethodM.Makkah;
				case 5:
				return CalculationMethodM.Egypt;
				case 6:
				return CalculationMethodM.Tehran;
				default:
				return CalculationMethodM.Custom;
				}
			}
	}
}
