namespace GameStore.FrontEnd.Clients
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public List<Message>? Messages { get; set; } = new();
    }
    public record Message(string Text, int Code);
}
