﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class CreateUserRequest
{
    public string? Name { get; set; }

    public List<CreateContactRequest?> Contacts { get; set; }
}
