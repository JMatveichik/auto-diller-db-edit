using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Models
{
	[Table("au_contracts")]
	public class Contract
	{
		[Key]
		[Column("c_id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("c_user_id")]
		public int UserId { get; set; }

		[Column("c_dealer_id")]
		public int DealerId { get; set; }

		[Column("c_auto_id")]
		public int AutoId { get; set; }

		[Column("c_equip_id")]
		public int EquipmentId { get; set; }

		[Column("c_warranty_id")]
		public int WarrantyId { get; set; }

		[Column("c_data")]
		public DateTime ContractDate { get; set; } = DateTime.Now;

		[ForeignKey("UserId")]
		public User? User { get; set; }

		[ForeignKey("DealerId")]
		public Dealer? Dealer { get; set; }

		[ForeignKey("AutoId")]
		public Automobile? Automobile { get; set; }

		[ForeignKey("AutoId, EquipmentId")]
		public Equipment? Equipment { get; set; }

		[ForeignKey("WarrantyId")]
		public Warranty? Warranty { get; set; }

	}
}
