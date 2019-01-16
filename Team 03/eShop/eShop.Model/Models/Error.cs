using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Model.Models
{
    [Table("Error")]
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime ErrorDate { get; set; }

        [MaxLength(40)]
        public string IpAddress { get; set; }

        [MaxLength(4000)]
        public string UserAgent { get; set; }

        [MaxLength(4000)]
        public string Exception { get; set; }

        [MaxLength(4000)]
        public string Message { get; set; }

        [MaxLength(4000)]
        public string Everything { get; set; }

        [MaxLength(500)]
        public string HttpReferer { get; set; }

        [MaxLength(500)]
        public string PathAndQuery { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }
    }
}
