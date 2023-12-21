using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Query;

namespace CQRSDemo.Data.Command
{
    public class DeleteEmployeeCommand :IRequest<int>
    {
        public int Id {get;set;}
        
    }
}