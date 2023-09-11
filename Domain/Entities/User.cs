using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User
{
    [Required]
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public virtual ICollection<Contact>? Contacts { get; set; }
}
