using System.ComponentModel.DataAnnotations;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels
{
    public class OrderBase
    {
        [Display(Name = "Poruka")]
        public string? Message { get; set; }

    }
}
