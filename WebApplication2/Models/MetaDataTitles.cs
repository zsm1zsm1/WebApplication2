using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class MetaDataTitles
    {
        public MetaDataTitles()
        {
            MetaData = new HashSet<MetaData>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int MetaDataTypeId { get; set; }
        public string Comment { get; set; }
        public string Entitle { get; set; }

        public virtual MetaDataTypes MetaDataType { get; set; }
        public virtual ICollection<MetaData> MetaData { get; set; }
    }
}
