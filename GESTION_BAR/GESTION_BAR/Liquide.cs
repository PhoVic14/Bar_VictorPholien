using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Liquide
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}
		private string _type;

		public string Type
		{
			get { return _type; }
		}
		public Liquide(string nom, string type)
		{
			_nom = nom;
			_type = type;
		}
		

	}
}
