using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Breaking
    {
        public Breaking()
        {
            Mendings = new HashSet<Mending>();
        }

        public int Idbreaking { get; set; }
        public DateOnly Datebreaking { get; set; }
        public string Description { get; set; } = null!;
        public int Fktypebreaking { get; set; }
        public int Fktechnology { get; set; }

        public virtual Technology FktechnologyNavigation { get; set; } = null!;
        public virtual Typebreaking FktypebreakingNavigation { get; set; } = null!;
        public virtual ICollection<Mending> Mendings { get; set; }
    }
}
