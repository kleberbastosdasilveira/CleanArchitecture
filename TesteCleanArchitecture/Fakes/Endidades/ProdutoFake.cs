using AutoFixture;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCleanArchitecture.Bases;

namespace TesteCleanArchitecture.Fakes.Endidades
{
    public class ProdutoFake : IFake<Product>
    {
        private readonly Fixture _fixture;
        private readonly CategoriaFake _categoriaFake;
        public ProdutoFake(Fixture fixture)
        {
            _fixture = fixture;
            _categoriaFake = new CategoriaFake(_fixture);
        }
        public Product CriarEntidadeInvalida()
        {
            var entidade = _fixture.Build<Product>().Create();
            entidade.Update(Guid.Empty,string.Empty,string.Empty,0,0,string.Empty);
            return entidade;
        }

        public Product CriarEntidadeValida()
        {
            var entidade = _fixture.Build<Product>().Create();
            return entidade;
        }
    }
}
