﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class UpdateContactRequest
{
    public int Id { get; set; }

    public ContactType Type { get; set; }

    public string Value { get; set; }
}
