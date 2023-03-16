namespace PortifolioMalostiApi.Model
{
    public class Contact
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
    }
}
