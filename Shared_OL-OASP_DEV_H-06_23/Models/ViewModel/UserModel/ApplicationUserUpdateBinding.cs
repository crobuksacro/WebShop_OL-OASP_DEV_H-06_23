using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using System.ComponentModel.DataAnnotations;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel
{
    public class ApplicationUserUpdateBinding
    {
        public string Id { get; set; }
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        public AddressUpdateBinding? Address { get; set; }
    }
}
