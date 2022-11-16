namespace cryptographyapi.BindingModels.MessageController
{
    public class SendMessageRequestModel
    {
        public string message { get; set; }
        public string key { get; set; }
        public string iv { get; set; }
    }
}
