using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoLandProcessor.Models
{
	[Table("au_automobiles")]
	internal class Automobile
	{
		[Key]
		[Column("a_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("a_mark")]
		[MaxLength(50)]
		public string? Mark { get; set; }

		[Required]
		[Column("a_model")]
		[MaxLength(50)]
		public string? Model { get; set; }

		[Column("a_body_id")]
		public int BodyTypeId { get; set; }

		[ForeignKey("BodyTypeId")]
		public BodyType? BodyType { get; set; }

		[Column("a_place_count")]
		public byte PlaceCount { get; set; }

		[Column("a_prod_year")]
		public int ProductionYear { get; set; }

		public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
	}
}
