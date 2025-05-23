using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Models
{
	[Table("au_equipments")]
	internal class Equipment
	{
		[Key]
		[Column("e_auto_id")]
		public int AutoId { get; set; }

		[Key]
		[Column("e_id")]
		public int Id { get; set; }

		[Column("e_name")]
		[MaxLength(70)]
		public string Name { get; set; } = "default";

		[Required]
		[Column("e_engine_name")]
		[MaxLength(70)]
		public string? EngineName { get; set; }

		[Column("e_engine_id")]
		public int EngineTypeId { get; set; }

		[Column("e_engine_volume")]
		public float EngineVolume { get; set; }

		[Column("e_horse_power")]
		public int HorsePower { get; set; }

		[Column("e_susp_id")]
		public int SuspensionTypeId { get; set; }

		[Column("e_drive_id")]
		public int DriveTypeId { get; set; }

		[Column("e_gearbox_id")]
		public int GearboxTypeId { get; set; }

		[Column("e_speed_count")]
		public int SpeedCount { get; set; }

		[Column("e_fuel_id")]
		public int FuelTypeId { get; set; }

		[Required]
		[Column("e_interior")]
		[MaxLength(70)]
		public string? Interior { get; set; }

		[Required]
		[Column("e_body_kit")]
		[MaxLength(70)]
		public string? BodyKit { get; set; }

		[Column("e_weight")]
		public int Weight { get; set; }

		[Column("e_price")]
		public decimal Price { get; set; }

		[Column("e_image")]
		[MaxLength(255)]
		public string? Image { get; set; }

		[ForeignKey("AutoId")]
		public Automobile? Automobile { get; set; }


	}
}
