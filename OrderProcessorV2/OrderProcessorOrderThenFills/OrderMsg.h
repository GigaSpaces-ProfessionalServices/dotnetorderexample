#pragma once

class OrderMsg
{
public:

	OrderMsg(long orderID, long quanity, double price);

	long OrderID;
	long Quanity;
	double Price;
};

