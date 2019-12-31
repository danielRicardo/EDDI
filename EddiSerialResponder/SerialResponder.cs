using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Eddi;
using EddiEvents;
using Utilities;

namespace EddiSerialResponder
{
    /// <summary>
    /// A responder that responds to events by sending data over a serial port
    /// Designed to be used as a framework for building physical cockpit panels that display the game status
    /// </summary>
    public class SerialResponder : EDDIResponder
    {
        public static readonly string LogFile = Constants.DATA_DIR + @"\serialresponder.out";
        
        protected static List<Event> eventQueue = new List<Event>();
        private static readonly object queueLock = new object();

        public string ResponderName()
        {
            return "Serial Responder";
        }

        public string LocalizedResponderName()
        {
            return Properties.SerialResponder.name;
        }

        public string ResponderDescription()
        {
            return Properties.SerialResponder.desc;
        }

        public bool Start()
        {
            EDDI.Instance.State["serialresponder_quiet"] = false;
            return true;
        }

        public void Stop()
        {
            EDDI.Instance.State["serialreponder_quiet"] = true;
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public UserControl ConfigurationTabItem()
        {
            throw new NotImplementedException();
        }

        public void Handle(Event @event)
        {
            if (@event.fromLoad)
            {
                return;
            }

            StatusMonitor status


        }
    }
}
