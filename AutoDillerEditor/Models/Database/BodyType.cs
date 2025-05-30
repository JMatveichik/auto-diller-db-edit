using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Models
{
	[Table("au_body_type")]
	public class BodyType
	{
		[Key]
		[Column("bt_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("bt_name")]
		[MaxLength(50)]
		public string? Name { get; set; }

		public ICollection<Automobile> Automobiles { get; set; } = new List<Automobile>();
	}
}
