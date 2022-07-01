using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
