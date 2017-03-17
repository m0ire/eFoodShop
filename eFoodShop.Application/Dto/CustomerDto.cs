namespace eFoodShop.Application.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public CartDto Cart { get; set; }
    }
}