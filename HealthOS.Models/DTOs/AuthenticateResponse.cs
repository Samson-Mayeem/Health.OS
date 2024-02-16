namespace RealEstate.Domain.ViewModels
{
    public class AuthenticateResponse
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
    }
}