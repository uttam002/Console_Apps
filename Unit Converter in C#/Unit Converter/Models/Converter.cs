using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter.Models
{
    internal class Converter
    {
        Modules Modules = new Modules();

        private string unit;
        private int index1;
        private int index2;
        private double inputVal;
        public Converter(string unit, int index1, int index2, double inputVal)
        {
            this.unit = unit;
            this.index1 = index1;
            this.index2 = index2;
            this.inputVal = inputVal;
        }

        internal double Convert()
        {
            double result = 0;
            switch (unit)
            {
                case "Length":
                    result = LengthConverter.Convert(index1, index2, inputVal);
                    break;
                case "Mass (Weight)":
                    result = MassConverter.Convert(index1, index2, inputVal);
                    break;
                case "Volume":
                    result = VolumeConverter.Convert(index1, index2, inputVal);
                    break;
                case "Temperature":
                    result = TemperatureConverter.Convert(index1, index2, inputVal);
                    break;
                case "Time":
                    result = TimeConverter.Convert(index1, index2, inputVal);
                    break;
                case "Speed":
                    result = SpeedConverter.Convert(index1, index2, inputVal);
                    break;
                case "Area":
                    result = AreaConverter.Convert(index1, index2, inputVal);
                    break;
                case "Energy":
                    result = EnergyConverter.Convert(index1, index2, inputVal);
                    break;
                case "Power":
                    result = PowerConverter.Convert(index1, index2, inputVal);
                    break;
                case "Pressure":
                    result = PressureConverter.Convert(index1, index2, inputVal);
                    break;
                case "Digital Storage":
                    result = DigitalStorageConverter.Convert(index1, index2, inputVal);
                    break;
                case "Angle":
                    result = AngleConverter.Convert(index1, index2, inputVal);
                    break;
                case "Frequency":
                    result = FrequencyConverter.Convert(index1, index2, inputVal);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid unit provided.");
            }
            return result;
        }

    }

    internal class FrequencyConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1,                             // Hertz (Hz)
        1_000,                         // Kilohertz (kHz)
        1_000_000,                     // Megahertz (MHz)
        1_000_000_000,                 // Gigahertz (GHz)
        1_000_000_000_000,             // Terahertz (THz)
        1_000_000_000_000_000          // Petahertz (PHz)
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to Hertz (base unit)
            double valueInHertz = inputVal * conversionFactors[index1];

            // Convert the value from Hertz to the target unit
            double convertedValue = valueInHertz / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class AngleConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        Math.PI / 180,                // Degree (°)
        1,                            // Radian (rad)
        Math.PI / 200,                // Gradian (g)
        Math.PI / 10_800,             // Minute of Arc (')
        Math.PI / 648_000,            // Second of Arc (")
        Math.PI / 200,                // Gon (equivalent to Gradian)
        Math.PI / 6,                  // Sign
        2 * Math.PI / 6_400,          // Mil
        2 * Math.PI,                  // Revolution
        2 * Math.PI,                  // Circle (equivalent to Revolution)
        Math.PI / 2,                  // Right Angle
        Math.PI / 3,                  // Sextant
        Math.PI / 2,                  // Quadrant (equivalent to Right Angle)
        Math.PI / 4                   // Octant
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to Radians (base unit)
            double valueInRadians = inputVal * conversionFactors[index1];

            // Convert the value from Radians to the target unit
            double convertedValue = valueInRadians / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class DataStorageConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1.0 / 8,                       // Bit
        1,                             // Byte
        125,                           // Kilobit (Kb)
        1000,                          // Kilobyte (KB)
        125_000,                       // Megabit (Mb)
        1_000_000,                     // Megabyte (MB)
        125_000_000,                   // Gigabit (Gb)
        1_000_000_000,                 // Gigabyte (GB)
        125_000_000_000,               // Terabit (Tb)
        1_000_000_000_000,             // Terabyte (TB)
        125_000_000_000_000,           // Petabit (Pb)
        1_000_000_000_000_000,         // Petabyte (PB)
        125_000_000_000_000_000,       // Exabit (Eb)
        1_000_000_000_000_000_000      // Exabyte (EB)
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to Bytes (base unit)
            double valueInBytes = inputVal * conversionFactors[index1];

            // Convert the value from Bytes to the target unit
            double convertedValue = valueInBytes / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class PressureConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1,               // Pascal (Pa)
        1000,            // Kilopascal (kPa)
        100,             // Hectopascal (hPa)
        1000000,       // Megapascal (MPa)
        100000,         // Bar
        100,             // Millibar
        0.1,             // Microbar
        133.322,         // Millimeter of Mercury (mmHg)
        3386.39,         // Inch of Mercury (inHg)
        6894.76,         // Pound per Square Inch (psi)
        6894760        // Kilopound per Square Inch (ksi)
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to Pascals (base unit)
            double valueInPascals = inputVal * conversionFactors[index1];

            // Convert the value from Pascals to the target unit
            double convertedValue = valueInPascals / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class PowerConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1,            // Watt (W)
        1000,         // Kilowatt (kW)
        745.7,        // Horsepower (hp)
        0.022597,     // Foot-Pound per Minute
        17.584        // BTU per Minute
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to watts (base unit)
            double valueInWatts = inputVal * conversionFactors[index1];

            // Convert the value from watts to the target unit
            double convertedValue = valueInWatts / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class EnergyConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1,                    // Joule (J)
        1000,                 // Kilojoule (kJ)
        4.184,                // Gram Calorie (cal)
        4184,                 // Kilocalorie (kcal)
        3600,                 // Watt Hour (Wh)
        3.6e6,                // Kilowatt Hour (kWh)
        1.60218e-19,          // Electronvolt (eV)
        1055.06,              // British Thermal Unit (BTU)
        1.055e8,              // US Therm
        1.35582               // Foot-Pound
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to joules (base unit)
            double valueInJoules = inputVal * conversionFactors[index1];

            // Convert the value from joules to the target unit
            double convertedValue = valueInJoules / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class AreaConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1e-6,         // Square Millimeter (mm²)
        1e-4,         // Square Centimeter (cm²)
        1,            // Square Meter (m²)
        10000,        // Hectare (ha)
        1e6,          // Square Kilometer (km²)
        0.00064516,   // Square Inch (in²)
        0.092903,     // Square Foot (ft²)
        0.836127,     // Square Yard (yd²)
        4046.86,      // Acre
        2_589_988     // Square Mile (mi²)
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to square meters (base unit)
            double valueInSquareMeters = inputVal * conversionFactors[index1];

            // Convert the value from square meters to the target unit
            double convertedValue = valueInSquareMeters / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class SpeedConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1,             // Meters per Second (m/s)
        1 / 3.6,       // Kilometers per Hour (km/h)
        0.44704,       // Miles per Hour (mph)
        0.3048,        // Feet per Second (ft/s)
        0.514444       // Knots (kn)
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to meters per second (base unit)
            double valueInMetersPerSecond = inputVal * conversionFactors[index1];

            // Convert the value from meters per second to the target unit
            double convertedValue = valueInMetersPerSecond / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class TimeConverter
    {
        private static readonly double[] conversionFactors = new double[]
        {
        1e-9,          // Nanosecond
        1e-6,          // Microsecond
        0.001,         // Millisecond
        1,             // Second
        60,            // Minute
        3600,          // Hour
        86400,         // Day
        604800,        // Week
        2628000,       // Month (average)
        31536000,      // Year (non-leap)
        315360000,     // Decade
        3153600000     // Century
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value to seconds (base unit)
            double valueInSeconds = inputVal * conversionFactors[index1];

            // Convert the value from seconds to the target unit
            double convertedValue = valueInSeconds / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class TemperatureConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            // If both indices are the same, no conversion is necessary
            if (index1 == index2)
                return inputVal;

            double tempInCelsius;

            // Convert input to Celsius first (if necessary)
            switch (index1)
            {
                case 0: // Celsius to Celsius
                    tempInCelsius = inputVal;
                    break;
                case 1: // Fahrenheit to Celsius
                    tempInCelsius = (inputVal - 32) * 5 / 9;
                    break;
                case 2: // Kelvin to Celsius
                    tempInCelsius = inputVal - 273.15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert from Celsius to the target unit
            switch (index2)
            {
                case 0: // Celsius
                    return tempInCelsius;
                case 1: // Celsius to Fahrenheit
                    return tempInCelsius * 9 / 5 + 32;
                case 2: // Celsius to Kelvin
                    return tempInCelsius + 273.15;
                default:
                    throw new ArgumentOutOfRangeException("Invalid unit index");
            }
        }
    }


    internal class VolumeConverter
    {
        // Conversion factors to cubic meters for each unit
        private static readonly double[] conversionFactors = new double[]
        {
        1e9,                   // Cubic Kilometer to Cubic Meter
        1,                     // Cubic Meter to Cubic Meter
        1e-6,                  // Cubic Centimeter to Cubic Meter
        0.001,                 // Liter to Cubic Meter
        1e-6,                  // Milliliter to Cubic Meter
        0.00378541,            // US Gallon to Cubic Meter
        0.000946353,           // US Quart to Cubic Meter
        0.000473176,           // US Pint to Cubic Meter
        0.000236588,           // US Cup to Cubic Meter
        2.95735e-5,            // US Fluid Ounce to Cubic Meter
        1.47868e-5,            // US Tablespoon to Cubic Meter
        4.92892e-6,            // US Teaspoon to Cubic Meter
        4.16818e9,             // Cubic Mile to Cubic Meter
        0.764555,              // Cubic Yard to Cubic Meter
        0.0283168,             // Cubic Foot to Cubic Meter
        1.63871e-5             // Cubic Inch to Cubic Meter
        };

        // Method to convert between different volume units
        internal static double Convert(int index1, int index2, double inputVal)
        {
            // Validate that the indices are within range of the array
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value from the original unit to cubic meters (base unit)
            double valueInCubicMeters = inputVal * conversionFactors[index1];

            // Convert the value from cubic meters to the target unit
            double convertedValue = valueInCubicMeters / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class MassConverter
    {
        // Conversion factors to kilograms for each unit
        private static readonly double[] conversionFactors = new double[]
        {
        1,                      // Kilogram to Kilogram
        0.001,                  // Gram to Kilogram
        0.000001,               // Milligram to Kilogram
        1000,                   // Ton to Kilogram
        0.453592,               // Pound to Kilogram
        0.0283495,              // Ounce to Kilogram
        0.0002,                 // Carat to Kilogram
        1.66053906660e-27       // Atomic Mass Unit to Kilogram
        };

        // Method to convert between different mass units
        internal static double Convert(int index1, int index2, double inputVal)
        {
            // Validate that the indices are within range of the array
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid unit index");
            }

            // Convert the input value from the original unit to kilograms (base unit)
            double valueInKilograms = inputVal * conversionFactors[index1];

            // Convert the value from kilograms to the target unit
            double convertedValue = valueInKilograms / conversionFactors[index2];

            return convertedValue;
        }
    }


    internal class LengthConverter
    {
        // Conversion factors to meters for each unit
        private static readonly double[] conversionFactors = new double[]
        {
        1000,       // Kilometer to Meter
        1,          // Meter to Meter
        0.01,       // Centimeter to Meter
        0.001,      // Millimeter to Meter
        1e-6,       // Micrometer to Meter
        1e-9,       // Nanometer to Meter
        1609.34,    // Mile to Meter
        0.9144,     // Yard to Meter
        0.3048,     // Foot to Meter
        0.0254,     // Inch to Meter
        1852        // Nautical Mile to Meter
        };

        internal static double Convert(int index1, int index2, double inputVal)
        {
            // Validate that the indices are within range of the array
            if (index1 < 0 || index1 >= conversionFactors.Length || index2 < 0 || index2 >= conversionFactors.Length)
                throw new ArgumentOutOfRangeException("Invalid unit index");


            // Convert the input value from the original unit to meters (base unit)
            double valueInMeters = inputVal * conversionFactors[index1];

            // Convert the value from meters to the target unit
            double convertedValue = valueInMeters / conversionFactors[index2];

            return convertedValue;
        }
    }
}
