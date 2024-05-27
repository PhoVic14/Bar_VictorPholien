using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Shaker
    {
        
        private double _contenanceMax;

		public double ContenanceMax
		{
			get { return _contenanceMax; }
		}
		private List<Portion> _contenu;

		public List<Portion> Contenu
		{
			get { return _contenu; }
			set { _contenu = value; }
		}
		private bool _propre;

		public bool Propre
		{
			get { return _propre; }
			set { _propre = value; }
		}
		public Shaker(double contenanceMax)
		{
			_contenanceMax = contenanceMax;
			_contenu = new List<Portion>();
			_propre = true;
		}
		public double CalculQuantiteContenu()
		{
			double quantite = 0;
			foreach (Portion contenu in _contenu)
			{
				quantite += contenu.Quantite * Constantes.VOLUME_COCKTAIL;
			}
			return quantite;
		}
		public void AjouterPortion(Portion portion) 
		{
                _contenu.Add(portion);
                _propre = false;	
		}
		public string MelangerContenu()
		{
			return "Shaker secoué => Contenu mélangé !";
		}
		public void Vider()
		{
			_contenu = new List<Portion>();
			_propre = true;
		}
		public string Laver()
		{
			Propre = true;
			return " Votre shaker est propre, il vient d'être lavé .";
		}
	}
}
