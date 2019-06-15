using CSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSB
{
    public static class Data
    {
        public static int StartYear = 2010;
        public static int EndYear = 2014;
        public static RawMetaData rawMetaData;
        public static RawData rawData;
        public static Dictionary<string, string> RegionNameCache = new Dictionary<string, string>();
        public static Dictionary<string, string> RegionKeyCache = new Dictionary<string, string>();
        public static Dictionary<string, int> RegionIndexCache = new Dictionary<string, int>();
        public static Dictionary<string, List<int>> RegionHierachicalCache = new Dictionary<string, List<int>>();
        public static Dictionary<string, string> RegionCommentCache;
        public static Dictionary<string, string> YearCommentCache;
        
        public static void SetData(RawData data)
        {
            rawData = data;
            RegionCommentCache = new Dictionary<string, string>();
            YearCommentCache = new Dictionary<string, string>();
            foreach (Comment comment in data.comments)
            {
                switch (comment.variable)
                {
                    case "Region":
                        RegionCommentCache.Add(comment.value, comment.comment.Replace('"', '\''));
                        break;
                    case "Tid":
                        YearCommentCache.Add(comment.value, comment.comment.Replace('"', '\''));
                        break;
                }
            }

        }

        public static List<int> YearList()
        {
            List<int> list = new List<int>();
            for (int i = StartYear; i <= EndYear; i++)
                list.Add(i);
            return list;
        }

        public static string GetGenderForKey(string key)
        {
            return key == "1" ? "Män" : "Kvinnor";
        }

        public static string GetRegionName(string key)
        {
            if (RegionNameCache.ContainsKey(key))
            {
                return RegionNameCache[key];
            }
            int index = Array.FindIndex(rawMetaData.variables[0].values, value => value == key);
            if(index >= 0)
            {
                string name = rawMetaData.variables[0].valueTexts[index];
                SaveRegionCache(key, name);
                return name;
            }
            return key;
        }
        
        public static string GetRegionKey(string name)
        {
            if (RegionKeyCache.ContainsKey(name))
            {
                return RegionKeyCache[name];
            }
            int index = Array.FindIndex(rawMetaData.variables[0].valueTexts, value => value == name);
            if(index >= 0)
            {
                string key = rawMetaData.variables[0].values[index];
                SaveRegionCache(key, name);
                return key;
            }
            return name;
        }

        public static string GetRegionKey(int index)
        {
            return rawData.data[index].Key[0];
        }

        public static string GetRegionName(int index)
        {
            return GetRegionName(GetRegionKey(index));
        }
        public static int getRegionIndex(string key)
        {
            if (RegionIndexCache.ContainsKey(key))
            {
                return RegionIndexCache[key];
            }

            int index = Array.FindIndex(rawData.data, value => value.Key[0] == key);
            if (index >= 0)
            {
                SaveRegionCache(index, key);
                return index;
            }
            return 0; // returning 0 to avoid an exception. To DO: Proper handling.
        }
        public static bool IsSummaryRow(string key)
        {
            return key.Length == 2;
        }

        public static List<int> GetBirthDataForIndex(int index)
        {
            List<int> values = new List<int>();
            int start = FirstRowOfRegion(index);
            int i = 0;
            while (SameRegion(start, start + i))
            {
                values.Add(GetValueOfRow(start + i));
                i++;
            }
            return values;
        }

        public static List<string[]> GetBirthDataLabelsForIndex(int index)
        {
            List<string[]> values = new List<string[]>();
            int start = FirstRowOfRegion(index);
            int i = 0;
            while (SameRegion(start, start + i))
            {
                string[] value = new string[2];
                value[0] = rawData.data[index].Key[0];
                value[1] = GetGenderForKey(rawData.data[index].Key[2]);
                values.Add(value);
                i++;
            }
            return values;
        }

        public static List<int> GetMenBirthDataForIndex(int index)
        {
            List<int> values = new List<int>();
            int start = FirstRowOfRegion(index);
            int i = 0;
            while ((start < rawData.data.Count() - 2) && SameSex(start, start + i))
            {
                values.Add(GetValueOfRow(start + i));
                i++;
            }
            return values;
        }

        public static List<int> GetWomenBirthDataForIndex(int index)
        {
            List<int> values = new List<int>();
            int start = FirstRowOfRegion(index);
            start += EndYear - StartYear + 1;
            int i = 0;
            while (SameSex(start, start + i))
            {
                values.Add(GetValueOfRow(start + i));
                i++;
            }
            return values;
        }

        public static int GetValueOfRow(int index)
        {
            int.TryParse(Data.rawData.data[index].values[0], out int value);
            return value;
        }

        public static bool SameRegion(int index1, int index2)
        {
            bool condition = index1 < rawData.data.Count() && index2 < rawData.data.Count() && rawData.data[index1].Key[0] == Data.rawData.data[index2].Key[0];
            return condition;
        }

        public static bool SameSex(int index1, int index2)
        {
            bool condition = index1 < rawData.data.Count() && index2 < rawData.data.Count() && rawData.data[index1].Key[2] == Data.rawData.data[index2].Key[2];
            return condition;
        }
        
        public static int FirstRowOfRegion(int index)
        {
            if (index == 0) return index;
            if (!SameRegion(index, index - 1)) return index;
            // Recursive
            return FirstRowOfRegion(index - 1);
        }

        public static int IndexOfNextRegion(int index)
        {
            int count = rawData.data.Count();
            if (index >= count - 2) return 0;
            if (!SameRegion(index, index + 1)) return index + 1;
            // recursive
            return IndexOfNextRegion(index + 1);
        }

        public static void SaveRegionCache(string key, string name)
        {
            if (!RegionNameCache.ContainsKey(key)) RegionNameCache.Add(key, name);
            if (!RegionKeyCache.ContainsKey(name)) RegionKeyCache.Add(name, key);
        }


        public static void SaveRegionCache(int index, string key, string name)
        {
            if (!RegionNameCache.ContainsKey(key)) RegionNameCache.Add(key, name);
            if (!RegionIndexCache.ContainsKey(key)) RegionIndexCache.Add(key, index);
            if (!RegionKeyCache.ContainsKey(name)) RegionKeyCache.Add(name, key);
        }

        public static void SaveRegionCache(int index, string key)
        {
            if (!RegionIndexCache.ContainsKey(key)) RegionIndexCache.Add(key, index);
        }

        public static Dictionary<string, List<int>> GetRegionHierachicalCache()
        {
            if (RegionHierachicalCache.ContainsKey("00"))
            {
                return RegionHierachicalCache;
            }
            for(int i = 10; i<rawData.data.Count(); i += 10)
            {
                string key = rawData.data[i].Key[0];
                if (IsSummaryRow(rawData.data[i].Key[0]))
                {
                    if (!RegionHierachicalCache.ContainsKey(key))
                    {
                        RegionHierachicalCache.Add(key, new List<int>());
                    } else
                    {
                    }
                } else
                {
                    string parent = key.Substring(0, 2);
                    if (!RegionHierachicalCache.ContainsKey(parent))
                    {
                        RegionHierachicalCache.Add(parent, new List<int>());
                    }
                    if (!RegionHierachicalCache[parent].Contains(i))
                    {
                        RegionHierachicalCache[parent].Add(i);
                    }
                }
            }
            return RegionHierachicalCache;
        }

    }
}