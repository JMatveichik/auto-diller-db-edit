using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Models
{
	[Table("au_dealers")]
	internal class Dealer
	{
		[Key]
		[Column("d_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("d_name")]
		[MaxLength(40)]
		public string? Name { get; set; }

		[Required]
		[Column("d_address")]
		[MaxLength(70)]
		public string? Address { get; set; }

		[Required]
		[Column("d_telephone")]
		[MaxLength(12)]
		public string? Telephone { get; set; }

		[Required]
		[Column("d_fax")]
		[MaxLength(12)]
		public string? Fax { get; set; }

		public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
	}
}
