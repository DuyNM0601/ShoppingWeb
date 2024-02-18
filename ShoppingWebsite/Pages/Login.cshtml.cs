using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using ShoppingWebsite.Repository;
using System.Security.Principal;
using ShoppingWebsite.UnitOfWork;

namespace ShoppingWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Customer Customer { get; set; }
        public List<Customer> listCustomer { get; set; }
        public LoginModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            listCustomer = _unitOfWork.CustomerRepository.GetList();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                // Lấy thông điệp từ TempData và hiển thị nó trên trang
                ViewData["SuccessMessage"] = TempData["SuccessMessage"].ToString();
            }
        }
        public IActionResult OnPost()
        {
            var checkLogin = _unitOfWork.CustomerRepository.checkLogin(Customer.ContactName, Customer.Password);

            if (checkLogin == null)
            {
                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                return Page();
            }
            else
            {
                // You might want to add logic to store user login state (e.g., using session or cookies) here.
                return RedirectToPage("/Index");
            }
        }

    }
}
