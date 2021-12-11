using System;
using System.Collections.Generic;


namespace EventBusExample
{
    
    sealed public class EventBus
    {
        private readonly TemperatureSensor tempSensor;
        private readonly PressureSensor pressureSensor;
        
        private readonly Dictionary<object, Delegate> events = new Dictionary<object, Delegate>(); 
        private void Publish(object sender, EventArgs e)
        {
            Delegate d;
            events.TryGetValue(sender, out d);
            d?.DynamicInvoke(this, e);
        }

        private void Subscribe(object sender, Delegate handler)
        {
            Delegate d;
            events.TryGetValue(sender, out d);
            events[sender] = Delegate.Combine(d, handler);
        }

        private void UnSubscribe(object sender, Delegate handler)
        {
            Delegate d;
            if (events.TryGetValue(sender, out d))
            {
                d = Delegate.Remove(d, handler);
                if (d != null) events[sender] = d;
                else events.Remove(sender);
            }
        }

        public event EventHandler<TemperatureEventArgs> ChangeTemperatureEvent
        {
            add { Subscribe(this.tempSensor, value); }
            remove { UnSubscribe(this.tempSensor, value); }
        }

        public event EventHandler<PressureEventArgs> ChangePressureEvent
        {
            add { Subscribe(this.pressureSensor, value); }
            remove { UnSubscribe(this.pressureSensor, value); }
        }
        
        public EventBus(TemperatureSensor tempSensor, PressureSensor pressureSensor)
        {
            this.tempSensor = tempSensor;
            this.pressureSensor = pressureSensor;
            
            // Подписываемся на издателя
            this.tempSensor.TemperatureSensorEvent += Publish;
            this.pressureSensor.PressureSensorEvent += Publish;

        }
    }
}