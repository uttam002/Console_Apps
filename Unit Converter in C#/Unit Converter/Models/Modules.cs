using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter.Models
{
    public class Modules
    {
        internal static List<string> GiveList(int index)
        {
            switch (index)
            {
                case 0:
                    return GetModulesOfLength();
                case 1:
                    return GetModulesOfMass();
                case 2:
                    return GetModulesOfVolume();
                case 3:
                    return GetModulesOfTemperature();
                case 4:
                    return GetModulesOfTime();
                case 5:
                    return GetModulesOfSpeed();
                case 6:
                    return GetModulesOfArea();
                case 7:
                    return GetModulesOfEnergy();
                case 8:
                    return GetModulesOfPower();
                case 9:
                    return GetModulesOfPressure();
                case 10:
                    return GetModulesOfDigitalStorage();
                case 11:
                    return GetModulesOfAngle();
                case 12:
                    return GetModulesOfFrequency();
                default:
                    throw new ArgumentOutOfRangeException("Invalid index provided.");
            }

        }
        internal static List<string> GetUnits(){

            return new List<string>
            {
            "Length",
            "Mass (Weight)",
            "Volume",
            "Temperature",
            "Time",
            "Speed",
            "Area",
            "Energy",
            "Power",
            "Pressure",
            "Digital Storage",
            "Angle",
            "Frequency"
            };
        }

        private static List<string> GetModulesOfLength(){
            return new List<string>
            {
                "Kilometer",
                "Meter",
                "Centimeter",
                "Millimeter",
                "Micrometer",
                "Nanometer",
                "Mile",
                "Yard",
                "Foot",
                "Inch",
                "Nautical Mile"
            };
        }
        internal static List<string> GetModulesOfMass(){
            return new List<string>
            {
                "Kilogram",
                "Gram",
                "Milligram",
                "Ton",
                "Pound",
                "Ounce",
                "Carat",
                "Atomic Mass Unit"
            };
        }
        internal static List<string> GetModulesOfVolume(){
            return new List<string>
            {
                "Cubic Kilometer",
                "Cubic Meter",
                "Cubic Centimeter",
                "Liter",
                "Milliliter",
                "US Gallon",
                "US Quart",
                "US Pint",
                "US Cup",
                "US Fluid Ounce",
                "US Table Spoon",
                "US Tea Spoon",
                "Cubic Mile",
                "Cubic Yard",
                "Cubic Foot",
                "Cubic Inch"
            };
        }
        internal static List<string> GetModulesOfTemperature(){
            return new List<string>
            {
                "Celsius",
                "Fahrenheit",
                "Kelvin"
            };
        }
        internal static List<string> GetModulesOfTime(){
            return new List<string>
            {
                "Nanosecond",
                "Microsecond",
                "Millisecond",
                "Second",
                "Minute",
                "Hour",
                "Day",
                "Week",
                "Month",
                "Year",
                "Decade",
                "Century"
            };
        }
        internal static List<string> GetModulesOfSpeed(){
            return new List<string>
            {
                "Meters per Second (m/s)",
                "Kilometers per Hour (km/h)",
                "Miles per Hour (mph)",
                "Feet per Second (ft/s)",
                "Knots (kn)"
            };
        }
        internal static List<string> GetModulesOfArea(){
            return new List<string>
            {
                "Square Millimeter (mm²)",
                "Square Centimeter (cm²)",
                "Square Meter (m²)",
                "Hectare (ha)",
                "Square Kilometer (km²)",
                "Square Inch (in²)",
                "Square Foot (ft²)",
                "Square Yard (yd²)",
                "Acre",
                "Square Mile (mi²)"
            };
        }
        internal static List<string> GetModulesOfEnergy(){
            return new List<string>
            {
                "Joule (J)",
                "Kilojoule (kJ)",
                "Gram Calorie",
                "Kilocalorie (kcal)",
                "Watt Hour (Wh)",
                "Kilowatt Hour (kWh)",
                "Electronvolt (eV)",
                "British Thermal Unit (BTU)",
                "US Therm",
                "Foot-Pound"
            };
        }
        internal static List<string> GetModulesOfPower(){
            return new List<string>
            {
                "Watt (W)",
                "Kilowatt (kW)",
                "Horsepower (hp)",
                "Foot-Pound per Minute",
                "BTU per Minute"
            };
        }
        internal static List<string> GetModulesOfPressure(){
            return new List<string>
            {
                "Pascal (Pa)",
                "Kilopascal (kPa)",
                "Hectopascal (hPa)",
                "Megapascal (MPa)",
                "Bar",
                "Millibar",
                "Microbar",
                "Millimeter of Mercury",
                "Inch of Mercury",
                "Pound per Square Inch (psi)",
                "Kilopound per Square Inch (ksi)"
            };
        }
        internal static List<string> GetModulesOfDigitalStorage(){
            return new List<string>
            {
                "Bit",
                "Byte",
                "Kilobit",
                "Kilobyte",
                "Megabit",
                "Megabyte",
                "Gigabit",
                "Gigabyte",
                "Terabit",
                "Terabyte",
                "Petabit",
                "Petabyte",
                "Exabit",
                "Exabyte"
            };
        }
        internal static List<string> GetModulesOfAngle(){
            return new List<string>
            {
                "Degree",
                "Radian",
                "Gradian",
                "Minute of Arc",
                "Second of Arc",
                "Gon",
                "Sign",
                "Mil",
                "Revolution",
                "Circle",
                "Right Angle",
                "Sextant",
                "Quadrant",
                "Octant"
            };
        }
        internal static List<string> GetModulesOfFrequency(){
            return new List<string>
            {
                "Hertz (Hz)",
                "Kilohertz (kHz)",
                "Megahertz (MHz)",
                "Gigahertz (GHz)",
                "Terahertz (THz)",
                "Petahertz (PHz)"
            };
        }
    }
}
