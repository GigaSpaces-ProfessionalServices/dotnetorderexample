using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.OrderProcessorWithCSharp.Common
{
	/// <summary>
	/// Represnts a Fill object
	/// </summary>	
	public class GS_Fill
	{

		private Nullable<long> _OPID;
		private Nullable<long> _FillID;
		private Nullable<long> _OrderID;
		private Nullable<long> _LastShares;
		private double _LastPrice;

		[SpaceRouting]
		public Nullable<long> OPID
		{
			get { return _OPID; }
			set { _OPID = value; }
		}

		[SpaceID]
		public Nullable<long> FillID
		{
			get { return _FillID; }
			set { _FillID = value; }
		}
		public Nullable<long> OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}
		public Nullable<long> LastShares
		{
			get { return _LastShares; }
			set { _LastShares = value; }
		}
		public double LastPrice
		{
			get { return _LastPrice; }
			set { _LastPrice = value; }
		}

	}
}