using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Models
{
	[Table("au_warranties")]
	public class Warranty
	{
		[Key]
		[Column("w_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("w_name")]
		[MaxLength(50)]
		public string? Name { get; set; }

		[Column("w_duration")]
		public int Duration { get; set; }

		[Column("w_price")]
		public decimal Price { get; set; }

		public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
	}
}
