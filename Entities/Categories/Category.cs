using EntitiesInterface.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    [Serializable]
    public class Category : ISerializable, ICategory
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public Category() { }

        public Category(ICategory pCategory)
        {
            IdCategory = pCategory.IdCategory;
            Name = pCategory.Name;
            IsEnabled = pCategory.IsEnabled;

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
