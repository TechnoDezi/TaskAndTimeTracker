using Raven.Abstractions.Indexing;
using Raven.Client.Document;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAndTimeTracker.Models;

namespace TaskAndTimeTracker.Classes.Indexes
{
    public class TimeLog_Description : AbstractIndexCreationTask<TimeLog>
    {
        public TimeLog_Description()
        {
            Map = timelog => from log in timelog
                             select new { log.Description, log.DateLogged };
            Index(x => x.Description, FieldIndexing.Analyzed);
        }
    }
}
