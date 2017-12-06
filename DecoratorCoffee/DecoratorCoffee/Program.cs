using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage1 = new DarkRoastCoffee();
            Console.WriteLine(beverage1.GetCost().ToString());

            Beverage beverage2 = new DarkRoastCoffee();
            beverage2 = new Milk(beverage2);
            beverage2 = new MintSyrop(beverage2);
            Console.WriteLine(beverage2.GetCost().ToString());
            Console.WriteLine(beverage2.GetDescription());

            Console.ReadLine();
        }
    }
    public abstract class Beverage
    {
        public int Cost { get; set;}
        public string Description { get; set; }

        public virtual int GetCost()
        {
            return Cost;
        }
        public virtual string GetDescription()
        {
            return Description;
        }
    }
    public class DarkRoastCoffee: Beverage
    {
        public DarkRoastCoffee()
        {
            Cost = 20;
            Description = "Кофе темной прожарки";
        }

    }
    public class Espresso: Beverage
    {
        public Espresso()
        {
            Cost = 10;
            Description = "Эспрессо";
        }
    }
    public abstract class DecoratorCondiment : Beverage
    {
        public Beverage beverage;

        public override int GetCost()
        {
            return beverage.GetCost() + Cost;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + " " + Description;
        }
    }
    public class Milk: DecoratorCondiment
    {
        public Milk(Beverage bev)
        {
            beverage = bev;
            Cost = 2;
            Description = "Молоко";
        }
    }
    public class MintSyrop: DecoratorCondiment
    {
        public MintSyrop(Beverage bev)
        {
            beverage = bev;
            Cost = 5;
            Description = "Мятный сироп";
        }
    }

}
