using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBDevOps.Models
{
    public class HPALM_SnapshotView1
    {
        public string ReleaseBundle { get; set; }
        public string FixingTeam { get; set; }
        public string DefectID { get; set; }
        public string ITSRIncidentNumber { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public string Vertical { get; set; }
        public string Severity { get; set; }
        public string IncidentPriority { get; set; }
        public string DefectCategory { get; set; }
        public string PlannedReleaseDate { get; set; }
        public string ITSRReleaseRequestComments { get; set; }
        public string ArchitecturalReview { get; set; }
        public string Developer { get; set; }
        public string Project { get; set; }
        public string Integrated { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        //public string IsNew { get; set; }
    }
}
