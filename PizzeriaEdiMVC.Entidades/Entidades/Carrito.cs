using System.Collections.Generic;
using System.Linq;

namespace PizzeriaEdiMVC.Entidades.Entidades
{
    public class Carrito
    {
        public List<ItemCarrito> listaItems { get; set; } = new List<ItemCarrito>();

        public List<ItemCarrito> GetItems()
        {
            return listaItems;
        }
        public void AgregarAlCarrito(Producto producto, int cantidad)
        {
            var item = listaItems.SingleOrDefault(i => i.Producto.ProductoId == producto.ProductoId);
            if (item == null)
            {
                listaItems.Add(new ItemCarrito
                {
                    Producto = producto,
                    Cantidad = cantidad
                });
            }
            else
            {
                item.Cantidad++;
            }
        }

        public void EliminarDelCarrito(Producto producto)
        {
            listaItems.RemoveAll(i => i.Producto.ProductoId == producto.ProductoId);
        }

        public decimal TotalCarrito()
        {
            return listaItems.Sum(i => i.Cantidad * i.Producto.Precio);
        }

        public void VaciarCarrito()
        {
            listaItems.Clear();
        }
    }
}
