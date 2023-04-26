namespace back_api.Domain.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}

