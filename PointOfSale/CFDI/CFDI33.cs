using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFDI
{

    public class CFDI33
    {
        //Propiedades
        public Venta Venta { get; set; }


        //Controladores
        private VentaController ventaController;
        private VentapController ventapController;
        private ClienteController clienteController;
        private EmpresaController empresaController;
        private DymErrorController dymErrorController;

        //Listas
        private List<Ventap> Partidas { get; set; }

        //Objetos
        private Cliente cliente;
        private Empresa empresa;


        //Variables
        private string cadenaOriginal;
        private string facturaActual;
        private string NoCertificado;
        private decimal totalIva;
        private decimal totalIeps;
        private string r1, r2;


        public CFDI33()
        {
            //Controladores
            ventaController = new VentaController();
            ventapController = new VentapController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();
            dymErrorController = new DymErrorController();



        }
    }
}
