using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSB.Models;

namespace CSB.Models.ViewModels
{
    public class RegionViewModel
    {
        public int Index;
        public string Key;
        public string Name;
        public List<int> Men;
        public List<int> Women;
        public List<int> Years;

        public RegionViewModel(int index)
        {
            Index = index;
            Key = Data.GetRegionKey(index);
            Name = Data.GetRegionName(index);
            Men = Data.GetMenBirthDataForIndex(index);
            Women = Data.GetWomenBirthDataForIndex(index);
            Years = Data.YearList();
        }

    }
}