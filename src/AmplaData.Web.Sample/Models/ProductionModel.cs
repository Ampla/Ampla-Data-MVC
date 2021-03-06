﻿using System;
using AmplaData.Attributes;

namespace AmplaData.Web.Sample.Models
{
    [AmplaLocation(Location="Vedanta", WithRecurse = true)]
    [AmplaModule(Module = "Production")]
    [AmplaDefaultFilters("Deleted={}")]
    public class ProductionModel
    {
        public int Id { get; set; }

        [AmplaField(Field = "Sample Period")]
        public DateTime Sample { get; set; }

        public TimeSpan Duration { get; set; }

        public string Location { get; set; }

        [AmplaField(Field = "Confirmed")]
        public bool Confirmed { get; set; }

        [AmplaField(Field = "Deleted")]
        public bool Deleted { get; set; }

        public string Train { get; set; }

        public string Shift { get; set; }
    }
}