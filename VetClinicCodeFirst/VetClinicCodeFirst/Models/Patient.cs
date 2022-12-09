using System.ComponentModel.DataAnnotations;

namespace VetClinicCodeFirst.Models
{
	public class Patient
	{
		[Key]
		public int PatientId { get; set; }
		public string Name { get; set; }
		public string Breed { get; set; }
		public string OwnerInitials { get; set; }
		[MaxLength(10)]
		public string dateOfBirth { get; set; }
		public string Diagnosis { get; set; }
	}
}
