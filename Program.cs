using System.Linq.Expressions;
using System.Text;

namespace ProjetPIZZA
{
    
    class Pizza
    {
        string nom;
        float prix;
        bool vegetarienne = false;

        public Pizza(string nom, float prix, bool vegetarienne)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
        }

        public void AfficherPizza()
        {
            string badgeVege = " (V)";
            if (!vegetarienne) { badgeVege = ""; }
            Console.WriteLine("Pizza : " + nom + badgeVege + " - " + prix + "€");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var listePizzas = new List<Pizza>();
            listePizzas.Add(new Pizza("Margherita", 7, true));
            listePizzas.Add(new Pizza("Reine", 8.5f, false));
            listePizzas.Add(new Pizza("5 fromages", 10.5f, true));
            listePizzas.Add(new Pizza("Tartiflette", 12, false));

            foreach(var pizza in listePizzas)
            {
                pizza.AfficherPizza();
            }
        }
    }
}