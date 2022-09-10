using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models { get; }
        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return models.FirstOrDefault(w => w.GetType().Name == type);

        }

        public bool Remove(IDecoration model)
        {
            foreach (var item in models)
            {
                if (item == model)
                {
                    models.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
