using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public  class Bar
    {
		private List<Bouteille> _bouteilles;

		public List<Bouteille> Bouteilles
		{
			get { return _bouteilles; }
			set { _bouteilles = value; }
		}
		public Bar(List<Bouteille> bouteilles)
		{
			_bouteilles = new List<Bouteille>();
			Bouteilles = bouteilles;		// vérifier si pointeur ou nécéssité de copier élément par élément
		}
		public bool PrendreBouteille(Liquide liquide, out int placeBouteille)
		{
			bool trouve = false;
			placeBouteille = -1;
			int i = 0;
			while ( i < Bouteilles.Count && !trouve)
			{
				if (Bouteilles[i].Contenu == liquide)
				{
					trouve = true;
					placeBouteille = i;
				}	
				i++;
			}
			return trouve;
		}
		public bool AjouterBouteille(Bouteille bouteille)
		{
			bool ok = false;
			Bouteilles.Add(bouteille);
			return ok;
		}
		public string AfficheInventaireBar()
		{
			string chaine = "Liste des bouteilles disponibles : \n";
			foreach (Bouteille bouteille in Bouteilles)
			{
				chaine += " Une bouteille de " + bouteille.Contenu.Nom + " contenant " + bouteille.Contenance + "cl\n";
			}
			return chaine;
		}
	}
}
