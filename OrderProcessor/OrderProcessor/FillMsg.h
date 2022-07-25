#pragma once
class FillMsg
{
public:
	FillMsg(long orderID, long lastShares, double lastPrice)
		: OrderID(orderID), LastShares(lastShares), LastPrice (lastPrice)
	{}

	long OrderID;
	long LastShares;
	double LastPrice;

};

