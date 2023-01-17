using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository repoDeco;
        private readonly ICollection<IAquarium> aquas;

        public Controller()
        {
            this.repoDeco = new DecorationRepository(); ;
            this.aquas = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
           
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else 
            {
                throw new InvalidOperationException($"Invalid aquarium type.");
            }

            aquas.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration deco = null;
            
            if (decorationType == "Ornament")
            {
                deco = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                deco = new Plant();
            }
            else
            {
                throw new InvalidOperationException($"Invalid decoration type.");
            }

            repoDeco.Add(deco);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
       
            IFish fish = null;
            if(fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if( fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            if ((fishType == nameof(FreshwaterFish) && targetAquarium.GetType().Name == nameof(SaltwaterAquarium)) ||
                (fishType == nameof(SaltwaterFish) && targetAquarium.GetType().Name == nameof(FreshwaterAquarium)))
            {
                return OutputMessages.UnsuitableWater;
            }

            targetAquarium.AddFish(fish);


            //foreach (var aquarium in aquas)
            //{
            //    if(aquarium.GetType().Name == aquariumName)
            //    {
            //        if (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium" ||
            //            fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            //        {
            //            aquarium.AddFish(fish);
            //            return $"Successfully added { fishType} to { aquariumName}.";
            //        }
            //    }
            //}
            return $"Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
            foreach (var aquarium in aquas)
            {
                if (aquarium.GetType().Name == aquariumName)
                {
                    var sumF = aquarium.Fish.Sum(x => x.Price);
                    var sumD = aquarium.Decorations.Sum(x => x.Price);
                    var total = sumD + sumF;
                    return $"The value of Aquarium {aquariumName} is {total:f2}.";
                }
            }
            return "Invalid";
        }

        public string FeedFish(string aquariumName)
        {
            var aqua = aquas.FirstOrDefault(x => x.Name == aquariumName);
            if (aqua == null)
            {

            }

            foreach (var item in aqua.Fish)
            {
                item.Eat();
            }
            return $"Fish fed: {aqua.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aqua = aquas.FirstOrDefault(x => x.Name == aquariumName);
            var deco  = aqua.Decorations.FirstOrDefault(x => x.GetType().Name == decorationType);
            if (deco == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
           
            aqua.AddDecoration(deco);
            return $"Successfully added {decorationType} to {aquariumName}.";

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder(); 
            foreach (var item in aquas)
            {
               string str = item.GetInfo();
            }
            return sb.ToString();   
        }

        public void Exit()
        {
            return;
        }
    }
}
