using System;


namespace EventBusExample
{
    
    public class Subscriber
    {
        public string Name;
        public void ShowTemperature(object sender, TemperatureEventArgs e)
        {
            Console.WriteLine($"Subscriber {Name}; Temperature = {e.Temperature}");
        }

        public void ShowPressure(object sender, PressureEventArgs e)
        {
            Console.WriteLine($"Subscriber {Name}; Pressure = {e.Pressure}");
        }

        public Subscriber(string name)
        {
            Name = name;
        }
        


    }
}