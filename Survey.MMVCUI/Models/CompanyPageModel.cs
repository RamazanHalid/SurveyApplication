using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MMVCUI.Models
{
    public class CompanyPageModel
    {
        public Company Company { get; set; }
        public List<City> Cities { get; set; }
    }
}