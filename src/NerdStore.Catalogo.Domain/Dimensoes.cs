using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }

        public decimal Largura { get; private set; }

        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Altura, 0, "Campo Altura nao pode ser 0");
            Validacoes.ValidarSeIgual(Largura, 0, "Campo Largura nao pode ser 0");
            Validacoes.ValidarSeIgual(Profundidade, 0, "Campo Profundidade nao pode ser 0");

            Validacoes.ValidarSeMenorQue(Altura, 0, "Campo Altura nao pode ser menor que 0");
            Validacoes.ValidarSeMenorQue(Largura, 0, "Campo Largura nao pode ser menor que 0");
            Validacoes.ValidarSeMenorQue(Profundidade, 0, "Campo Profundidade nao pode ser menor que 0");
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
