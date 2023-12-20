using ProniaOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Category:BaseNameableEntity
    {
        //Relational Prop
        public ICollection<Product>? Products { get; set; }

    }
}
