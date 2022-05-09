using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Abstract
{
    public interface ITenantBL
    {
        bool CreateOrganization(Organization _org);
    }
}
