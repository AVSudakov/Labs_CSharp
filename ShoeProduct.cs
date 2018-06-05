using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    public class ShoeProduct : Product
    {
        public ShoeProduct(string ProductName)
            : base(ProductName)
        {
 
        }
        public override string[] GetAllProperties()
        {
            string[] properties = new string[3];
            properties[0] = "Size";
            properties[1] = "Season";
            properties[2] = "TargetGender";
            return properties;
        }
        public byte Size
        {
            get;
            set;
        }
        public TargetGenders TargetGender
        {
            get;
            set;
        }
        public Seasons Season
        {
            get;
            set;
        }
        override public string ToString()
        {
            return (String.Format("Name = {0}, Price = {1}, Manufacter = {2}", Name, Price, Manufacter));
        }
        public override string GetProperty(string propertyName)
        {
             switch (propertyName)
            {
                case "Size":
                    return Size.ToString();
                    //break;
                case "Season":
                    return Season.ToString();
                    //break;
                case "TargetGender":
                    return TargetGender.ToString();
                //break;
                default:
                    return "";
                //break;
            }
        
        }
        public override bool SetProperty(string propertyName, string value)
        {
            switch (propertyName)
            {
                case "Size":
                    Size = byte.Parse(value);
                    return true;
                    //break;
                case "Season":
                    if (!Enum.IsDefined(typeof(Seasons), int.Parse(value)))
                        throw new IndexOutOfRangeException();
                    Season = (Seasons)int.Parse(value);
                    return true;
                //break;
                case "TargetGender":
                    if (!Enum.IsDefined(typeof(TargetGenders), int.Parse(value)))
                        throw new IndexOutOfRangeException();
                    TargetGender = (TargetGenders)int.Parse(value);
                    return true;
                //break;
                //case "Name":
                    //Name = value;
                    //return true;
                    //break;
                default:
                    return false;
                //break;
            }
        }
    }
}
