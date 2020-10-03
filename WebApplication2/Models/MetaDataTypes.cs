using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class MetaDataTypes
    {
        public MetaDataTypes()
        {
            MetaDataTitles = new HashSet<MetaDataTitles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MetaDataTitles> MetaDataTitles { get; set; }
    }
}
