using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Domain.Entities
{
	[Table("product")]
	public record Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("product_name")]
		[MaxLength(100)]
		public string? ProductName { get; set; }

		[Column("product_code")]
		[MaxLength(10)]
		public string? ProductCode { get; set; }
		[Column("price", TypeName = "decimal(7,2)")]
		public decimal? Price { get; set; }

	}
}
