using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Typetechnology
    {
        public Typetechnology()
        {
            Technologies = new HashSet<Technology>();
        }

        public int Idtypetechnology { get; set; }
        public string Typetechnology1 { get; set; } = null!;

        public virtual ICollection<Technology> Technologies { get; set; }
    }
}
