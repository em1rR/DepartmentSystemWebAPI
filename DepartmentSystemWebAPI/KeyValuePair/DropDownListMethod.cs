using DepartmentSystemWebAPI.Enums;

namespace DepartmentSystemWebAPI.KeyValuePair
{
    public class DropDownListMethod
    {
        public static List<DropDownGenderModel> MakeCreateList()
        {
            List<DropDownGenderModel> list = new List<DropDownGenderModel>();
            //list = ((Gender[])Enum.GetValues(typeof(Gender))).ToDictionary(k => k.ToString(), v => (byte)v);
            list = ((Gender[])Enum.GetValues(typeof(Gender))).Select(c => new DropDownGenderModel() { Value = (byte)c, Key = c.ToString() }).ToList();
            //list.Add(new DropDownGenderModel{ Key = "Select", Value = 0 });
            return list;

        }

        public static List<DropDownGenderModel> MakeSearchList()
        {
            List<DropDownGenderModel> list = new List<DropDownGenderModel>();
            //list = ((Gender[])Enum.GetValues(typeof(Gender))).ToDictionary(k => k.ToString(), v => (byte)v);
            list = ((Gender[])Enum.GetValues(typeof(Gender))).Select(c => new DropDownGenderModel() { Value = (byte)c, Key = c.ToString() }).ToList();
            //list.Add(new DropDownGenderModel { Key = "All", Value = 0 });
            list.Insert(0,new DropDownGenderModel { Key = "All", Value = 0 });
            return list;

        }
    }
}
