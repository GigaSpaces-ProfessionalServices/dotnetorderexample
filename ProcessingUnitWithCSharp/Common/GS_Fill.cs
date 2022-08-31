using System;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.ProcessingUnit.Common
{
	/// <summary>
	/// Represnts a Fill object
	/// </summary>	
	public class GS_Fill
	{

//		private Nullable<long> _OPID;
		private long _FillID;
		private long _OrderID;
		private long _LastShares;
		private double _LastPrice;

	//	[SpaceRouting]
/*		public Nullable<long> OPID
		{
			get { return _OPID; }
			set { _OPID = value; }
		}*/

		[SpaceID]
		public long FillID
		{
			get { return _FillID; }
			set { _FillID = value; }
		}

        [SpaceRouting]
		public long OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}
		public long LastShares
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