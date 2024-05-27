using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BAR
{
    public class Barman
    {
		private string _nom;	// nom du Barman

		public string Nom
		{
			get { return _nom; }
		}
		public Barman(string nom)
		{
			_nom = nom;
		}
		/// <summary>
		/// Récupérer le numéro de la recette du cocktail désiré par le client
		/// </summary>
		/// <param name="menu">liste des noms des cocktails disponibles</param>
		/// <param name="nbRecettes"> nombre de recettes à disposition</param>
		/// <returns>entier : numéro du cocktail désiré (entre 1 et nbRecettes)</returns>
		public int Commander(string menu, int nbRecettes)
		{
			string choixUser;
			int numeroCocktail;
			do		//vérification de l'intervalle de valeurs attendues
			{
                do		//Lecture d'un entier
                {
                    Console.WriteLine("Choisissez un cocktail dans le menu suivant : (tapez le numéro de la recette)");
					Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine(menu);
                    choixUser = Console.ReadLine();
                } while (!int.TryParse(choixUser, out numeroCocktail));
            } while (numeroCocktail < 0 || numeroCocktail > nbRecettes);
			
			return numeroCocktail;
		}
		/// <summary>
		/// Réaliser la fabrication complète du cocktail et renvoyer vrai si fait, sinon renvoyer faux
		/// </summary>
		/// <param name="cocktail">cocktail choisi</param>
		/// <param name="shaker">shaker à utiliser pour constituer le mélange</param>
		/// <param name="monBar">bar pour y prendre les bouteilles</param>
		/// <returns>renvoyer vrai si cocktail est réalisé, faux, sinon</returns>
		public bool Fabriquer(Cocktail cocktail, ref Shaker shaker, Bar monBar)
		{
			bool ok = true;
			// parcours des ingrédients de la recette
			foreach (Portion portion in cocktail.RecetteCocktail.Ingredients)
			{
				Liquide ingredient = portion.Contenu;
                int numeroBouteille;
				// si bouteille présente
                if (monBar.PrendreBouteille(ingredient, out numeroBouteille))
				{
					//Affichage pour vérification
					//Console.WriteLine("Quantite dans bouteille :" + monBar.Bouteilles[numeroBouteille].Contenance);
					//Console.WriteLine("quantite à prendre : " + portion.Quantite * 0.2d);

					// vérification de la possibilité de verser la portion dans le shaker et qu'il y a assez de liquide dans la bouteille pour le faire
					if(portion.TesterPortion(shaker, monBar.Bouteilles[numeroBouteille]))
					{
						monBar.Bouteilles[numeroBouteille].Verser(portion);
						shaker.AjouterPortion(portion);
						Console.WriteLine("--> " + ingredient.Nom + " ajouté ");
					}
					else
					{
                        Console.WriteLine("\n!!! --> Il n'y a plus suffisamment de liquide dans votre bouteille de " + monBar.Bouteilles[numeroBouteille].Contenu.Nom + "!");
						Console.WriteLine(monBar.Bouteilles[numeroBouteille].Jeter(monBar.Bouteilles[numeroBouteille]));
						// aller chercher à la cave => à programmer
						ok = false;
                    }
                }
				else
				{
					Console.WriteLine("Il n'y a plus de " + ingredient.Nom + " dans le bar !");
					// aller chercher à la cave
					ok = false;
				}
			}
			return ok;
		}
		/// <summary>
		/// Cree la chaine de caractère qui permet de savoir qu'on est servi ou pas
		/// </summary>
		/// <param name="cocktail">Le cocktail créé</param>
		/// <param name="fabricationOk">état de la fabrication (vrai si on a su aller jusqu'au bout de la fabrication</param>
		/// <param name="shaker">shaker employé</param>
		/// <returns></returns>
		public string Servir(Cocktail cocktail, bool fabricationOk, ref Shaker shaker) 
		{
			string chaine = "";
			if (fabricationOk)
			{
				chaine = " Voici votre " + cocktail.Nom;
			}
			else
			{
				chaine = "Nous avons rencontré un problème lors de la fabrication de votre coktail ";
			}
			shaker.Vider();
			return chaine;
		}
	}
}
