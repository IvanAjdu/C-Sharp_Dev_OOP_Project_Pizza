using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjetPIZZA
{
    class PizzaPersonnalisee : Pizza
    {
        static int indexPizza = 1;
        public PizzaPersonnalisee() : base ("Personnalisée", 5, false, null)
        {
            nom = "Pizza Personnalisée " + indexPizza;
            ingredients = new List<string>();
            DemanderIngredients();
            indexPizza++;
        }
        public List<string> DemanderIngredients()
        {
            while (true)
            {
                Console.Write("Veuillez entrer un ingrédient de votre pizza personnalisée " + indexPizza + " (ENTER pour arreter) : ");
                string ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    return ingredients;
                }
                else 
                {
                    if (ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("Vous avez déjà ajouté cet ingredient. Veuillez en choisir un nouveau.");
                    }
                    else
                    {
                        ingredients.Add(ingredient);
                        Console.WriteLine(FormatMots(string.Join(", ", ingredients)));
                        prix = prix + 1.5f;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    class Pizza
    {
        protected string nom;
        public float prix { get; protected set; }
        bool vegetarienne = false;
        public List<string> ingredients { get; protected set;}

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
            Console.WriteLine(FormatMots(nom) + badgeVege + " - " + prix +  "€");

            var ingredientsAfficher = ingredients.Select(x => FormatMots(x)).ToList();

            Console.WriteLine(string.Join(", ", ingredientsAfficher));
            Console.WriteLine();
        }

        protected static string FormatMots(string nom)
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

            var Pizzas = new List<Pizza>();
            Pizzas.Add(new Pizza("Margherita", 7, true, new List<string>() { "tomate", "mozzarella", "basilic" }));
            Pizzas.Add(new Pizza("reine", 10f, false, new List<string>() { "tomate", "mozzarella", "champignon", "jambon" }));
            Pizzas.Add(new Pizza("Calzone", 9.5f, false, new List<string>() { "tomate", "mozzarella", "jambon", "basicil" }));
            Pizzas.Add(new Pizza("4 fromages", 10.5f, true, new List<string>() { "tomate", "mozzarella", "raclette", "parmesan", "roquefort" }));
            Pizzas.Add(new Pizza("Tartiflette", 12, false, new List<string>() { "crème", "raclette", "lardons", "patates" }));
            Pizzas.Add(new Pizza("veggie", 11, true, new List<string>() { "tomate", "mozzarella", "basicil", "roquette", "capres" }));
            Pizzas.Add(new PizzaPersonnalisee());
            Pizzas.Add(new PizzaPersonnalisee());

            //listePizzas = listePizzas.OrderBy(x => x.prix).ToList();
            //listePizzas = listePizzas.OrderByDescending(x => x.prix).ToList();

            foreach (var pizza in Pizzas)
            {
                pizza.AfficherPizza();
            }
        }
    }
}   
