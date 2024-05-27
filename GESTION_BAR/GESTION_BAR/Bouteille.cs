using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public  class Bouteille 
    {
        
        private Liquide _contenu;

		public Liquide Contenu
		{
			get { return _contenu; }
			set { _contenu = value; }
		}
		private double _contenance;	//en litre

		public double Contenance
		{
			get { return _contenance; }
			set { _contenance = value; }
		}
		public Bouteille(Liquide liquide, double contenance) 
		{
			_contenu = liquide;
			_contenance = contenance;
		}
		/// <summary>
		/// déduction de la quantité d'une portion de liquide dans la bouteille
		/// </summary>
		/// <param name="portion">portion déduite</param>
		public void Verser(Portion portion)
		{
			_contenance -= portion.Quantite * Constantes.VOLUME_COCKTAIL;   
		}
		/// <summary>
		/// destruction de la bouteille (vérifier pour pb destructeur sur 'this')
		/// </summary>
		/// <param name="bouteille"></param>
		/// <returns></returns>
		 public string Jeter(Bouteille bouteille)
		{
            string chaine =  "La bouteille de " + bouteille.Contenu.Nom + " a été mise à la poubelle.";
            bouteille = null;
			return chaine;
        }
	}
}
