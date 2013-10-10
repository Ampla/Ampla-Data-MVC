﻿using System;
using AmplaWeb.Data.Attributes;

namespace AmplaWeb.Data.Downtime
{
    [AmplaLocation(Location = "Plant.Area.Downtime")]
    [AmplaModule(Module = "Downtime")]
    public class IdentifierDowntimeModel
    {
        public int Id { get; set; }
        public string Location { get; set; }

        [AmplaField(Field = "Start Time")]
        public DateTime StartTime { get; set; }

        [AmplaField(Field = "Cause Location")]
        public string CauseLocation { get; set; }

        /// <summary>
        /// Uso
        /// </summary>
        public int Cause { get; set; }

        public int Classification { get; set; }
    }
}