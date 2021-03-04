namespace finalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Meetings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? matchMakerId { get; set; }

        public int? firstParticipantId { get; set; }

        public int? secondParticipantId { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        public DateTime? date { get; set; }

        public virtual MatchMaker MatchMaker { get; set; }

        public virtual Participants Participants { get; set; }

        public virtual Participants Participants1 { get; set; }

        public virtual Participants Participants2 { get; set; }
    }
}
