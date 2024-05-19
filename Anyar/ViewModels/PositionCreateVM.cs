using System.ComponentModel.DataAnnotations;

namespace Anyar.ViewModels
{
    public class PositionCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
