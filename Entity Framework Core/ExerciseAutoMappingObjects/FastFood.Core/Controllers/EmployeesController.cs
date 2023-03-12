using AutoMapper;
using FastFood.Data;
using FastFood.Web.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
