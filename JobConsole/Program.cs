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
            Console.WriteLine(string.Format("Total des Video : {0} ",MyApp.Domain.Services.AssetService.GetTotalAssetParTypeId(1)));
            Console.WriteLine(string.Format("Total des Audio : {0} ", MyApp.Domain.Services.AssetService.GetTotalAssetParTypeId(2)));
            Console.WriteLine(string.Format("Total des Image : {0} ", MyApp.Domain.Services.AssetService.GetTotalAssetParTypeId(3)));
            Console.WriteLine(string.Format("Total des Streamers : {0} ", MyApp.Domain.Services.AssetService.GetTotalAssetParTypeId(4)));
            Console.WriteLine(string.Format("Total des Autres ressource : {0} ", MyApp.Domain.Services.AssetService.GetTotalAssetParTypeId(5)));
            Console.WriteLine(string.Format("Total des Assets : {0} ", MyApp.Domain.Services.AssetService.GetTotalAssets()));
            Console.WriteLine(string.Format("Type of Asset : {0} ", MyApp.Domain.Services.AssetService.GetNameAssetParTypeId(40)));
            //execution pour elastic search service methods

            MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.CreateIndex(); 
            Console.ReadLine();

        }
    }
}
