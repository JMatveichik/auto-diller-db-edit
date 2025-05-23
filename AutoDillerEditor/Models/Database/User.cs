using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoLandProcessor.Models
{
	[Table("au_users")]
	public class User
	{
		[Key]
		[Column("u_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("u_login")]
		[MaxLength(50)]
		public string Login { get; set; }

		[Column("u_role")]
		[MaxLength(50)]
		public string Role { get; set; } = "user";

		[Required]
		[Column("u_password")]
		[MaxLength(50)]
		public string Password { get; set; }

		[Required]
		[Column("u_name")]
		[MaxLength(40)]
		public string Name { get; set; }

		[Required]
		[Column("u_surname")]
		[MaxLength(40)]
		public string Surname { get; set; }

		[Column("u_birthday")]
		public DateTime Birthday { get; set; }

		[Required]
		[Column("u_email")]
		[MaxLength(50)]
		public string Email { get; set; }

		[Required]
		[Column("u_telephone")]
		[MaxLength(12)]
		public string Telephone { get; set; }

		[Required]
		[Column("u_address")]
		[MaxLength(70)]
		public string Address { get; set; }

		[Column("u_avatar")]
		[MaxLength(1000)]
		public string Avatar { get; set; } = "images/default.png";

		public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
	}
}
