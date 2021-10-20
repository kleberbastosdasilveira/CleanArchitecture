using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCleanArchitecture.Fakes.Endidades;
using Xunit;

namespace TesteCleanArchitecture.Entidades
{
    public class CategoriaTeste
    {
        private readonly Fixture _fixture;
        private readonly CategoriaFake _categoriaFake;
        public CategoriaTeste()
        {
            _fixture = new Fixture();
            _categoriaFake = new CategoriaFake(_fixture);
        }


        [Fact]
        [Trait("Entidade Categoria", "Validar Entidade Invalida")]
        public void DeveretornarNotificacaoQuandoCategoriaForInvalida()
        {
            var categoria = _categoriaFake.CriarEntidadeInvalida();
            categoria.ValidateDomain();

            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count > 0);

        }
    }
}
