namespace Tienda.Transversal.Helpers.Pagination
{
    // Generica para que pueda recibir los registros de cualquier tabla
    public class Pager<T> where T : class
    {
        public int PageIndex { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T>? Registers { get; set; }

        // Inicializo los valores
        public Pager(int pageIndex, int amountRegisters, int pageSize, IEnumerable<T>? registers)
        {
            PageIndex = pageIndex;
            Total = amountRegisters;
            PageSize = pageSize;
            Registers = registers;
        }



        public int TotalPages
        {
            get
            {
                // Redondeará el resultado hacia el valor siguiente y lo transformará en entero
                return (int)Math.Ceiling(Total / (double)PageSize);
            }
        }
        // Si se cumple la condición pasará a la página anterior
        public bool PreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool NextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

    }
}
