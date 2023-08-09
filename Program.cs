using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjetPIZZA
{
    
    class Pizza
    {
        string nom;
        float prix;
        bool vegetarienne = false;
        List<string> ingredients;

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }

        public void AfficherPizza()
        {
            string badgeVege = " (V)";
            if (!vegetarienne) { badgeVege = ""; }
            Console.WriteLine(FormatMots(nom) + badgeVege + " - " + prix + "€");

            List<string> ingredientsForm = new List<string>(ingredients);
            for (int i = 0; i < ingredientsForm.Count; i++) 
            {
                ingredientsForm[i] = FormatMots(ingredients[i]);
            }

            Console.WriteLine(string.Join(", ", ingredientsForm));
            Console.WriteLine();
        }

        private static string FormatMots(string nom)
        {
            if (string.IsNullOrEmpty(nom)) { return nom; }

            string majuscules = nom.ToUpper();
            string minuscules = nom.ToLower();
            string nomFormat = majuscules[0] + minuscules.Substring(1);

            return nomFormat;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var listePizzas = new List<Pizza>();
            listePizzas.Add(new Pizza("Margherita", 7, true, new List<string>() {"tomate", "mozzarella", "basilic"}));
            listePizzas.Add(new Pizza("Reine", 8.5f, false, new List<string>() { "tomate", "mozzarella", "champignon", "jambon" }));
            listePizzas.Add(new Pizza("Calzone", 9.5f, false, new List<string>() { "tomate", "mozzarella", "jambon", "basicil" }));
            listePizzas.Add(new Pizza("4 fromages", 10.5f, true, new List<string>() { "tomate", "mozzarella", "raclette", "parmesan", "roquefort" }));
            listePizzas.Add(new Pizza("TARTiflette", 12, false, new List<string>() { "crème", "raclette", "lardons", "patates" }));
            listePizzas.Add(new Pizza("veggie", 11, true, new List<string>() { "tomate", "mozzarella", "basicil", "roquette", "capres" }));

            foreach (var pizza in listePizzas)
            {
                pizza.AfficherPizza();
            }
        }
    }
}