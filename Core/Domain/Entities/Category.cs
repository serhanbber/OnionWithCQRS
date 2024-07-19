using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : EntityBase, IEntityBase
    {
        public Category()
        {
                
        }
        public Category(string name,int priorty,int parentId)
        {
            Name = name;
            Priorty = priorty;
            ParentId = parentId;
        }
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        //public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
