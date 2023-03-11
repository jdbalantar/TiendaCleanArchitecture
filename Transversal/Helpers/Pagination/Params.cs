namespace Tienda.Transversal.Helpers.Pagination
{
    // Esta clase contiene los parametros dados por el usuario
    public class Params
    {
        private int _pageSize = 5;
        private int _pageIndex = 1;
        private const int MaxPageSize = 50;

        // bumero de registros por página
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        //Pagina actual
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = (value <= 0) ? 1 : value;
        }
    }
}
