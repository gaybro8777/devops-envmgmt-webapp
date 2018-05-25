using System;
using System.Threading.Tasks;

namespace DBDevOps.Models
{
  
  public class TfsLabels{
    public int LabelId { get; set; }
    public string LabelName { get; set; }
    public string Comment { get; set; }
    public int Changeset { get; set; }
    public string ProjectName { get; set; }
    public string Path { get; set; }
    public DateTime LastModified { get; set; }
    public string User { get; set; }
  }

}