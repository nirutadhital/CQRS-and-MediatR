using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Command;
using Services;

namespace CQRSDemo.Data.Handlers
{
    public class DeleteEmployeeHandler :IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        public async Task <int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee=await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if(employee==null) return default;
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
        
    }
}