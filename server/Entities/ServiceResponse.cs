namespace server.Entities
{
    public class ServiceResponse<Type>
    {
        public Type Data { get; set; }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}

