﻿using Encinecarlos.PaymentManager.Application.Transaction.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class AddCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryRequest Category { get; set; }
    }
}
