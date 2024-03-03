﻿using DevoraLimeTestTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IHeroGenerator
    {
        HeroGeneratorResult Execute(int heroesCount);
    }
}
