using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage =
            "The new Password and Confirmation password do not Match.")]
        public string ConfirmPassword { get; set; }
    }
}
