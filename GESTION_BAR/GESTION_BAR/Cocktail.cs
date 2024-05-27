using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Cocktail
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}

		private Recette _recetteCocktail;

		public Recette RecetteCocktail
		{
			get { return _recetteCocktail; }
			set { _recetteCocktail = value; }
		}
		public Cocktail(string nom, Recette recetteCocktail)
		{
			_nom = nom;
			_recetteCocktail = recetteCocktail;
		}
		
        public string AfficherRecette()
        {
            string chaine = "Recette du " + Nom + " : \n";
            for (int i = 0; i < RecetteCocktail.Ingredients.Count; i++)
            {
                chaine += RecetteCocktail.Ingredients[i].Quantite + " de " + RecetteCocktail.Ingredients[i].Contenu.Nom + "\n";
            }
            return chaine;
        }
		
		public double CalculContenance()
		{
			double contenance = 0;
			foreach (Portion ingredient in RecetteCocktail.Ingredients)
			{
				contenance += ingredient.Quantite;
            }
			return contenance;
		}
    }
}
