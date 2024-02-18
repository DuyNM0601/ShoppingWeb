using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebsite.Models;
using ShoppingWebsite.UnitOfWork;

namespace ShoppingWebsite.Pages
{
    public class UpdateCustomerModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Customer Customer { get; set; }
        public UpdateCustomerModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public void OnGet(int customerId)
        {
            Customer = _unitOfWork.CustomerRepository.GetById(customerId);
        }

       

        public IActionResult OnPost(string handler)
        {
            if (handler == "Delete") // Kiểm tra xem người dùng đã click nút Delete hay không
            {
                try
                {
                    _unitOfWork.BeginTransaction();

                    _unitOfWork.CustomerRepository.Delete(Customer.CustomerId); // Xóa khách hàng

                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();

                    return RedirectToPage("/Login");
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi xóa khách hàng.");
                    return Page();
                }
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.BeginTransaction();

                    _unitOfWork.CustomerRepository.Update(Customer, Customer.CustomerId); // Cập nhật thông tin khách hàng

                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();

                    return RedirectToPage("/Login");
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật thông tin khách hàng.");
                    return Page();
                }
            }
            return Page();
        }


    }
}
