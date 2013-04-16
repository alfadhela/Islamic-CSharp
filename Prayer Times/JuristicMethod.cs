using System;
namespace org.tamrah.islamic.pray
{
	public class JuristicMethod
	{
		/*
		public static readonly JuristicMethod Shafii = new JuristicMethod(0); 		// Shafii (standard)
		public static readonly JuristicMethod Hanafi=new JuristicMethod(0);    // Hanafi
        */
		public enum JuristicMethodM {Shafii=0,Hanafi};
		private int id;
		private JuristicMethod(int id) {
			this.id = id;
		}
		public int getId() {
			return id;
		}
	public static JuristicMethodM get(int id){
			switch (id) {
			case 1:
				return JuristicMethodM.Hanafi;
			default:
				return JuristicMethodM.Shafii;
			}
		}
	}
	}
