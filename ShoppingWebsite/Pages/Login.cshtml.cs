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
        public Accounts newAccount { get; set; }
        public IEnumerable<Accounts> Accounts { get; private set; }
        public LoginModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Accounts = _unitOfWork.AccountRepository.GetList();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.AccountRepository.Create(newAccount);
            _unitOfWork.Save();

            return RedirectToPage("/Index"); // Chuyển hướng sau khi tạo tài khoản thành công
        }
    }
}
