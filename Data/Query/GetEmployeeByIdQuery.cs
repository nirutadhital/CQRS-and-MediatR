using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CQRSDemo.Data.Query
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id {get;set;}
        
    }
}