using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Models;
using ShoppingWebsite.UnitOfWork;

namespace ShoppingWebsite.Pages
{
    public class UpdateAccountModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Accounts Account { get; set; }

        public UpdateAccountModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int accountId)
        {
            Account = _unitOfWork.AccountRepository.GetById(accountId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _unitOfWork.AccountRepository.Update(Account, Account.AccountID);
            _unitOfWork.Save();
            return RedirectToPage("/Login");
        }
    }
}
