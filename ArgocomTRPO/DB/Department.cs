using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Department
    {
        public Department()
        {
            Mendings = new HashSet<Mending>();
            Technologies = new HashSet<Technology>();
        }

        public int Iddepartment { get; set; }
        public string Numberdepartment { get; set; } = null!;
        public string Namedepartment { get; set; } = null!;

        public virtual ICollection<Mending> Mendings { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
    }
}
