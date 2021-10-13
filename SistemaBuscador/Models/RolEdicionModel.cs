﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class RolEdicionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}
