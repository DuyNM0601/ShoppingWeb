using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Models;
using ShoppingWebsite.UnitOfWork;

namespace ShoppingWebsite.Pages
{
    public class RegisterCustomerModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Customer Customer { get; set; }
        public RegisterCustomerModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.CustomerRepository.Create(Customer);

            _unitOfWork.Save();

            TempData["SuccessMessage"] = "Đăng ký thành công!";

            return RedirectToPage("/Login");
        }
    }
}
