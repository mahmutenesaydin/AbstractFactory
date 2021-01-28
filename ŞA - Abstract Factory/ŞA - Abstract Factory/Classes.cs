using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŞA___Abstract_Factory
{
    /*
     Africa, America,... --> Continent
     Herbivor, Carnivor...--> 
     Wildeebeast, Lion, Bison, Wolf
     Animal World
     */

    interface IHerbivor
    {

    }  

    interface ICarnivor
    {
        void Eat(IHerbivor h);
    }
     
    class Wildebeast : IHerbivor
    {

    }

    class Lion : ICarnivor
    {
        public void Eat(IHerbivor h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Bison : IHerbivor
    {

    }

    class Wolf : ICarnivor
    {
        public void Eat(IHerbivor h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    interface IContinentFactory
    {
        IHerbivor CreateHerbivor();
        ICarnivor CreateCarnivor();
    }

    class AfricaFactory : IContinentFactory
    {
        public ICarnivor CreateCarnivor()
        {
            return new Lion();
        }

        public IHerbivor CreateHerbivor()
        {
            return new Wildebeast();
        }
    }

    class AmericaFactory : IContinentFactory
    {
        public ICarnivor CreateCarnivor()
        {
            return new Wolf();
        }

        public IHerbivor CreateHerbivor()
        {
            return new Bison();
        }
    }

    class AnimalWorld
    {
        private IHerbivor _herbivor;
        private ICarnivor _carnivor;

        public AnimalWorld(IContinentFactory kita)
        {
            _herbivor = kita.CreateHerbivor();
            _carnivor = kita.CreateCarnivor();
        }

        public void RunFoodChain()
        {
            _carnivor.Eat(_herbivor);
        }
    }
}
