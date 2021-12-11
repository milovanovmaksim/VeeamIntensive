using System;

namespace EventBusExample
{
    public class TemperatureSensor
    {
        private event EventHandler<TemperatureEventArgs> temperatureSensorEvent;
        public event EventHandler<TemperatureEventArgs> TemperatureSensorEvent
        {
            add
            {
                if (value.Target as EventBus == null)
                    throw new ArgumentException("The object on which the current delegate adds should be EventBus");

                else temperatureSensorEvent += value;
            }
            remove { temperatureSensorEvent -= value; }
        }
                       
        protected virtual void OnChengeTemp(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> temp = temperatureSensorEvent;
            temp?.Invoke(this, e);
        }

        public void Post(double temperature)
        {
            TemperatureEventArgs e = new TemperatureEventArgs(temperature);
            Console.WriteLine($"Publisher 'TemperatureSensor' public temperature: {e.Temperature}");

            OnChengeTemp(e);
        }
        
    }

    public class PressureSensor
    {
        public event EventHandler<PressureEventArgs> PressureSensorEvent;
        protected virtual void OnChangePressure(PressureEventArgs e)
        {
            EventHandler<PressureEventArgs> pressure = PressureSensorEvent;
            pressure?.Invoke(this, e);
            
        }

        public void Post(double pressure)
        {
            PressureEventArgs e = new PressureEventArgs(pressure);
            Console.WriteLine($"Plisher 'PressureSensor' public pressure: {e.Pressure}");
            OnChangePressure(e);
        }
    }
    
}