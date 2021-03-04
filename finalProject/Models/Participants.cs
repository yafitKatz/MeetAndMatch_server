namespace finalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participants()
        {
            Meetings = new HashSet<Meetings>();
            Meetings1 = new HashSet<Meetings>();
            Meetings2 = new HashSet<Meetings>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        public DateTime? dateOfBirth { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string origin { get; set; }

        [StringLength(100)]
        public string resume { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meetings> Meetings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meetings> Meetings1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meetings> Meetings2 { get; set; }

        public virtual Status Status1 { get; set; }
    }
}
