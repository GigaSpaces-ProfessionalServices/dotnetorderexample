#pragma once
using namespace System;
using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Metadata;

[Serializable]
[SpaceClass(Persist = true)]
ref class GS_Order
{

public:
	GS_Order();

	// Partion ID
	[SpaceRouting]
	Nullable<long> OPID;

	[SpaceID]
	//[SpaceIndex(Type=SpaceIndexType::Equal, Unique = true)]
	Nullable<long> OrderID;

	String^ Symbol;
	Nullable<long> Quantity;
	Nullable<double> Price;
	Nullable<long> CalCumQty;
	Nullable<double> CalExecValue;
};

