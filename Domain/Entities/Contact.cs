using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Contact
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    public ContactType Type { get; set; }

    [Required]
    [MaxLength(100)]
    public string Value { get; set; }

    public virtual User User { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
}
