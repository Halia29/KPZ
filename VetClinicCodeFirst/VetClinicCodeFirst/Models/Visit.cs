using System.ComponentModel.DataAnnotations;

namespace VetClinicCodeFirst.Models
{
	public class Visit
	{
		[Key]
		public int VisitId { get; set; }
		[MaxLength(10)]
		public string dateOfVisit { get; set; }
		[MaxLength(5)]
		public string timeOfVisit { get; set; }
		public virtual Patient patient { get; set; }
	}
}
