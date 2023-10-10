using System;
using System.Collections.Generic;

namespace ArgocomTRPO.DB
{
    public partial class Mending
    {
        public int Idmending { get; set; }
        public DateOnly Datemending { get; set; }
        public int Fkemployees { get; set; }
        public int Fkbreaking { get; set; }
        public int Fkdepartment { get; set; }

        public virtual Breaking FkbreakingNavigation { get; set; } = null!;
        public virtual Department FkdepartmentNavigation { get; set; } = null!;
        public virtual Employee FkemployeesNavigation { get; set; } = null!;
    }
}
