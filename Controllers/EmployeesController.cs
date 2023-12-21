using CQRSDemo.Data.Command;
using CQRSDemo.Data.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet]
        public async Task<List<Employee>> EmployeeList()
        {
            var employeeList=await _mediator.Send(new GetEmployeeListQuery());
            return (List<Employee>)employeeList;
        }

        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            var employee=await _mediator.Send(new GetEmployeeByIdQuery(){Id=id});
            return (Employee)employee;
        }
        [HttpPost]
        public async Task<Employee>AddEmployee(Employee employee)
        {
            var employeeReturn=await _mediator.Send(new CreateEmployeeCommand(
                employee.Name,
                employee.Address,
                employee.Email,
                employee.Phone
            ));
            return (Employee)employeeReturn;
        }

        [HttpPut]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employeeReturn=await _mediator.Send(new UpdateEmployeeCommand(
                employee.Id,
                employee.Name,
                employee.Address,
                employee.Email,
                employee.Phone
            ));
            return (int)employeeReturn;
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return (int)await _mediator.Send(new DeleteEmployeeCommand(){Id=id});
        }

        
    }

    
}