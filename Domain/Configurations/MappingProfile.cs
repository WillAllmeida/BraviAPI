﻿using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact, ContactListResponse>().ReverseMap();
    }
}