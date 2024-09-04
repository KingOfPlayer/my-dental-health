namespace Entity.Models.User
{
	public class UserRole
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public HashSet<UserUserRole> Users { get; set; } = new HashSet<UserUserRole>();
	}
}
