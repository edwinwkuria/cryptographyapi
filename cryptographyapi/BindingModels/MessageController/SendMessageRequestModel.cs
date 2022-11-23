namespace cryptographyapi.BindingModels.MessageController
{
    public class SendMessageRequestModel
    {
        public string? Message { get; set; }
        public string? Key { get; set; }
        public string? IV { get; set; }
    }
}
