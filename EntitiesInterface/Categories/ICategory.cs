using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterface.Categories
{
    public interface ICategory
    {
        int IdCategory { get; set; }
        string Name { get; set; }
        bool IsEnabled { get; set; }
    }
}
