using GigaSpaces.XAP.Remoting.Routing;

namespace GigaSpaces.Examples.ProcessingUnit.Common
{
	/// <summary>
	/// Provide statistics of a processor
	/// </summary>
	public interface IProcessorStatisticsProvider
	{
		/// <summary>
		/// Gets the number of processd objects of a specific type (Since the type is used as the routing
		/// field of the Data object, we will use it to route the invocation to the corresponding processor).
		/// </summary>
		/// <param name="type">Type to get the count of</param>
		/// <returns>The number of processd objects of a specific type.</returns>
		int GetProcessObjectCount([ServiceRouting]int type);
	}
}