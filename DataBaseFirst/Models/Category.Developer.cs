using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Models
{
    public partial class Category
    {
        public override string ToString()
        {
            return $"{CategoryId} :: {CategoryName}";
        }
    }
}
