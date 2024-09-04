using System.ComponentModel.DataAnnotations;

namespace Shul_Modules.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string FName { get; set; }

        [Required]
        [StringLength(50)]
        public string LName { get; set; }

        [StringLength(50)]
        public string? HFName { get; set; } // Nullable

        [StringLength(50)]
        public string? HLName { get; set; } // Nullable

        [StringLength(50)]
        public string? Ben { get; set; } // Nullable

        [StringLength(15)]
        public string? CYL { get; set; } // Nullable

        [StringLength(50)]
        public string? Phone { get; set; } // Nullable

        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; } // Nullable

        [StringLength(50)]
        public string? Address { get; set; } // Nullable
    }
}
