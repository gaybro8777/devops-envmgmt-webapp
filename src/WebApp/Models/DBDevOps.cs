namespace DBDevOps.Models
{
      
  public class tblAppEnvs{
    public int AppEnvID { get; set; }
    public int ApplicationID { get; set; }
    public int EnvironmentID { get; set; }
  }

  public class AppEnvsByAppID
    {
      public int AppEnvID { get; set; }
      public int ApplicationID { get; set; }
      public int EnvironmentID { get; set; }
      public string EnvName { get; set; }
    }

  public class tblApplications{
    public int ApplicationID { get; set; }
    public int ProjectTeamID { get; set; }
    public string ApplicationName { get; set; }
  }
      
  public class tblEnvironments{
    public int EnvironmentID { get; set; }
    public string EnvName { get; set; }
  }
      
  public class tblEnvReqStatusTypes{
    public int EnvReqStatusTypesID { get; set; }
    public string Description { get; set; }
    public int OrderBy { get; set; }
  }
      
  public class tblEnvRequests{
    public int EnvRequestID { get; set; }
    public int RequestorID { get; set; }
    public int OwnerID { get; set; }
    public int ReleaseID { get; set; }
    public int ApplicationID { get; set; }
    public System.DateTime DateFrom { get; set; }
    public System.DateTime TimeFrom { get; set; }
    public System.DateTime DateTo { get; set; }
    public System.DateTime TimeTo { get; set; }
    public int EnvReqStatusTypesID { get; set; }
    public string Notes { get; set; }
  }
      
  public class tblEnvServers{
    public int EnvServerID { get; set; }
    public int EnvironmentID { get; set; }
    public int ServerID { get; set; }
  }
      
  public class tblEnvStatus{
    public int EnvStatusID { get; set; }
    public int AppEnvID { get; set; }
    public string AppVersion { get; set; }
    public string DatabaseVersion { get; set; }
    public System.DateTime DateTimeDeployed { get; set; }
  }
      
  public class tblProjectTeam{
    public int ProjectTeamID { get; set; }
    public string Name { get; set; }
    public int LeaderName { get; set; }
    public int IsActive { get; set; }
  }
      
  public class tblReleases{
    public int ReleaseID { get; set; }
    public string ReleaseName { get; set; }
    public System.DateTime ReleaseDate { get; set; }
  }
      
  public class tblRoles{
    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public int OrderBy { get; set; }
    public int IsAdmin { get; set; }
  }
      
  public class tblServers{
    public int ServerID { get; set; }
    public string ServerName { get; set; }
    public string ServerIPAddress { get; set; }
    public int ServerType { get; set; }
    public string URL { get; set; }
    public string DirectoryPath { get; set; }
    public int Owner { get; set; }
    public int IsActive { get; set; }
  }
      
  public class tblServerType{
    public int ServerTypeID { get; set; }
    public string ServerTypeDescr { get; set; }
  }
      
  public class tblUserRoles{
    public int UserRoleID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
  }
      
  public class tblUsers{
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int IsActive { get; set; }
  }
  
    public class apiResult
    {
        public string status { get; set; }
    }
}



