using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab21
{
    public class ElectronicProduct : Product
    {
        public ElectronicProduct(string ProductName)
            : base(ProductName)
        {

        }
        public ElectronicProduct()
        {

        }
        public override string[] GetAllProperties()
        { 
            string[] properties = new string[4];
            properties[0] = "ScreenResolution";
            properties[1] = "RamSize";
            properties[2] = "HddSize";
            properties[3] = "CameraResolution";
            //properties[4] = "Name";
            return properties;
        }
        public string CameraResolution
        {
            get;
            set;
        }
        public string ScreenResolution
        {
            get;
            set;
        }
        public int RamSize
        {
            get;
            set;
        }
        public int HddSize
        {
            get;
            set;
        }
        public override  string ToString()
        {
            return (String.Format("Name = {0}, Price = {1}, Manufacter = {2}", Name, Price, Manufacter));
        }
        public override string GetProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "ScreenResolution":
                  return ScreenResolution;
                    break;
                case "CameraResolution":
                    return CameraResolution;
                    break;
                case "Name":
                    return Name;
                    break;
                case "RamSize":
                    return RamSize.ToString();
                    break;
                case "HddSize":
                    return HddSize.ToString();
                    break;
                default:
                    return "";
                //break;
            }
        }
        public override bool SetProperty(string propertyName, string value)
        { 
              switch (propertyName)
              {
                  case "ScreenResolution":
                      ScreenResolution = value;
                      return true;
                      break;
                  case "RamSize":
                      RamSize = int.Parse(value);
                      return true;
                      break;
                  case "HddSize":
                      HddSize = int.Parse(value);
                      return true;
                      break;
                  case "CameraResolution":
                      CameraResolution = value;
                      return true;
                      break;
                  default:
                      return false;
                      //break;
              }
        }
    }
}
