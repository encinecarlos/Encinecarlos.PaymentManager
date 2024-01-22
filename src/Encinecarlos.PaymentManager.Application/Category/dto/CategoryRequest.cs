using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Category.dto
{
    public record CategoryRequest
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}
