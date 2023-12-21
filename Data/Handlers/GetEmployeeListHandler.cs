using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Query;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Models;
using Services;

namespace CQRSDemo.Data.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeListHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeListAsync();
        }

        
    }

    public interface IRequestHandler<T1, T2>
    {
    }
}