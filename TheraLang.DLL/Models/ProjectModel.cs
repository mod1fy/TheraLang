﻿using System;


namespace MvcWeb.TheraLang.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public DateTime ProjectBegin { get; set; }

        public DateTime ProjectEnd { get; set; }

        public decimal DonationAmount { get; set; }
    }
}
