using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearn
{
	internal class Program
	{
		//	Delegate -> function pointer -> callback method 
		//	Delegate (C#) -> Interface 
		//	 Anonomious function,
		//	 Anonomious Object
		//	 

		//public static void Main(string[] args)
		public delegate string Add(int a,float b);
		public delegate O Func<in T, out O>(T a);
		public delegate O Func<in T1,in T2,  out O>(T1 a,T2 b);


		public delegate bool Predicate<in T1, in T2>(T1 a, T2 b);

		public delegate void Action<in T1, in T2>(T1 a, T2 b);
		static void Main(string[] args)
		{ 


		Data dd= new Data();
			Show(XYZ);
			//Show(dd.DataX);

			//Show((x, y) => "a") ;
			Add add = XYZ;
			//add.Invoke()
			add(2, 3.0f);
		int[] arr = {1,2,4,5,6,7};
		var data=	arr.Select(x => new { id = x }).ToList();
					// arr.Where(Func)
			Console.WriteLine("I am in");
			
		}


		static string XYZ(int a, float b)
		{
			return "abc";
		}

		public static void Show(Add d)
		{
			d(1, 2.0f);
		}

	}

	public class Data
	{
		public string DataX(int a, float b)
		{
			return "abc";
		}
	}
}
