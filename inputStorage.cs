using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
	public class inputStorage
	{
		public string RecipeName{set; get;}
		public string IngredName { set; get; }
		public double IngredQuantity { set; get; }
		public string UnitfMeasurement { set; get; }
		public string FoodGroup { set; get; }
		public double Calaries { set; get; }
		public string steps { set; get; }

		//public inputStorage() { }
		public inputStorage(string recipename,string ingredname,double ingredquan,string unitofmeasurement,string foodgroup,double calaries,string step)
		{
			this.RecipeName = recipename;
			this.IngredName = ingredname;	
			this.IngredQuantity = ingredquan;
			this.UnitfMeasurement = unitofmeasurement;
			this.FoodGroup = foodgroup;
			this.Calaries = calaries;
			this.steps = step;
		}

	}
}
