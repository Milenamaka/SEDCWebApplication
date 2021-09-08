﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.BLL.logic.Models
{
    public enum RoleEnum
    {
        [Display(Name="Menadzer")]
        Menadzer = 1,
        Prodavac = 2,
        PizzaMajstor = 3
    }
}
