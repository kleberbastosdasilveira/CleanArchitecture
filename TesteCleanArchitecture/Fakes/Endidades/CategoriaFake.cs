using AutoFixture;
using CleanArchitecture.Domain.Entities;
using System;
using TesteCleanArchitecture.Bases;

namespace TesteCleanArchitecture.Fakes.Endidades
{
    class CategoriaFake : IFake<Category>
    {
        private readonly Fixture _fixture;
        public CategoriaFake(Fixture fixture)
        {
            _fixture = fixture;
       }

        public Category CriarEntidadeInvalida()
        {
            var entidade = _fixture.Build<Category>().Create();
            entidade.Update(string.Empty);
            return entidade;

        }

        public Category CriarEntidadeValida()
        {
            var entidade = _fixture.Build<Category>().Create();
            return entidade;
        }
    }
}
