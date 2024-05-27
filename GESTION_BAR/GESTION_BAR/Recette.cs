using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Recette
    {
		private List<Portion> _ingredients;

		public List<Portion> Ingredients
		{
			get { return _ingredients; }
			set { _ingredients = value; }
		}
		public Recette(List<Portion> ingredients)
		{
			_ingredients = new List<Portion>();
			_ingredients = ingredients;
		}
		
	}
}
