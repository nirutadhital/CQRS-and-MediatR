using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Command;
using Services;

namespace CQRSDemo.Data.Handlers
{
    public class UpdateEmployeeHandler :IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        public async Task <int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee=await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if(employee==null) return default;
            employee.Name=request.Name;
            employee.Email=request.Email;
            employee.Phone=request.Phone;
            employee.Address=request.Address;
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }


        
    }
}