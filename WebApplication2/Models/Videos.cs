using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Videos
    {
        public Videos()
        {
            MetaData = new HashSet<MetaData>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MetaData> MetaData { get; set; }
    }
}
