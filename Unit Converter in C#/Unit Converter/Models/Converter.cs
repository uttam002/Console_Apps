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
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class AngleConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class DigitalStorageConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class PressureConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class PowerConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class EnergyConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class AreaConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class SpeedConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
        }
    }

    internal class TimeConverter
    {
        internal static double Convert(int index1, int index2, double inputVal)
        {
            throw new NotImplementedException();
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
