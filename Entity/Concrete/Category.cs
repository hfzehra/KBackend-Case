using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }


    }
}
