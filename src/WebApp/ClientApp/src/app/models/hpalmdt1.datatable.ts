export interface IHPALMDt1 {
  ReleaseBundle: string;
  FixingTeam: string;
  DefectID: string;
  ITSRIncidentNumber: string;
  Status: string;
  AssignedTo: string;
  Vertical: string;
  Severity: string;
  IncidentPriority: string;
  DefectCategory: string;
  PlannedReleaseDate: string;
  ITSRReleaseRequestComments: string;
  ArchitecturalReview: string;
  Developer: string;
  Project: string;
  Integrated: string;
  Description: string;
  Summary: string;
  IsNew: string;
}


export class HPALMDt1 {
  ReleaseBundle: string;
  FixingTeam: string;
  DefectID: string;
  ITSRIncidentNumber: string;
  Status: string;
  AssignedTo: string;
  Vertical: string;
  Severity: string;
  IncidentPriority: string;
  DefectCategory: string;
  PlannedReleaseDate: string;
  ITSRReleaseRequestComments: string;
  ArchitecturalReview: string;
  Developer: string;
  Project: string;
  Integrated: string;
  Description: string;
  Summary: string;
  IsNew: string;

  constructor(ReleaseBundle: string,
    FixingTeam: string,
    DefectID: string,
    ITSRIncidentNumber: string,
    Status: string,
    AssignedTo: string,
    Vertical: string,
    Severity: string,
    IncidentPriority: string,
    DefectCategory: string,
    PlannedReleaseDate: string,
    ITSRReleaseRequestComments: string,
    ArchitecturalReview: string,
    Developer: string,
    Project: string,
    Integrated: string,
    Description: string,
    Summary: string,
    IsNew: string) {
    this.ReleaseBundle = ReleaseBundle;
    this.FixingTeam = FixingTeam;
    this.DefectID = DefectID;
    this.ITSRIncidentNumber = ITSRIncidentNumber;
    this.Status = Status;
    this.AssignedTo = AssignedTo;
    this.Vertical = Vertical;
    this.Severity = Severity;
    this.IncidentPriority = IncidentPriority;
    this.DefectCategory = DefectCategory;
    this.PlannedReleaseDate = PlannedReleaseDate;
    this.ITSRReleaseRequestComments = ITSRReleaseRequestComments;
    this.ArchitecturalReview = ArchitecturalReview;
    this.Developer = Developer;
    this.Project = Project;
    this.Integrated = Integrated;
    this.Description = Description;
    this.Summary = Summary;
    this.IsNew = IsNew;
  }
}

