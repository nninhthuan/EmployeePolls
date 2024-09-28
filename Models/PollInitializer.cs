using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class PollInitializer : DropCreateDatabaseIfModelChanges<PollContext>
    {
    }
}