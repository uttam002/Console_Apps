using System;
using Unit_Converter.Models;

namespace UnitConverter
{
    class Program 
    {
        public static void Main(string[] args)
        {
            Controller _controller = new Controller();
         
            _controller.StartApp();
            //Converter converter = new Converter(unit);
        }
    }

}
