using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCleanArchitecture.Bases
{
    public interface IFake<T>
    {
        T CriarEntidadeValida();
        T CriarEntidadeInvalida();
    }
}
