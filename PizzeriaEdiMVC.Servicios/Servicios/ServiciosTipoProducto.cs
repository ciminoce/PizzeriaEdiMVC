using System;
using System.Collections.Generic;
using AutoMapper;
using PizzeriaEdiMVC.Datos;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Servicios.Servicios
{
    public class ServiciosTipoProducto : IServiciosTipoProducto
    {
        private readonly IRepositorioTipoProductos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoProducto(IRepositorioTipoProductos repositorio,  IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<TipoProductoListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoProductoEditDto GetTipoPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoProductoEditDto tipoDto)
        {
            try
            {
                TipoProducto tipo = _mapper.Map<TipoProducto>(tipoDto);
                _repositorio.Guardar(tipo);
                _unitOfWork.Save();
                tipoDto.TipoProductoId = tipo.TipoProductoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                if (e.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado con otras tablas baja denegada");
                    
                }
                throw new Exception("Error al borrar un tipo de producto");

                //throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoProductoEditDto tipoDto)
        {
            try
            {
                TipoProducto tipo = _mapper.Map<TipoProducto>(tipoDto);
                return _repositorio.Existe(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoProductoEditDto tipoDto)
        {
            try
            {
                TipoProducto tipo = _mapper.Map<TipoProducto>(tipoDto);
                return _repositorio.EstaRelacionado(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoProductoCantidadListDto> GetListaTipoCantidad()
        {
            try
            {
                return _repositorio.GetListaTipoCantidad();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoProductoDetailsDto GetDetallesPorId(int? id)
        {
            try
            {
                return _repositorio.GetDetallesPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
