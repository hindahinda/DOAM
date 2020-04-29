using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobConsole
{
    class Program
    {
        static void Main(string[] args)  
        {
         
            
            //lancement d'elastic search index pour actualiser les données

            MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.CreateIndex();
            Console.ReadLine();

           
        }
    }
}
