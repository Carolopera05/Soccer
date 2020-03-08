namespace Soccer.Common.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }//booleano

        public string Message { get; set; }

        public object Result { get; set; }//respuesta
    }
}
