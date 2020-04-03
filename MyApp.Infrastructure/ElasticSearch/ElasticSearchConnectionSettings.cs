using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.ElasticSearch
{
   public class ElasticSearchConnectionSettings
    {
        static string elasticAdress = "http://localhost:9200";
        public static ElasticClient EsClient()
        {
            var nodes = new Uri(elasticAdress);

            var connectionSettings = new ConnectionSettings(nodes);
            connectionSettings.ThrowExceptions(alwaysThrow: true);
            connectionSettings.PrettyJson();
            var elasticClient = new ElasticClient(connectionSettings);

            return elasticClient;
        }
    }
}
