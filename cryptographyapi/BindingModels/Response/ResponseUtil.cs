namespace cryptographyapi.BindingModels.Response
{
    public class ResponseUtil<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }

    }
}
