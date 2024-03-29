﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        //private readonly List<IPilot> models;
        //public PilotRepository()
        //{
        //    models = new List<IPilot>();
        //}
        //public IReadOnlyCollection<IPilot> Models => models;

        //public void Add(IPilot model)
        //{
        //    models.Add(model);
        //}

        //public IPilot FindByName(string name)
        //{
        //    return models.FirstOrDefault(h => h.FullName == name);
        //}

        //public bool Remove(IPilot model)
        //{
        //    return models.Remove(model);
        //}
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => models;

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(p => p.FullName == name);
        }
    }
}
