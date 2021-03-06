﻿using AmplaData.Web.Controllers;
using AmplaData.Web.Sample.Models;

namespace AmplaData.Web.Sample.Controllers
{
    public class EnergyController : RepositoryController<EnergyModel>
    {
        public EnergyController(IRepository<EnergyModel> repository)
            : base(repository)
        {
        }
    }
}