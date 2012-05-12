using stFacturacion.Models;
using System.Web.Mvc;
using System.Collections;

namespace stFacturacion.ViewModels
{
    public class ArticuloSelectListViewModel
    {
        public Articulo Articulo { get; private set; }
        public SelectList Tallas { get; private set; }
        public SelectList Tarifas { get; private set; }
        public SelectList TipoIvas { get; private set; }
        public SelectList Colores { get; private set; }
        public SelectList Familias { get; private set; }
        public SelectList FormaPagos { get; private set; }

        public ArticuloSelectListViewModel(Articulo articulo, 
                                        IEnumerable tallas, 
                                        IEnumerable tarifas,
                                        IEnumerable tipoivas,
                                        IEnumerable colores,
                                        IEnumerable familias,
                                        IEnumerable formapagos)
	    {		 
            Articulo = articulo;
            Tallas = new SelectList(tallas, "tallaId", "descripciontalla", articulo.tallaId);
            Tarifas = new SelectList(tarifas, "tarifaId", "descripcion", articulo.tarifaId);
            TipoIvas = new SelectList(tipoivas, "tipoivaId", "descripcion", articulo.tipoivaId);
        }
    }
}