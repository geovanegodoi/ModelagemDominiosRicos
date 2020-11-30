using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private const int ESTOQUE_MINIMO = 10;
        private const int ESTOQUE_MAXIMO = 100;

        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _bus;
        

        public EstoqueService(IProdutoRepository produtoRepository, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _bus = mediatorHandler;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            // TODO : Parametrizar a quantidade de estoque baixo

            if (produto.QuantidadeEstoque < ESTOQUE_MINIMO)
            {
                // Avisar, mandar email, abrir chamado, realizar nova compra
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            if (produto.QuantidadeEstoque >= ESTOQUE_MAXIMO)
            {
                // Avisar, mandar email, abrir chamado, realizar nova compra
                await _bus.PublicarEvento(new ProdutoMaximoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
