using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Abstract
{
   public interface ITenant_DL
    {
        int CreateTenantDL(Organization _org);
    }
}
