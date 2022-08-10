using System;
using System.IO;
using System.Linq;
using GigaSpaces.Core;
using GigaSpaces.Examples.StockSba.Commons.Entities;
using GigaSpaces.XAP.ProcessingUnit.Containers;

namespace GigaSpaces.Examples.StockSba.PUDebugExecuter
{
	/// <summary>
	/// Run ProcessingUnitContainers to execute full PU lifecycle locally, for debug purposes.
	/// </summary>

	internal class Program
    {
		private static Random random = new Random();
		private static void Main(string[] args)
        {
            int noOfLoops = 1;
            for (int i = 0; i < noOfLoops; ++i)
            {
             //   readOrWriteData();
				readOrWriteOrderData();
                readOrWriteFillsData();
            }
        }
		static void readOrWriteFillsData()
		{
			ISpaceProxy spaceProxy = new SpaceProxyFactory("stock").Create();

			Console.WriteLine("Connected to space");
			SqlQuery<Fills> template = new SqlQuery<Fills>("FillID>=0");

			int startSize = spaceProxy.Count(template);
			int batchSize = 200;
			Fills[] orderAry = new Fills[batchSize];
			Console.WriteLine("startSize=" + startSize);
			Console.WriteLine("initial Fills data in grid count : " + spaceProxy.Count(template));


			for (int i = startSize; i < startSize + batchSize; i++)
			{
				Fills p = new Fills();
				p.FillID = (long)i;
				p.OrderID = (long)i;
				p.LastShares = (long)i;
				p.LastPrice = random.Next(10, 20 + i) % 10000 / 32;
				p.FldInt_1 = i;
				p.FldInt_2 = i;
				p.FldInt_3 = i;
				p.FldInt_4 = i;
				p.FldInt_5 = i;
				p.FldInt_6 = i;
				p.FldInt_7 = i;
				p.FldInt_8 = i;
				p.FldInt_9 = i;
				p.FldInt_10 = i;
				p.FldInt_11 = i;
				p.FldTime_1 = DateTime.Now;
				p.FldTime_2 = DateTime.Now;
				p.FldTime_3 = DateTime.Now;
				p.FldTime_4 = DateTime.Now;
				p.FldDbl_1 = random.Next(10, 20 + i) % 10000 / 32;
				p.FldDbl_2 = random.Next(10, 20 + i) % 10000 / 32;
				p.FldDbl_3 = random.Next(10, 20 + i) % 10000 / 32;
				p.FldStr_1 = getRandomString(random.Next(10, 20));
				p.FldStr_2 = getRandomString(random.Next(10, 20));
				p.FldStr_3 = getRandomString(random.Next(10, 20));
				p.FldStr_4 = getRandomString(random.Next(10, 20));
				p.FldStr_5 = getRandomString(random.Next(10, 20));
				p.FldStr_6 = getRandomString(random.Next(10, 20));
				p.FldStr_7 = getRandomString(random.Next(10, 20));
				p.FldStr_8 = getRandomString(random.Next(10, 20));
				p.FldStr_9 = getRandomString(random.Next(10, 20));
				p.FldStr_10 = getRandomString(random.Next(10, 20));
				p.FldStr_11 = getRandomString(random.Next(10, 20));
				p.FldStr_12 = getRandomString(random.Next(10, 20));
				p.FldStr_13 = getRandomString(random.Next(10, 20));
				p.FldStr_14 = getRandomString(random.Next(10, 20));
				p.FldStr_15 = getRandomString(random.Next(10, 20));
				p.FldStr_16 = getRandomString(random.Next(10, 20));
				p.FldStr_17 = getRandomString(random.Next(10, 20));
				p.FldStr_18 = getRandomString(random.Next(10, 20));
				p.FldStr_19 = getRandomString(random.Next(10, 20));
				p.FldStr_20 = getRandomString(random.Next(10, 20));
				p.FldStr_21 = getRandomString(random.Next(10, 20));
				p.FldStr_22 = getRandomString(random.Next(10, 20));
				p.FldStr_23 = getRandomString(random.Next(10, 20));
				p.FldStr_24 = getRandomString(random.Next(10, 20));
				p.FldStr_25 = getRandomString(random.Next(10, 20));
				p.FldStr_26 = getRandomString(random.Next(10, 20));
				p.FldStr_27 = getRandomString(random.Next(10, 20));
				p.FldStr_28 = getRandomString(random.Next(10, 20));
				p.FldStr_29 = getRandomString(random.Next(10, 20));
				p.FldStr_30 = getRandomString(random.Next(10, 20));
				p.FldStr_31 = getRandomString(random.Next(10, 20));
				p.FldStr_32 = getRandomString(random.Next(10, 20));
				p.FldStr_33 = getRandomString(random.Next(10, 20));
				p.FldStr_34 = getRandomString(random.Next(10, 20));
				p.FldStr_35 = getRandomString(random.Next(10, 20));
				p.FldStr_36 = getRandomString(random.Next(10, 20));
				p.FldStr_37 = getRandomString(random.Next(10, 20));
				p.FldStr_38 = getRandomString(random.Next(10, 20));
				p.FldStr_39 = getRandomString(random.Next(10, 20));
				p.FldStr_40 = getRandomString(random.Next(10, 20));
				p.FldStr_41 = getRandomString(random.Next(10, 20));
				p.FldStr_42 = getRandomString(random.Next(10, 20));
				p.FldStr_43 = getRandomString(random.Next(10, 20));
				p.FldStr_44 = getRandomString(random.Next(10, 20));
				p.FldStr_45 = getRandomString(random.Next(10, 20));
				p.FldStr_46 = getRandomString(random.Next(10, 20));
				p.FldStr_47 = getRandomString(random.Next(10, 20));
				p.FldStr_48 = getRandomString(random.Next(10, 20));
				p.FldStr_49 = getRandomString(random.Next(10, 20));
				p.FldStr_50 = getRandomString(random.Next(10, 20));

				orderAry[i - startSize] = p;

			}
			long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Fills objects started at " + start);

			spaceProxy.WriteMultiple(orderAry);
			long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Fills objects ended at " + end);

			long diff = end - start;
			Console.WriteLine("Time taken in milliseconds to insert " + batchSize + " objects in the space is " + diff + " milliseconds");

			Console.WriteLine("after running feeder, data in grid count : " + spaceProxy.Count(template));
		}

		static void readOrWriteOrderData()
		{
			ISpaceProxy spaceProxy = new SpaceProxyFactory("stock").Create();

			Console.WriteLine("Connected to space");
			SqlQuery<Order> template = new SqlQuery<Order>("OrderID>=0");

			int startSize = spaceProxy.Count(template);
			int batchSize = 200;
			Order[] orderAry = new Order[batchSize];
			Console.WriteLine("startSize=" + startSize);
			Console.WriteLine("initial Order data in grid count : " + spaceProxy.Count(template));


			for (int i = startSize; i < startSize + batchSize; i++)
			{
				Order p = new Order();
				p.OrderID = (long)i;
				p.TraderID = (long)i;
				p.Symbol = getRandomString(random.Next(10, 20));
				p.Quanity = random.Next(10, 20 + i);
				p.CalCumQty = random.Next(10, 20 + i);
				p.Price = random.Next(10, 20 + i) * 10000 / 32;
				p.CalCumQty = (long)i;
				p.CalExecValue = random.Next(10, 20 + i) * 10000 / 32;
				p.FldInt_1 = random.Next(10, 20 + i);
				p.FldInt_2 = random.Next(10, 20 + i);
				p.FldInt_3 = random.Next(10, 20 + i);
				p.FldInt_4 = random.Next(10, 20 + i);
				p.FldInt_5 = random.Next(10, 20 + i);
				p.FldInt_6 = random.Next(10, 20 + i);
				p.FldInt_7 = random.Next(10, 20 + i);
				p.FldInt_8 = random.Next(10, 20 + i);
				p.FldInt_9 = random.Next(10, 20 + i);
				p.FldInt_10 = random.Next(10, 20 + i);
				p.FldInt_11 = random.Next(10, 20 + i);
				p.FldInt_12 = random.Next(10, 20 + i);
				p.FldInt_13 = random.Next(10, 20 + i);
				p.FldInt_14 = random.Next(10, 20 + i);
				p.FldInt_15 = random.Next(10, 20 + i);
				p.FldInt_16 = random.Next(10, 20 + i);
				p.FldInt_17 = random.Next(10, 20 + i);
				p.FldInt_18 = random.Next(10, 20 + i);
				p.FldInt_19 = random.Next(10, 20 + i);
				p.FldInt_20 = random.Next(10, 20 + i);
				p.FldInt_21 = random.Next(10, 20 + i);
				p.FldInt_22 = random.Next(10, 20 + i);
				p.FldInt_23 = random.Next(10, 20 + i);
				p.FldInt_24 = random.Next(10, 20 + i);
				p.FldInt_25 = random.Next(10, 20 + i);
				p.FldInt_26 = random.Next(10, 20 + i);
				p.FldInt_27 = random.Next(10, 20 + i);
				p.FldInt_28 = random.Next(10, 20 + i);
				p.FldInt_29 = random.Next(10, 20 + i);
				p.FldInt_30 = random.Next(10, 20 + i);
				p.FldInt_31 = random.Next(10, 20 + i);
				p.FldInt_32 = random.Next(10, 20 + i);
				p.FldInt_33 = random.Next(10, 20 + i);
				p.FldInt_34 = random.Next(10, 20 + i);
				p.FldInt_35 = random.Next(10, 20 + i);
				p.FldInt_36 = random.Next(10, 20 + i);
				p.FldInt_37 = random.Next(10, 20 + i);
				p.FldInt_38 = random.Next(10, 20 + i);
				p.FldInt_39 = random.Next(10, 20 + i);
				p.FldInt_40 = random.Next(10, 20 + i);
				p.FldTime_1 = DateTime.Now;
				p.FldTime_2 = DateTime.Now;
				p.FldTime_3 = DateTime.Now;
				p.FldTime_4 = DateTime.Now;
				p.FldTime_5 = DateTime.Now;
				p.FldTime_6 = DateTime.Now;
				p.FldTime_7 = DateTime.Now;
				p.FldTime_8 = DateTime.Now;
				p.FldStr_1 = getRandomString(random.Next(10, 20));
				p.FldStr_2 = getRandomString(random.Next(10, 20));
				p.FldStr_3 = getRandomString(random.Next(10, 20));
				p.FldStr_4 = getRandomString(random.Next(10, 20));
				p.FldStr_5 = getRandomString(random.Next(10, 20));
				p.FldStr_6 = getRandomString(random.Next(10, 20));
				p.FldStr_7 = getRandomString(random.Next(10, 20));
				p.FldStr_8 = getRandomString(random.Next(10, 20));
				p.FldStr_9 = getRandomString(random.Next(10, 20));
				p.FldStr_10 = getRandomString(random.Next(10, 20));
				p.FldStr_11 = getRandomString(random.Next(10, 20));
				p.FldStr_12 = getRandomString(random.Next(10, 20));
				p.FldStr_13 = getRandomString(random.Next(10, 20));
				p.FldStr_14 = getRandomString(random.Next(10, 20));
				p.FldStr_15 = getRandomString(random.Next(10, 20));
				p.FldStr_16 = getRandomString(random.Next(10, 20));
				p.FldStr_17 = getRandomString(random.Next(10, 20));
				p.FldStr_18 = getRandomString(random.Next(10, 20));
				p.FldStr_19 = getRandomString(random.Next(10, 20));
				p.FldStr_20 = getRandomString(random.Next(10, 20));
				p.FldStr_21 = getRandomString(random.Next(10, 20));
				p.FldStr_22 = getRandomString(random.Next(10, 20));
				p.FldStr_23 = getRandomString(random.Next(10, 20));
				p.FldStr_24 = getRandomString(random.Next(10, 20));
				p.FldStr_25 = getRandomString(random.Next(10, 20));
				p.FldStr_26 = getRandomString(random.Next(10, 20));
				p.FldStr_27 = getRandomString(random.Next(10, 20));
				p.FldStr_28 = getRandomString(random.Next(10, 20));
				p.FldStr_29 = getRandomString(random.Next(10, 20));
				p.FldStr_30 = getRandomString(random.Next(10, 20));
				p.FldStr_31 = getRandomString(random.Next(10, 20));
				p.FldStr_32 = getRandomString(random.Next(10, 20));
				p.FldStr_33 = getRandomString(random.Next(10, 20));
				p.FldStr_34 = getRandomString(random.Next(10, 20));
				p.FldStr_35 = getRandomString(random.Next(10, 20));
				p.FldStr_36 = getRandomString(random.Next(10, 20));
				p.FldStr_37 = getRandomString(random.Next(10, 20));
				p.FldStr_38 = getRandomString(random.Next(10, 20));
				p.FldStr_39 = getRandomString(random.Next(10, 20));
				p.FldStr_40 = getRandomString(random.Next(10, 20));
				p.FldDbl_1 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_2 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_3 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_4 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_5 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_6 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_7 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_8 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_9 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_10 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_11 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_12 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_13 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_14 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_15 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_16 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_17 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_18 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_19 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_20 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_21 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_22 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_23 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_24 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_25 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_26 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_27 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_28 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_29 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_30 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_31 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_32 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_33 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_34 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_35 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_36 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_37 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_38 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_39 = random.Next(10, 20 + i) * 100 / 32;
				p.FldDbl_40 = random.Next(10, 20 + i) * 100 / 32;


				//p.Id = (long)i;
				//	p.Name = "from .net";
				//	p.DotnetEventContainer = "";
				//	p.Timestamp = DateTime.Now.Ticks;
				orderAry[i - startSize] = p;
				//	spaceProxy.Write(p);
			}
			long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Order objects started at " + start);

			spaceProxy.WriteMultiple(orderAry);
			long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Order objects ended at " + end);

			long diff = end - start;
			Console.WriteLine("Time taken in milliseconds to insert " + batchSize + " objects in the space is " + diff + " milliseconds");

			Console.WriteLine("after running feeder, data in grid count : " + spaceProxy.Count(template));
		}


		public static string getRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		static void readOrWriteData()
		{
			ISpaceProxy spaceProxy = new SpaceProxyFactory("stock").Create();

			Console.WriteLine("Connected to space");
			SqlQuery<Person> template = new SqlQuery<Person>("id>=0");

			int startSize = spaceProxy.Count(template);
			int batchSize = 200000;
			Person[] personAry = new Person[batchSize];
			Console.WriteLine("startSize=" + startSize);
			Console.WriteLine("initial data in grid count : " + spaceProxy.Count(template));

			DateTime dateTimeObj = new DateTime();

			for (int i = startSize; i < startSize + batchSize; i++)
			{
				Person p = new Person();
				p.Id = (long)i;
				p.Name = "from .net";
				p.DotnetEventContainer = "";
				p.Timestamp = DateTime.Now.Ticks;
				personAry[i - startSize] = p;
			}
			long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Person objects started at " + start);

			spaceProxy.WriteMultiple(personAry);
			long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

			Console.WriteLine("Insert of Person objects ended at " + end);

			long diff = end - start;
			Console.WriteLine("Time taken in milliseconds to insert " + batchSize + " objects in the space is " + diff + " milliseconds");

			Console.WriteLine("after running feeder, data in grid count : " + spaceProxy.Count(template));
		}
	}
}