using System.Collections;
using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        // EF Relation Navigation Property
        public ICollection<Produto> Produtos { get; private set; }

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto nao pode ser vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo do produto nao pode ser 0");
        }
    }
}
