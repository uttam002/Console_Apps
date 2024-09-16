using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter.Models
{
    internal class Controller
    {
        Grid Grid = new Grid();
        Modules Modules = new Modules();
        Converter Converter;
        public void StartApp()
        {
            int unit = 0;//index of Unit type
            int subUnit1 = 0;//index of Unit1
            int subUnit2 = 0;//index of Unit2
            String title = string.Empty;
            List<string> unitTypes;
            List<string> units;
            double inputVal = 0;




            title = "Welcome to Unit Converter App";
            Grid.Welcomegrid(title);

            title = "Choose type of Units";
            unitTypes = Modules.GetUnits();
            unit = Grid.ShowMenu(title,unitTypes);

            units = Modules.GiveList(unit);

            //For Unit1
            title = "You Choose " + unitTypes[unit]+"\n Now Select Unit1";
            subUnit1 = Grid.ShowMenu(title,units);
            //For Unit2
            title = $"You Choose {unitTypes[unit]}\nYou select {units[subUnit1]}\nNow Select Unit2";
            subUnit2 = Grid.ShowMenu(title,units);

            inputVal = Grid.GetUnitValue(unitTypes[unit]); 
            
            Converter = new Converter(unitTypes[unit], subUnit1, subUnit2, inputVal);

            double result = Converter.Convert();
            Console.WriteLine(result);
        }
        
    }
}
