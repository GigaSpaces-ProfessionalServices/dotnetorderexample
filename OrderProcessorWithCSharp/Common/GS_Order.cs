using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.OrderProcessorWithCSharp.Common
{
	/// <summary>
	/// Represnts a Order object
	/// </summary>	
	public class GS_Order
	{
		private Nullable<long> _OPID;
		private Nullable<long> _OrderID;
		private String _Symbol;
		private Nullable<long> _Quantity;
		private Nullable<Double> _Price;
		private Nullable<long> _CalCumQty;
		private Nullable<Double> _CalExecValue;

		// Partion ID
		[SpaceRouting]
		public Nullable<long> OPID
		{
			get { return _OPID; }
			set { _OPID = value; }
		}

		[SpaceID]
		public Nullable<long> OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}

		public String Symbol
		{
			get { return _Symbol; }
			set { _Symbol = value; }
		}

		public Nullable<long> Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}
		public Nullable<Double> Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		public Nullable<long> CalCumQty
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