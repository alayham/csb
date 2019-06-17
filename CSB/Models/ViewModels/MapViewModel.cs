using System.IO;
using Newtonsoft.Json;

namespace CSB.Models.ViewModels
{
    public class MapViewModel
    {
        public string RegionDataCache;
        public string RegionNameCache;

        public MapViewModel()
        {
            RegionDataCache = JsonConvert.SerializeObject(Data.GetDataForJs());
            RegionNameCache = JsonConvert.SerializeObject(Data.GetRegionListForJs());
        }
    }
}