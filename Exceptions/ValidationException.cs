namespace bloggin_plataform_api.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IDictionary<string, string[]> errors) : base("One or more validation errors occurred.")
        {
            Errors = errors ?? new Dictionary<string, string[]>();
        }
    }
}