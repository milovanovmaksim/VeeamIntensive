using System;


namespace EventBusExample
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            var tempSensor = new TemperatureSensor();
            var pressureSensor = new PressureSensor();
            var eventBus = new EventBus(tempSensor, pressureSensor);
            var subscriber = new Subscriber("#1");
            var subscriber2 = new Subscriber("#2");
            eventBus.ChangeTemperatureEvent += subscriber.ShowTemperature;
            eventBus.ChangePressureEvent += subscriber2.ShowPressure;
            tempSensor.Post(65.6);
            pressureSensor.Post(4565.65);
            eventBus.ChangePressureEvent -= subscriber2.ShowPressure;
        }
    }

    
}
