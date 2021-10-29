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
    public class ProdutoTeste
    {
        protected readonly Fixture _fixture;
        protected readonly ProdutoFake _produtoFake;
        public ProdutoTeste()
        {
            _fixture = new Fixture();
            _produtoFake = new ProdutoFake(_fixture);
        }


        [Fact]
        [Trait("Entidade Produto", "Validar Entidade Invalida")]
        public void DeveretornarNotificacaoQuandoProdutoForInvalida()
        {
            var categoria = _produtoFake.CriarEntidadeInvalida();
            categoria.ValidateDomain();

            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count > 0);
        }

        [Fact]
        [Trait("Entidade Produto", "Validar Entidade Valida")]
        public void NãoDeveretornarNotificacaoQuandoProdutoForValida()
        {
            var categoria = _produtoFake.CriarEntidadeValida();
            categoria.ValidateDomain();

            Assert.True(categoria.IsValid);
            Assert.False(categoria.Notifications.Count > 0);
        }
    }
}
