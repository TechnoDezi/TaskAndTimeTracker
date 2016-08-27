using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAndTimeTracker.Classes.Indexes;

namespace TaskAndTimeTracker.Classes
{
    public class DataDocumentStore
    {
        private static IDocumentStore instance;

        public static IDocumentStore Instance
        {
            get
            {
                if (instance == null)
                    Initialize();
                return instance;
            }
        }

        public static IDocumentStore Initialize()
        {
            instance = new EmbeddableDocumentStore { ConnectionStringName = "RavenDB" };
            instance.Conventions.IdentityPartsSeparator = "-";
            instance.Initialize();
            IndexCreation.CreateIndexes(typeof(TimeLog_Description).Assembly, instance);
            return instance;
        }
    }
}
