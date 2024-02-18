using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Models;
using ShoppingWebsite.Repository;
using ShoppingWebsite.UnitOfWork;

namespace ShoppingWebsite.Pages
{
    public class LoginAccountModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public LoginAccountModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Accounts loginaccount = _unitOfWork.AccountRepository.GetAccount(Username, Password);
            if (loginaccount != null)
            {
                if (loginaccount.Type.ToString() == "1")
                {/*
                    HttpContext.Session.SetString("Role", "Staff");*/
                    return RedirectToPage("/Staff/StaffHome");
                }
                /*HttpContext.Session.SetString("Role", "NormalUser");
                HttpContext.Session.SetString("AccountId", loginaccount.AccountID.ToString());*/
                return RedirectToPage("/UpdateCustomer");
            }
            else
                return RedirectToPage("/Index");
        }
    }
}
