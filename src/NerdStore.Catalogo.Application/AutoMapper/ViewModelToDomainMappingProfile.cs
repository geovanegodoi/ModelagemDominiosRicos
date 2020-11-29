using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(vm =>
                    new Produto(vm.Nome, vm.Descricao, vm.Ativo,
                        vm.Valor, vm.CategoriaId, vm.DataCadastro,
                        vm.Imagem, new Dimensoes(vm.Altura, vm.Largura, vm.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(vm => new Categoria(vm.Nome, vm.Codigo));
        }
    }
}