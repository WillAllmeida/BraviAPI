﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class UpdateUserRequest
{
    public int Id { get; set; }

    public string Name { get; set; }
}
