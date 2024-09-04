namespace Entity.Models.User
{
	public class UserUserRole
	{
		public int UserId { get; set; }
		public int UserRoleId { get; set; }
		public User User { get; set; } = null!;
		public UserRole UserRole { get; set; } = null!;
	}
}
