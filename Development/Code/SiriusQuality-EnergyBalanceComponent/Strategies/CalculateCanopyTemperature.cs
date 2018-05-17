

 //Author:pierre martre pierre.martre@supagro.inra.fr
 //Institution:Inra
 //Author of revision: 
 //Date first release:4/11/2016
 //Date of revision:

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;


using SiriusQualityEnergyBalance;


//To make this project compile please add the reference to assembly: SiriusQuality-EnergyBalanceComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace SiriusQualityEnergyBalance
{

	/// <summary>
	///Class CalculateCanopyTemperature
    /// 
    /// </summary>
	public class CalculateCanopyTemperature : IStrategySiriusQualityEnergyBalance
	{

	#region Constructor

			public CalculateCanopyTemperature()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 2.454;
				 v1.Description = "latent heat of vaporization of water";
				 v1.Id = 0;
				 v1.MaxValue = 10;
				 v1.MinValue = 0;
				 v1.Name = "lambda";
				 v1.Size = 1;
				 v1.Units = "?";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 1.225;
				 v2.Description = "Density of air";
				 v2.Id = 0;
				 v2.MaxValue = 10;
				 v2.MinValue = 0;
				 v2.Name = "rhoDensityAir";
				 v2.Size = 1;
				 v2.Units = "?";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				VarInfo v3 = new VarInfo();
				 v3.DefaultValue = 0.00101;
				 v3.Description = "Specific heat capacity of dry air";
				 v3.Id = 0;
				 v3.MaxValue = 1;
				 v3.MinValue = 0;
				 v3.Name = "specificHeatCapacityAir";
				 v3.Size = 1;
				 v3.Units = "?";
				 v3.URL = "";
				 v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v3);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd1.PropertyName = "minTair";
				pd1.PropertyType = (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minTair)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minTair);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd2.PropertyName = "maxTair";
				pd2.PropertyType = (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxTair)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxTair);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd3.PropertyName = "cropHeatFlux";
				pd3.PropertyType = (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.cropHeatFlux)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.cropHeatFlux);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd4.PropertyName = "conductance";
				pd4.PropertyType = (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.conductance)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.conductance);
				_inputs0_0.Add(pd4);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd5.PropertyName = "minCanopyTemperature";
				pd5.PropertyType =  (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minCanopyTemperature)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =(  SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minCanopyTemperature);
				_outputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(SiriusQualityEnergyBalance.EnergyBalanceState);
				pd6.PropertyName = "maxCanopyTemperature";
				pd6.PropertyType =  (( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxCanopyTemperature)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =(  SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxCanopyTemperature);
				_outputs0_0.Add(pd6);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager
				_modellingOptionsManager = new ModellingOptionsManager(mo0_0);
			
				SetStaticParametersVarInfoDefinitions();
				SetPublisherData();
					
			}

	#endregion

	#region Implementation of IAnnotatable

			/// <summary>
			/// Description of the model
			/// </summary>
			public string Description
			{
				get { return ""; }
			}
			
			/// <summary>
			/// URL to access the description of the model
			/// </summary>
			public string URL
			{
				get { return "http://biomamodelling.org"; }
			}
		

	#endregion
	
	#region Implementation of IStrategy

			/// <summary>
			/// Domain of the model.
			/// </summary>
			public string Domain
			{
				get {  return "EnergyBalance"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return ""; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
			}

			/// <summary>
			/// Timestep to be used with this strategy
			/// </summary>
			public IList<int> TimeStep
			{
				get
				{
					IList<int> ts = new List<int>();
					
					return ts;
				}
			}
	
	
	#region Publisher Data

			private PublisherData _pd;
			private  void SetPublisherData()
			{
					// Set publishers' data
					
				_pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
				_pd.Add("Creator", "pierre.martre@supagro.inra.fr");
				_pd.Add("Date", "4/11/2016");
				_pd.Add("Publisher", "Inra");
			}

			public PublisherData PublisherData
			{
				get { return _pd; }
			}

	#endregion

	#region ModellingOptionsManager

			private ModellingOptionsManager _modellingOptionsManager;
			
			public ModellingOptionsManager ModellingOptionsManager
			{
				get { return _modellingOptionsManager; }            
			}

	#endregion

			/// <summary>
			/// Return the types of the domain classes used by the strategy
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Type> GetStrategyDomainClassesTypes()
			{
				return new List<Type>() {  typeof(SiriusQualityEnergyBalance.EnergyBalanceState) };
			}

	#endregion

    #region Instances of the parameters
			
			// Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

			
			public Double lambda
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("lambda");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'lambda' not found (or found null) in strategy 'CalculateCanopyTemperature'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("lambda");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'lambda' not found in strategy 'CalculateCanopyTemperature'");
				}
			}
			public Double rhoDensityAir
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("rhoDensityAir");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'rhoDensityAir' not found (or found null) in strategy 'CalculateCanopyTemperature'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("rhoDensityAir");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'rhoDensityAir' not found in strategy 'CalculateCanopyTemperature'");
				}
			}
			public Double specificHeatCapacityAir
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("specificHeatCapacityAir");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'specificHeatCapacityAir' not found (or found null) in strategy 'CalculateCanopyTemperature'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("specificHeatCapacityAir");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'specificHeatCapacityAir' not found in strategy 'CalculateCanopyTemperature'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				 

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
					//Code written below will not be overwritten by a future code generation

					//Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
            }

	#endregion		

	#region Static parameters VarInfo definition

			// Define the properties of the static VarInfo of the parameters
			private static void SetStaticParametersVarInfoDefinitions()
			{                                
                lambdaVarInfo.Name = "lambda";
				lambdaVarInfo.Description =" latent heat of vaporization of water";
				lambdaVarInfo.MaxValue = 10;
				lambdaVarInfo.MinValue = 0;
				lambdaVarInfo.DefaultValue = 2.454;
				lambdaVarInfo.Units = "?";
				lambdaVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				rhoDensityAirVarInfo.Name = "rhoDensityAir";
				rhoDensityAirVarInfo.Description =" Density of air";
				rhoDensityAirVarInfo.MaxValue = 10;
				rhoDensityAirVarInfo.MinValue = 0;
				rhoDensityAirVarInfo.DefaultValue = 1.225;
				rhoDensityAirVarInfo.Units = "?";
				rhoDensityAirVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				specificHeatCapacityAirVarInfo.Name = "specificHeatCapacityAir";
				specificHeatCapacityAirVarInfo.Description =" Specific heat capacity of dry air";
				specificHeatCapacityAirVarInfo.MaxValue = 1;
				specificHeatCapacityAirVarInfo.MinValue = 0;
				specificHeatCapacityAirVarInfo.DefaultValue = 0.00101;
				specificHeatCapacityAirVarInfo.Units = "?";
				specificHeatCapacityAirVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _lambdaVarInfo= new VarInfo();
				/// <summary> 
				///lambda VarInfo definition
				/// </summary>
				public static VarInfo lambdaVarInfo
				{
					get { return _lambdaVarInfo; }
				}
				private static VarInfo _rhoDensityAirVarInfo= new VarInfo();
				/// <summary> 
				///rhoDensityAir VarInfo definition
				/// </summary>
				public static VarInfo rhoDensityAirVarInfo
				{
					get { return _rhoDensityAirVarInfo; }
				}
				private static VarInfo _specificHeatCapacityAirVarInfo= new VarInfo();
				/// <summary> 
				///specificHeatCapacityAir VarInfo definition
				/// </summary>
				public static VarInfo specificHeatCapacityAirVarInfo
				{
					get { return _specificHeatCapacityAirVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
						

	#endregion
	
	#region pre/post conditions management		

		    /// <summary>
			/// Test to verify the postconditions
			/// </summary>
			public string TestPostConditions(SiriusQualityEnergyBalance.EnergyBalanceState energybalancestate, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minCanopyTemperature.CurrentValue=energybalancestate.minCanopyTemperature;
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxCanopyTemperature.CurrentValue=energybalancestate.maxCanopyTemperature;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minCanopyTemperature);
					if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minCanopyTemperature.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxCanopyTemperature);
					if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxCanopyTemperature.ValueType)){prc.AddCondition(r6);}

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component SiriusQualityEnergyBalance, strategy " + this.GetType().Name ); }
					return postConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

					string msg = "Component SiriusQualityEnergyBalance, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
					throw new Exception(msg, exception);
				}
			}

			/// <summary>
			/// Test to verify the preconditions
			/// </summary>
			public string TestPreConditions(SiriusQualityEnergyBalance.EnergyBalanceState energybalancestate, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minTair.CurrentValue=energybalancestate.minTair;
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxTair.CurrentValue=energybalancestate.maxTair;
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.cropHeatFlux.CurrentValue=energybalancestate.cropHeatFlux;
					SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.conductance.CurrentValue=energybalancestate.conductance;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minTair);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.minTair.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxTair);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.maxTair.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.cropHeatFlux);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.cropHeatFlux.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.conductance);
					if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityEnergyBalance.EnergyBalanceStateVarInfo.conductance.ValueType)){prc.AddCondition(r4);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambda")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoDensityAir")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("specificHeatCapacityAir")));

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component SiriusQualityEnergyBalance, strategy " + this.GetType().Name ); }
					return preConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

					string msg = "Component SiriusQualityEnergyBalance, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
					throw new Exception(msg, exception);
				}
			}

		
	#endregion
		


	#region Model

		 	/// <summary>
			/// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
			/// </summary>
			public void Estimate(SiriusQualityEnergyBalance.EnergyBalanceState energybalancestate)
			{
				try
				{
					CalculateModel(energybalancestate);

					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

					string msg = "Error in component SiriusQualityEnergyBalance, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;				
					throw new Exception(msg, exception);
				}
			}

		

			private void CalculateModel(SiriusQualityEnergyBalance.EnergyBalanceState energybalancestate)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
				//Code written below will not be overwritten by a future code generation
                energybalancestate.minCanopyTemperature = CanopyTemp(energybalancestate.minTair, energybalancestate.cropHeatFlux, energybalancestate.conductance);
                energybalancestate.maxCanopyTemperature = CanopyTemp(energybalancestate.maxTair, energybalancestate.cropHeatFlux, energybalancestate.conductance);
				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation
                public double CanopyTemp(double temperature, double cropHeatFlux, double conductance)
                {
                    return temperature + cropHeatFlux / ((rhoDensityAir * specificHeatCapacityAir * conductance / lambda) * 1000); // 1000 converts kg in g
            
                }
				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
