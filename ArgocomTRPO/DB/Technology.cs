using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Technology
    {
        public Technology()
        {
            Breakings = new HashSet<Breaking>();
        }

        public int Idtechnology { get; set; }
        public int Uniquecode { get; set; }
        public string Сharacteristic { get; set; } = null!;
        public int Fkstatus { get; set; }
        public int Fkdepartment { get; set; }
        public int Fktypetechnology { get; set; }

        public virtual Department FkdepartmentNavigation { get; set; } = null!;
        public virtual Status FkstatusNavigation { get; set; } = null!;
        public virtual Typetechnology FktypetechnologyNavigation { get; set; } = null!;
        public virtual ICollection<Breaking> Breakings { get; set; }
    }
}
