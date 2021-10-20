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
            var entridade = _fixture.Build<Category>().Create();
            entridade.Update(string.Empty);
            return entridade;

        }

        public Category CriarEntidadeValida()
        {
            var entridade = _fixture.Build<Category>().Create();
            return entridade;
        }
    }
}
