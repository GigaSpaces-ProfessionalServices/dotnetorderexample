#pragma once
using namespace System;
using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Metadata;

[SpaceClass(Persist = true)]
ref class GS_Fill
{
public:
	GS_Fill();
	
	// Partion ID
	[SpaceRouting]
	Nullable<long>  OPID;

	[SpaceID]
	//[SpaceIndex(Type=SpaceIndexType::Equal, Unique = true)]
	Nullable<long> FillID;
	Nullable<long> OrderID;

	Nullable<long> LastShares;
	Nullable<double> LastPrice;


};

