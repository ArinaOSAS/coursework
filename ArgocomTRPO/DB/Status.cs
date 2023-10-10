using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Status
    {
        public Status()
        {
            Technologies = new HashSet<Technology>();
        }

        public int Idstatus { get; set; }
        public string Status1 { get; set; } = null!;

        public virtual ICollection<Technology> Technologies { get; set; }
    }
}
