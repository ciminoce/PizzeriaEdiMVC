using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Web.Binders
{
    public class CarritoModelBinder : IModelBinder
    {
        private const string sessionKey = "ePizza";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = null;
            if (controllerContext.HttpContext.Session[sessionKey] != null)
            {
                carrito = (Carrito)controllerContext.HttpContext.Session[sessionKey];
            }

            if (carrito == null)
            {
                carrito = new Carrito();
                if (controllerContext.HttpContext.Session[sessionKey] == null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = carrito;

                }
            }

            return carrito;
        }
    }
}