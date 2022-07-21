using System;
using System.Collections.Generic;

namespace OrganicWeb.Models
{
    public partial class Location
    {
        public Location()
        {
            Customers = new HashSet<Customer>();
            InverseParent = new HashSet<Location>();
        }

        public int LocationId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? NameWithType { get; set; }
        public string? PathWithType { get; set; }
        public int? ParentId { get; set; }
        public int? Levels { get; set; }

        public virtual Location? Parent { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Location> InverseParent { get; set; }
    }
}
