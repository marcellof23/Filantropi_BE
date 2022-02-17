using if3250_2022_19_filantropi_backend.Models;
using System.Collections.Generic;

namespace PostgresCRUD.DataAccess
{
  public interface IDataAccessProvider
  {
    void AddPatientRecord(User user);
    void UpdatePatientRecord(User user);
    void DeletePatientRecord(string id);
    User GetPatientSingleRecord(string id);
    List<User> GetPatientRecords();
  }
}
