using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Typebreaking
    {
        public Typebreaking()
        {
            Breakings = new HashSet<Breaking>();
        }

        public int Idtypebreaking { get; set; }
        public string Typebreaking1 { get; set; } = null!;

        public virtual ICollection<Breaking> Breakings { get; set; }
    }
}
