using System.Data.SqlClient;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Entidades.ViewModels.Carrito;
using PizzeriaEdiMVC.Entidades.ViewModels.ItemVenta;
using PizzeriaEdiMVC.Entidades.ViewModels.Producto;
using PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto;
using PizzeriaEdiMVC.Entidades.ViewModels.Venta;

namespace PizzeriaEdiMVC.Mapeador
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadTipoProductosMapping();
            LoadProductosMapping();
            LoadCarritoMapping();
            LoadItemVentasMapping();
            LoadVentasMapping();
        }

        private void LoadItemVentasMapping()
        {
            CreateMap<ItemVenta, ItemVentaListDto>()
                .ForMember(dest => dest.Producto, act => act.MapFrom(src => src.Producto.Descripcion));
                
                    
            CreateMap<ItemVenta, ItemVentaEditDto>()
                .ForMember(dest => dest.Producto, act => act.MapFrom(src => src.Producto.Descripcion)).ReverseMap();
            CreateMap<ItemVentaListDto, ItemVentaListViewModel>();
            CreateMap<ItemVentaEditDto, ItemVentaListDto>().ForMember(dest => dest.Producto,
                act => act.MapFrom(src => src.Producto.Descripcion));
        }

        private void LoadVentasMapping()
        {
            //CreateMap<Venta, VentaListDto>()
            //    .ForMember(dest => dest.ItemsVentas, act => act.MapFrom(src => src.ItemsVentas)).ReverseMap();
            //CreateMap<Venta, VentaEditDto>()
            //    .ForMember(dest => dest.ItemsVentas, act => act.MapFrom(src => src.ItemsVentas)).ReverseMap();
            CreateMap<Venta, VentaListDto>();
           
            //CreateMap<Venta, VentaListDto>().ForMember(dest=>dest.ItemsVentas, act=>act.MapFrom(src=>src.ItemsVentas))
            //    .ReverseMap();
            CreateMap<Venta, VentaEditDto>()
                .ReverseMap();
            CreateMap<VentaListDto, VentaDetailsViewModel>();

            CreateMap<VentaListDto, VentaDetailsViewModel>()
                .ForMember(dest => dest.Detalles, act => act.MapFrom(src => src.ItemsVentas));
            CreateMap<VentaListDto, VentaListViewModel>();
            CreateMap<VentaEditDto, VentaListDto>();
        }

        private void LoadCarritoMapping()
        {
            CreateMap<ItemCarrito, ItemCarritoListViewModel>()
                .ForMember(dest => dest.ProductoListViewModel, act => act.MapFrom(src => src.Producto));


            CreateMap<Producto, ProductoListViewModel>()
            .ForMember(dest => dest.TipoProducto, act => act.MapFrom(src => src.TipoProducto.Descripcion));

            CreateMap<Carrito, CarritoListViewModel>()
                .ForMember(dest => dest.Items, act => act.MapFrom(src => src.listaItems));

        }


        private void LoadProductosMapping()
        {
            CreateMap<Producto, ProductoListDto>()
                .ForMember(dest => dest.TipoProducto, act => act.MapFrom(src => src.TipoProducto.Descripcion));

            CreateMap<ProductoListDto, Producto>();

            CreateMap<ProductoListDto, ProductoListViewModel>();
            CreateMap<ProductoEditViewModel, ProductoEditDto>().ReverseMap();
            CreateMap<ProductoEditDto, Producto>().ReverseMap();
            CreateMap<ProductoEditDto, ProductoListDto>();
            CreateMap<ProductoEditDto, ProductoDetailsViewModel>();
            CreateMap<Producto, ProductoListViewModel>()
                .ForMember(dest => dest.TipoProducto, act => act.MapFrom(src => src.TipoProducto.Descripcion));

        }

        private void LoadTipoProductosMapping()
        {
            CreateMap<TipoProducto, TipoProductoListDto>();
            CreateMap<TipoProducto, TipoProductoEditDto>().ReverseMap();
            CreateMap<TipoProductoListDto, TipoProductoListViewModel>().ReverseMap();
            CreateMap<TipoProductoEditDto, TipoProductoEditViewModel>().ReverseMap();
            CreateMap<TipoProductoEditDto, TipoProductoListDto>().ReverseMap();
            CreateMap<TipoProductoCantidadListDto, TipoProductoCantidadListViewModel>();

            CreateMap<TipoProductoDetailsDto, TipoProductoDetailsViewModel>()
                .ForMember(dest => dest.TipoProductoListViewModel,
                    act => act
                        .MapFrom(src => src.Tipo))
                .ForMember(dest => dest.ProductosVm,

                    act => act
                        .MapFrom(src => src.ProductosListDto));
        }
    }
}