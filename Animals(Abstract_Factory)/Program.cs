using Animals_Abstract_Factory_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_Abstract_Factory_
{
    #region Создание животных
    public interface IAnimal
    {
        bool Live { get; set; }
    }

    public abstract class Herbivores : IAnimal
    {
        public bool Live { get; set; }
        public double Weight { get; set; }
        public abstract double EatGrass();
        public abstract string ToString();
    }
    public class Wildebeest : Herbivores
    {
        public Wildebeest()
        {
            Live = true;
            Weight = 0;
        }
        public Wildebeest(double weight)
        {
            Weight = weight;
            Live = true;
        }
        public override double EatGrass()
        {
            if (Weight < 0)
            {
                Live = false;
                return Weight;
            }
            return Weight += 10;
        }

        public override string ToString()
        {
            return $"Wildebeest Live - {Live}    Weight - {Weight}";
        }
    }
    public class Bison : Herbivores
    {
        public Bison()
        {
            Live = true;
            Weight = 0;
        }
        public Bison(double weight)
        {
            Weight = weight;
            Live = true;
        }
        public override double EatGrass()
        {
            if (Weight < 0)
            {
                Live = false;
                return Weight;
            }
            return Weight += 10;
        }
        public override string ToString()
        {
            return $"Bison Live - {Live}    Weight - {Weight}";
        }
    }
    /// 

    public abstract class Predators : IAnimal
    {
        public bool Live { get; set; }
        public double Power { get; set; }
        public abstract double Eat(Herbivores herbivores);
        public abstract string ToString();
    }
    public class Lion : Predators
    {
        public Lion()
        {
            Live = true;
            Power = 0;
        }
        public Lion(double power)
        {
            Power = power;
            Live = true;
        }
        public override double Eat(Herbivores herbivores)
        {
            if (Power < 0)
            {
                Live = false;
                return Power;
            }
            if (Power > herbivores.Weight)
            {
                herbivores.Live = false;
                return Power += 10;
            }
            if (Power == herbivores.Weight)
            {
                return Power;
            }
            return Power -= 10;
        }
        public override string ToString()
        {
            return $"Lion Live - {Live}    Weight - {Power}";
        }
    }
    public class Wolf : Predators
    {
        public Wolf()
        {
            Live = true;
            Power = 0;
        }
        public Wolf(double power)
        {
            Power = power;
            Live = true;
        }
        public override double Eat(Herbivores herbivores)
        {
            if (Power < 0)
            {
                Live = false;
                return Power;
            }
            if (Power > herbivores.Weight)
            {
                herbivores.Live = false;
                return Power += 10;
            }
            if (Power == herbivores.Weight)
            {
                return Power;
            }
            return Power -= 10;
        }
        public override string ToString()
        {
            return $"Wolf Live - {Live}    Weight - {Power}";
        }
    }
    #endregion
    /// 
    public abstract class Cauntry
    {
        public List<Herbivores> list_herbivores { get; set; }
        public List<Predators> list_predators { get; set; }
        public abstract void CreationHerbivore(Herbivores herbivores);
        public abstract void CreationPredators(Predators predators);
    }
    public class Africa : Cauntry
    {
        public Africa()
        {
            list_herbivores = new List<Herbivores>();
            list_predators = new List<Predators>();
        }
        public override void CreationHerbivore(Herbivores herbivores)
        {
            list_herbivores.Add(herbivores);
        }
        public override void CreationPredators(Predators predators)
        {
            list_predators.Add(predators);
        }

    }
    public class NorthAmerica : Cauntry
    {
        public override void CreationHerbivore(Herbivores herbivores)
        {
            list_herbivores.Add(herbivores);
        }
        public override void CreationPredators(Predators predators)
        {
            list_predators.Add(predators);
        }
    }
    ///

    public class AnimalWorld
    {
        public void ShowAnimalHerbivores(Cauntry cauntry)
        {
            for (int i = 0; i < cauntry.list_herbivores.Count; i++)
            {
                Console.WriteLine(cauntry.list_herbivores[i].ToString());
            }
        }
        public void ShowAnimalPredators(Cauntry cauntry)
        {
            for (int i = 0; i < cauntry.list_predators.Count; i++)
            {
                Console.WriteLine(cauntry.list_predators[i].ToString());
            }
        }
        public void MealsHerbivores(Cauntry cauntry)
        {
            for (int i = 0; i < cauntry.list_herbivores.Count; i++)
            {
                cauntry.list_herbivores[i].EatGrass();
            }
        }
        public void NutritionCarnivores(Cauntry cauntry)
        {
            int j = 0;
            for (int i = 0; i < cauntry.list_predators.Count || j < cauntry.list_herbivores.Count; i++, j++)
            {
                cauntry.list_predators[i].Eat(cauntry.list_herbivores[j]);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Wildebeest wildebeest = new Wildebeest(45);
            Wildebeest wildebeest1 = new Wildebeest(43);
            Wildebeest wildebeest2 = new Wildebeest(80);

            Bison bison = new Bison(66);
            Bison bison1 = new Bison(34);
            Bison bison2 = new Bison(34);


            Wolf wolf = new Wolf(23);
            Wolf wolf1 = new Wolf(60);
            Wolf wolf2 = new Wolf(34);

            Lion lion = new Lion(100);
            Lion lion1 = new Lion(56);
            Lion lion2 = new Lion(70);

            Africa africa = new Africa();

            africa.CreationHerbivore(wildebeest);
            africa.CreationHerbivore(wildebeest1);
            africa.CreationHerbivore(wildebeest2);
            africa.CreationHerbivore(bison);
            africa.CreationHerbivore(bison1);
            africa.CreationHerbivore(bison2);

            africa.CreationPredators(wolf);
            africa.CreationPredators(wolf1);
            africa.CreationPredators(wolf2);
            africa.CreationPredators(lion);
            africa.CreationPredators(lion1);
            africa.CreationPredators(lion2);

            AnimalWorld world = new AnimalWorld();
            world.ShowAnimalHerbivores(africa);
            world.ShowAnimalPredators(africa);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
            //world.MealsHerbivores(africa);
            world.NutritionCarnivores(africa);
            world.NutritionCarnivores(africa);
            world.NutritionCarnivores(africa);
            world.ShowAnimalHerbivores(africa);
            world.ShowAnimalPredators(africa);
        }
    }
}
