﻿using AplicaçãoContainer.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.DTOs
{
    public class ContainerDTO
    {
        public string Cliente { get; set; }
        
        public string Numero_Container { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }

        public Categoria Categoria { get; set; }
    }
}
