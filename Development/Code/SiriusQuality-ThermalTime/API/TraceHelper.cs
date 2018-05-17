/*
     -------------------------------------------------------------
     
     Code generated by CRA.ModelLayer.ACC - API Code Generator
     http://components.biomamodelling.org/components/acc/help/ 

     MyName MyLastname
     myemail@mydomain.com
     MyInstitution
     25/11/2016 20:20:50

     -------------------------------------------------------------
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SiriusQualityThermalTime
{
    public static class TraceHelper
    {
        static private System.Diagnostics.TraceSource Source = 
		    new System.Diagnostics.TraceSource(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

        /// <summary>
        /// Writes a trace event message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        /// collection using the specified event type, event identifier, and message.
        /// </summary>
        /// <param name="eventType">One of the System.Diagnostics.TraceEventType values that specifies the event type of the trace data.</param>
        /// <param name="id">A numeric identifier for the event</param>
        /// <param name="message">The trace message to write</param>
        [System.Diagnostics.Conditional("TRACE")]
        public static void TraceEvent(System.Diagnostics.TraceEventType eventType, int id, string message)
        {
            Source.TraceEvent(eventType, id, message);
            Source.Flush();
        }

        public static void AddListener(TraceListener listener)
        {
            Source.Listeners.Add(listener);
            Source.Switch.Level = ~SourceLevels.Off;
        }
	}
}
