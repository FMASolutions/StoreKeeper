using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StoreKeeper.Core.Models
{
    public class ProductGroup
    {
        public static readonly int NameMaxLength = 50;
        public static readonly int CodeMaxLength = 7;
        public static readonly int DescriptionMaxLength = 500;
        public ProductGroup()
        {
            SubGroups = new Collection<SubGroup>();
        }
        public int ID {get; set;}
        public string Name {get; set;}
        public string Code {get; set;}
        public string Description {get; set;}
        public bool IsVisible {get; set;} = true;
        public ICollection<SubGroup> SubGroups { get; set; }
    }
}
