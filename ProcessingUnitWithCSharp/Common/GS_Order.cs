using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.ProcessingUnit.Common
{
	/// <summary>
	/// Represnts a Order object
	/// </summary>	
	public class GS_Order
	{
//		private long _OPID;
		private long _OrderID;
		private String _Symbol;
		private long _Quantity;
		private Nullable<Double> _Price;
		private long _CalCumQty;
		private Nullable<Double> _CalExecValue;

		// Partion ID
	//	[SpaceRouting]
/*		public long OPID
		{
			get { return _OPID; }
			set { _OPID = value; }
		}*/

		[SpaceID]
		public long OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}

		public String Symbol
		{
			get { return _Symbol; }
			set { _Symbol = value; }
		}

		public long Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}
		public Nullable<Double> Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		public long CalCumQty
		{
			get { return _CalCumQty; }
			set { _CalCumQty = value; }
		}
		public Nullable<Double> CalExecValue
		{
			get { return _CalExecValue; }
			set { _CalExecValue = value; }
		}
	}
}