namespace Transversal.ResponseData
{
    public class Response<T>
    {
        private T? _data;
        public T? Data
        {
            get { return _data; }
            set
            {
                if (_data == null)
                    _data = value;
            }
        }

        private string? _message;
        public string? Message
        {
            get { return _message; }
            set
            {
                if(Message == null)
                    _message = value;
            }
        }

        public Response()
        {

        }
    }
}
