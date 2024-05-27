using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Portion
    {

        private Liquide _contenu;

		public Liquide Contenu
		{
			get { return _contenu; }
		}
		private double _quantite;	// pourcentage du verre dans la recette

		public double Quantite
		{
			get { return _quantite; }
			set { _quantite = value; }
		}
		public Portion(Liquide liquide, double quantite)
		{
			_contenu = liquide;
			_quantite = quantite;	
		}
		/// <summary>
		/// Vérification de la place disponible dans le shaker et du liquide disponible dans la bouteille  => renvoi d'un booléeen
		/// vrai si ajout de portion disponible
		/// </summary>
		/// <param name="shaker">shaker employé</param>
		/// <param name="bouteille">bouteille prise sur le bar</param>
		/// <returns></returns>
		public bool TesterPortion(Shaker shaker, Bouteille bouteille)
		{
			bool ok = false;
            if ((shaker.ContenanceMax >= (shaker.CalculQuantiteContenu() + this.Quantite * Constantes.VOLUME_COCKTAIL)) && this.Quantite * Constantes.VOLUME_COCKTAIL <= bouteille.Contenance)
			{
				ok = true;
			}
            return ok;
		}
	}
}
