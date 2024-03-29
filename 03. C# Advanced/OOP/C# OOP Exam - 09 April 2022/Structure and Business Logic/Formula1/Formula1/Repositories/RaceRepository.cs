﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public IReadOnlyCollection<IRace> Models => models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(c => c.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }

    }
}
