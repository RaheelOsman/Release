/*   
     ----------------------------------------------------------------
	 Code generated by CRA.ModelLayer.ACC - API Code Generator
     http://components.biomamodelling.org/components/acc/help/ 

     MyName MyLastname
     myemail@mydomain.com
     MyInstitution
     25/11/2016 20:20:50
	 ----------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Text;
using CRA.ModelLayer.Core;
using CRA.AgroManagement;

namespace SiriusQualityThermalTime
{
    /// <summary>
    /// SiriusQualityThermalTime component API 
    /// </summary>
    public class SiriusQualityThermalTimeAPI 
    {
        private string _resultPreConditions;
        private string _resultPostConditions;
        Preconditions p = new Preconditions();

        /// <summary>
        /// Calculate method for the component
        /// </summary>
        /// <param name=t>ThermalTimeState Domain class contains the accessors to values</param>
        public void Estimate
		(IStrategySiriusQualityThermalTime st, ThermalTimeState t)
        {
            st.Estimate
			( t);
        }
              
        /// <summary>
        /// Calculate method for the component with test of preconditions
        /// </summary>
        /// <param name=t>ThermalTimeState Domain class contains the accessors to values</param>
        /// <param name="saveLog">Save log via a writer or show on screen</param>
        /// <param name="callID">Context description for violations</param>
        public void Estimate
            (IStrategySiriusQualityThermalTime st, ThermalTimeState t, bool saveLog, string callID)        
           {
            _resultPreConditions = String.Empty;
            _resultPostConditions = String.Empty;
            _resultPreConditions = st.TestPreConditions( t, callID);
            st.Estimate
			( t);
            _resultPostConditions = st.TestPostConditions( t, callID);

            if (_resultPreConditions != String.Empty || _resultPostConditions != String.Empty)
            {
                p.TestsOut(_resultPreConditions + _resultPostConditions, saveLog, callID);
            }
        }

        /// <summary>
        /// Show the about form with access to the help and codedoc
        /// </summary>
        public void Info()
        {
            // The following assumes an about form called AboutBox
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }
    }
}
 
