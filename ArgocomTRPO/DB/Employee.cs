using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Employee
    {
        public Employee()
        {
            Mendings = new HashSet<Mending>();
        }

        public int Idemployees { get; set; }
        public string Surnameemployee { get; set; } = null!;
        public string Nameemployee { get; set; } = null!;
        public string? Patronymicemployee { get; set; }
        public string? Phonenumber { get; set; }
        public string Login { get; set; } = null!;
        public string Passwordemployee { get; set; } = null!;
        public int Fkspeciality { get; set; }

        public virtual Speciality FkspecialityNavigation { get; set; } = null!;
        public virtual ICollection<Mending> Mendings { get; set; }
    }
}
