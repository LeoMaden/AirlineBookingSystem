using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

    }
}