export class HPALMSnapshotModel {
  releaseBundle: string;
  fixingTeam: string;
  defectID: string;
  itsrIncidentNumber: string;
  status: string;
  assignedTo: string;
  vertical: string;
  Sseverity: string;
  incidentPriority: string;
  defectCategory: string;
  plannedReleaseDate: string;
  itsrReleaseRequestComments: string;
  architecturalReview: string;
  developer: string;
  project: string;
  integrated: string;
  description: string;
  summary: string;
}

export class HPALMSnapshotListModel {
  snapshotID: number;
  snapshotDateTime: Date;
  snapshotDateTimeString: string;
}
