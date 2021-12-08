using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
   public sealed class User
    {
        public string Name { get; set; }
        public Address Endereco { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

    }
}
