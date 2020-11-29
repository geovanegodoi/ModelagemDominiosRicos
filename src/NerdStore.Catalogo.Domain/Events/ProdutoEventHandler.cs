using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Bus;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler :
        ICanHandle<ProdutoAbaixoEstoqueEvent>,
        ICanHandle<ProdutoMaximoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // enviar email para compra de mais produtos
        }

        public async Task Handle(ProdutoMaximoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // enviar email para avisando que atingiu o estoque maximo
        }
    }
}
