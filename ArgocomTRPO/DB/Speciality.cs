using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Speciality
    {
        public Speciality()
        {
            Employees = new HashSet<Employee>();
        }

        public int Idspeciality { get; set; }
        public string Speciality1 { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
