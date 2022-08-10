using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    [SpaceClass(Persist = true)]
    public class Order
    {
        private long _OrderID;
        [SpaceProperty(AliasName = "OrderID")]
        [SpaceID]
        public long OrderID
        {
            get { return this._OrderID; }
            set { this._OrderID = value; }
        }
        
        private long _TraderID;
        [SpaceIndex(Type = SpaceIndexType.Equal, Unique = true)]
        [SpaceProperty(AliasName = "TraderID")]
        public long TraderID
        {
            get { return this._TraderID; }
            set { this._TraderID = value; }
        }

        private string _Symbol;
        [SpaceProperty(AliasName = "Symbol")]
        public string Symbol
        {
            get { return this._Symbol; }
            set { this._Symbol = value; }
        }

        private long _Quanity;
        [SpaceProperty(AliasName = "Quanity")]
        public long Quanity
        {
            get { return this._Quanity; }
            set { this._Quanity = value; }

        }
        
        private long _CumQty;
        [SpaceProperty(AliasName = "CumQty")]
        public long CumQty
        {
            get { return this._CumQty; }
            set { this._CumQty = value; }
        }
        
        private double _Price;
        [SpaceProperty(AliasName = "Price")]
        public double Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }
        
        private long _CalCumQty;
        [SpaceProperty(AliasName = "CalCumQty")]
        public long CalCumQty
        {
            get { return this._CalCumQty; }
            set { this._CalCumQty = value; }
        }
        
        private long _CalExecValue;
        [SpaceProperty(AliasName = "CalExecValue")]
        public long CalExecValue
        {
            get { return this._CalExecValue; }
            set { this._CalExecValue = value; }
        }        
        
        private long _FldInt_1;
        [SpaceProperty(AliasName = "FldInt_1")]
        public long FldInt_1
        {
            get { return this._FldInt_1; }
            set { this._FldInt_1 = value; }
        }

        private long _FldInt_2;
        [SpaceProperty(AliasName = "FldInt_2")]
        public long FldInt_2
        {
            get { return this._FldInt_2; }
            set { this._FldInt_2 = value; }
        }

        private long _FldInt_3;
        [SpaceProperty(AliasName = "FldInt_3")]
        public long FldInt_3
        {
            get { return this._FldInt_3; }
            set { this._FldInt_3 = value; }
        }

        private long _FldInt_4;
        [SpaceProperty(AliasName = "FldInt_4")]
        public long FldInt_4
        {
            get { return this._FldInt_4; }
            set { this._FldInt_4 = value; }
        }

        private long _FldInt_5;
        [SpaceProperty(AliasName = "FldInt_5")]
        public long FldInt_5
        {
            get { return this._FldInt_5; }
            set { this._FldInt_5 = value; }
        }

        private long _FldInt_6;
        [SpaceProperty(AliasName = "FldInt_6")]
        public long FldInt_6
        {
            get { return this._FldInt_6; }
            set { this._FldInt_6 = value; }
        }

        private long _FldInt_7;
        [SpaceProperty(AliasName = "FldInt_7")]
        public long FldInt_7
        {
            get { return this._FldInt_7; }
            set { this._FldInt_7 = value; }
        }

        private long _FldInt_8;
        [SpaceProperty(AliasName = "FldInt_8")]
        public long FldInt_8
        {
            get { return this._FldInt_8; }
            set { this._FldInt_8 = value; }
        }

        private long _FldInt_9;
        [SpaceProperty(AliasName = "FldInt_9")]
        public long FldInt_9
        {
            get { return this._FldInt_9; }
            set { this._FldInt_9 = value; }
        }

        private long _FldInt_10;
        [SpaceProperty(AliasName = "FldInt_10")]
        public long FldInt_10
        {
            get { return this._FldInt_10; }
            set { this._FldInt_10 = value; }
        }

        private long _FldInt_11;
        [SpaceProperty(AliasName = "FldInt_11")]
        public long FldInt_11
        {
            get { return this._FldInt_11; }
            set { this._FldInt_11 = value; }
        }

        private long _FldInt_12;
        [SpaceProperty(AliasName = "FldInt_12")]
        public long FldInt_12
        {
            get { return this._FldInt_12; }
            set { this._FldInt_12 = value; }
        }

        private long _FldInt_13;
        [SpaceProperty(AliasName = "FldInt_13")]
        public long FldInt_13
        {
            get { return this._FldInt_13; }
            set { this._FldInt_13 = value; }
        }

        private long _FldInt_14;
        [SpaceProperty(AliasName = "FldInt_14")]
        public long FldInt_14
        {
            get { return this._FldInt_14; }
            set { this._FldInt_14 = value; }
        }

        private long _FldInt_15;
        [SpaceProperty(AliasName = "FldInt_15")]
        public long FldInt_15
        {
            get { return this._FldInt_15; }
            set { this._FldInt_15 = value; }
        }

        private long _FldInt_16;
        [SpaceProperty(AliasName = "FldInt_16")]
        public long FldInt_16
        {
            get { return this._FldInt_16; }
            set { this._FldInt_16 = value; }
        }

        private long _FldInt_17;
        [SpaceProperty(AliasName = "FldInt_17")]
        public long FldInt_17
        {
            get { return this._FldInt_17; }
            set { this._FldInt_17 = value; }
        }

        private long _FldInt_18;
        [SpaceProperty(AliasName = "FldInt_18")]
        public long FldInt_18
        {
            get { return this._FldInt_18; }
            set { this._FldInt_18 = value; }
        }

        private long _FldInt_19;
        [SpaceProperty(AliasName = "FldInt_19")]
        public long FldInt_19
        {
            get { return this._FldInt_19; }
            set { this._FldInt_19 = value; }
        }

        private long _FldInt_20;
        [SpaceProperty(AliasName = "FldInt_20")]
        public long FldInt_20
        {
            get { return this._FldInt_20; }
            set { this._FldInt_20 = value; }
        }

        private long _FldInt_21;
        [SpaceProperty(AliasName = "FldInt_21")]
        public long FldInt_21
        {
            get { return this._FldInt_21; }
            set { this._FldInt_21 = value; }
        }

        private long _FldInt_22;
        [SpaceProperty(AliasName = "FldInt_22")]
        public long FldInt_22
        {
            get { return this._FldInt_22; }
            set { this._FldInt_22 = value; }
        }

        private long _FldInt_23;
        [SpaceProperty(AliasName = "FldInt_23")]
        public long FldInt_23
        {
            get { return this._FldInt_23; }
            set { this._FldInt_23 = value; }
        }

        private long _FldInt_24;
        [SpaceProperty(AliasName = "FldInt_24")]
        public long FldInt_24
        {
            get { return this._FldInt_24; }
            set { this._FldInt_24 = value; }
        }

        private long _FldInt_25;
        [SpaceProperty(AliasName = "FldInt_25")]
        public long FldInt_25
        {
            get { return this._FldInt_25; }
            set { this._FldInt_25 = value; }
        }

        private long _FldInt_26;
        [SpaceProperty(AliasName = "FldInt_26")]
        public long FldInt_26
        {
            get { return this._FldInt_26; }
            set { this._FldInt_26 = value; }
        }

        private long _FldInt_27;
        [SpaceProperty(AliasName = "FldInt_27")]
        public long FldInt_27
        {
            get { return this._FldInt_27; }
            set { this._FldInt_27 = value; }
        }

        private long _FldInt_28;
        [SpaceProperty(AliasName = "FldInt_28")]
        public long FldInt_28
        {
            get { return this._FldInt_28; }
            set { this._FldInt_28 = value; }
        }

        private long _FldInt_29;
        [SpaceProperty(AliasName = "FldInt_29")]
        public long FldInt_29
        {
            get { return this._FldInt_29; }
            set { this._FldInt_29 = value; }
        }

        private long _FldInt_30;
        [SpaceProperty(AliasName = "FldInt_30")]
        public long FldInt_30
        {
            get { return this._FldInt_30; }
            set { this._FldInt_30 = value; }
        }

        private long _FldInt_31;
        [SpaceProperty(AliasName = "FldInt_31")]
        public long FldInt_31
        {
            get { return this._FldInt_31; }
            set { this._FldInt_31 = value; }
        }

        private long _FldInt_32;
        [SpaceProperty(AliasName = "FldInt_32")]
        public long FldInt_32
        {
            get { return this._FldInt_32; }
            set { this._FldInt_32 = value; }
        }

        private long _FldInt_33;
        [SpaceProperty(AliasName = "FldInt_33")]
        public long FldInt_33
        {
            get { return this._FldInt_33; }
            set { this._FldInt_33 = value; }
        }

        private long _FldInt_34;
        [SpaceProperty(AliasName = "FldInt_34")]
        public long FldInt_34
        {
            get { return this._FldInt_34; }
            set { this._FldInt_34 = value; }
        }

        private long _FldInt_35;
        [SpaceProperty(AliasName = "FldInt_35")]
        public long FldInt_35
        {
            get { return this._FldInt_35; }
            set { this._FldInt_35 = value; }
        }

        private long _FldInt_36;
        [SpaceProperty(AliasName = "FldInt_36")]
        public long FldInt_36
        {
            get { return this._FldInt_36; }
            set { this._FldInt_36 = value; }
        }

        private long _FldInt_37;
        [SpaceProperty(AliasName = "FldInt_37")]
        public long FldInt_37
        {
            get { return this._FldInt_37; }
            set { this._FldInt_37 = value; }
        }

        private long _FldInt_38;
        [SpaceProperty(AliasName = "FldInt_38")]
        public long FldInt_38
        {
            get { return this._FldInt_38; }
            set { this._FldInt_38 = value; }
        }

        private long _FldInt_39;
        [SpaceProperty(AliasName = "FldInt_39")]
        public long FldInt_39
        {
            get { return this._FldInt_39; }
            set { this._FldInt_39 = value; }
        }

        private long _FldInt_40;
        [SpaceProperty(AliasName = "FldInt_40")]
        public long FldInt_40
        {
            get { return this._FldInt_40; }
            set { this._FldInt_40 = value; }
        }

        private DateTime _FldTime_1;
        [SpaceProperty(AliasName = "FldTime_1")]
        public DateTime FldTime_1
        {
            get { return this._FldTime_1; }
            set { this._FldTime_1 = value; }
        }

        private DateTime _FldTime_2;
        [SpaceProperty(AliasName = "FldTime_2")]
        public DateTime FldTime_2
        {
            get { return this._FldTime_2; }
            set { this._FldTime_2 = value; }
        }

        private DateTime _FldTime_3;
        [SpaceProperty(AliasName = "FldTime_3")]
        public DateTime FldTime_3
        {
            get { return this._FldTime_3; }
            set { this._FldTime_3 = value; }
        }

        private DateTime _FldTime_4;
        [SpaceProperty(AliasName = "FldTime_4")]
        public DateTime FldTime_4
        {
            get { return this._FldTime_4; }
            set { this._FldTime_4 = value; }
        }

        private DateTime _FldTime_5;
        [SpaceProperty(AliasName = "FldTime_5")]
        public DateTime FldTime_5
        {
            get { return this._FldTime_5; }
            set { this._FldTime_5 = value; }
        }

        private DateTime _FldTime_6;
        [SpaceProperty(AliasName = "FldTime_6")]
        public DateTime FldTime_6
        {
            get { return this._FldTime_6; }
            set { this._FldTime_6 = value; }
        }

        private DateTime _FldTime_7;
        [SpaceProperty(AliasName = "FldTime_7")]
        public DateTime FldTime_7
        {
            get { return this._FldTime_7; }
            set { this._FldTime_7 = value; }
        }

        private DateTime _FldTime_8;
        [SpaceProperty(AliasName = "FldTime_8")]
        public DateTime FldTime_8
        {
            get { return this._FldTime_8; }
            set { this._FldTime_8 = value; }
        }

        private string _FldStr_1;
        [SpaceProperty(AliasName = "FldStr_1")]
        public String FldStr_1
        {
            get { return this._FldStr_1; }
            set { this._FldStr_1 = value; }
        }

        private string _FldStr_2;
        [SpaceProperty(AliasName = "FldStr_2")]
        public String FldStr_2
        {
            get { return this._FldStr_2; }
            set { this._FldStr_2 = value; }
        }

        private string _FldStr_3;
        [SpaceProperty(AliasName = "FldStr_3")]
        public String FldStr_3
        {
            get { return this._FldStr_3; }
            set { this._FldStr_3 = value; }
        }

        private string _FldStr_4;
        [SpaceProperty(AliasName = "FldStr_4")]
        public String FldStr_4
        {
            get { return this._FldStr_4; }
            set { this._FldStr_4 = value; }
        }

        private string _FldStr_5;
        [SpaceProperty(AliasName = "FldStr_5")]
        public String FldStr_5
        {
            get { return this._FldStr_5; }
            set { this._FldStr_5 = value; }
        }

        private string _FldStr_6;
        [SpaceProperty(AliasName = "FldStr_6")]
        public String FldStr_6
        {
            get { return this._FldStr_6; }
            set { this._FldStr_6 = value; }
        }

        private string _FldStr_7;
        [SpaceProperty(AliasName = "FldStr_7")]
        public String FldStr_7
        {
            get { return this._FldStr_7; }
            set { this._FldStr_7 = value; }
        }

        private string _FldStr_8;
        [SpaceProperty(AliasName = "FldStr_8")]
        public String FldStr_8
        {
            get { return this._FldStr_8; }
            set { this._FldStr_8 = value; }
        }

        private string _FldStr_9;
        [SpaceProperty(AliasName = "FldStr_9")]
        public String FldStr_9
        {
            get { return this._FldStr_9; }
            set { this._FldStr_9 = value; }
        }

        private string _FldStr_10;
        [SpaceProperty(AliasName = "FldStr_10")]
        public String FldStr_10
        {
            get { return this._FldStr_10; }
            set { this._FldStr_10 = value; }
        }

        private string _FldStr_11;
        [SpaceProperty(AliasName = "FldStr_11")]
        public String FldStr_11
        {
            get { return this._FldStr_11; }
            set { this._FldStr_11 = value; }
        }

        private string _FldStr_12;
        [SpaceProperty(AliasName = "FldStr_12")]
        public String FldStr_12
        {
            get { return this._FldStr_12; }
            set { this._FldStr_12 = value; }
        }

        private string _FldStr_13;
        [SpaceProperty(AliasName = "FldStr_13")]
        public String FldStr_13
        {
            get { return this._FldStr_13; }
            set { this._FldStr_13 = value; }
        }

        private string _FldStr_14;
        [SpaceProperty(AliasName = "FldStr_14")]
        public String FldStr_14
        {
            get { return this._FldStr_14; }
            set { this._FldStr_14 = value; }
        }

        private string _FldStr_15;
        [SpaceProperty(AliasName = "FldStr_15")]
        public String FldStr_15
        {
            get { return this._FldStr_15; }
            set { this._FldStr_15 = value; }
        }

        private string _FldStr_16;
        [SpaceProperty(AliasName = "FldStr_16")]
        public String FldStr_16
        {
            get { return this._FldStr_16; }
            set { this._FldStr_16 = value; }
        }

        private string _FldStr_17;
        [SpaceProperty(AliasName = "FldStr_17")]
        public String FldStr_17
        {
            get { return this._FldStr_17; }
            set { this._FldStr_17 = value; }
        }

        private string _FldStr_18;
        [SpaceProperty(AliasName = "FldStr_18")]
        public String FldStr_18
        {
            get { return this._FldStr_18; }
            set { this._FldStr_18 = value; }
        }

        private string _FldStr_19;
        [SpaceProperty(AliasName = "FldStr_19")]
        public String FldStr_19
        {
            get { return this._FldStr_19; }
            set { this._FldStr_19 = value; }
        }

        private string _FldStr_20;
        [SpaceProperty(AliasName = "FldStr_20")]
        public String FldStr_20
        {
            get { return this._FldStr_20; }
            set { this._FldStr_20 = value; }
        }

        private string _FldStr_21;
        [SpaceProperty(AliasName = "FldStr_21")]
        public String FldStr_21
        {
            get { return this._FldStr_21; }
            set { this._FldStr_21 = value; }
        }

        private string _FldStr_22;
        [SpaceProperty(AliasName = "FldStr_22")]
        public String FldStr_22
        {
            get { return this._FldStr_22; }
            set { this._FldStr_22 = value; }
        }

        private string _FldStr_23;
        [SpaceProperty(AliasName = "FldStr_23")]
        public String FldStr_23
        {
            get { return this._FldStr_23; }
            set { this._FldStr_23 = value; }
        }

        private string _FldStr_24;
        [SpaceProperty(AliasName = "FldStr_24")]
        public String FldStr_24
        {
            get { return this._FldStr_24; }
            set { this._FldStr_24 = value; }
        }

        private string _FldStr_25;
        [SpaceProperty(AliasName = "FldStr_25")]
        public String FldStr_25
        {
            get { return this._FldStr_25; }
            set { this._FldStr_25 = value; }
        }

        private string _FldStr_26;
        [SpaceProperty(AliasName = "FldStr_26")]
        public String FldStr_26
        {
            get { return this._FldStr_26; }
            set { this._FldStr_26 = value; }
        }

        private string _FldStr_27;
        [SpaceProperty(AliasName = "FldStr_27")]
        public String FldStr_27
        {
            get { return this._FldStr_27; }
            set { this._FldStr_27 = value; }
        }

        private string _FldStr_28;
        [SpaceProperty(AliasName = "FldStr_28")]
        public String FldStr_28
        {
            get { return this._FldStr_28; }
            set { this._FldStr_28 = value; }
        }

        private string _FldStr_29;
        [SpaceProperty(AliasName = "FldStr_29")]
        public String FldStr_29
        {
            get { return this._FldStr_29; }
            set { this._FldStr_29 = value; }
        }

        private string _FldStr_30;
        [SpaceProperty(AliasName = "FldStr_30")]
        public String FldStr_30
        {
            get { return this._FldStr_30; }
            set { this._FldStr_30 = value; }
        }

        private string _FldStr_31;
        [SpaceProperty(AliasName = "FldStr_31")]
        public String FldStr_31
        {
            get { return this._FldStr_31; }
            set { this._FldStr_31 = value; }
        }

        private string _FldStr_32;
        [SpaceProperty(AliasName = "FldStr_32")]
        public String FldStr_32
        {
            get { return this._FldStr_32; }
            set { this._FldStr_32 = value; }
        }

        private string _FldStr_33;
        [SpaceProperty(AliasName = "FldStr_33")]
        public String FldStr_33
        {
            get { return this._FldStr_33; }
            set { this._FldStr_33 = value; }
        }

        private string _FldStr_34;
        [SpaceProperty(AliasName = "FldStr_34")]
        public String FldStr_34
        {
            get { return this._FldStr_34; }
            set { this._FldStr_34 = value; }
        }

        private string _FldStr_35;
        [SpaceProperty(AliasName = "FldStr_35")]
        public String FldStr_35
        {
            get { return this._FldStr_35; }
            set { this._FldStr_35 = value; }
        }

        private string _FldStr_36;
        [SpaceProperty(AliasName = "FldStr_36")]
        public String FldStr_36
        {
            get { return this._FldStr_36; }
            set { this._FldStr_36 = value; }
        }

        private string _FldStr_37;
        [SpaceProperty(AliasName = "FldStr_37")]
        public String FldStr_37
        {
            get { return this._FldStr_37; }
            set { this._FldStr_37 = value; }
        }

        private string _FldStr_38;
        [SpaceProperty(AliasName = "FldStr_38")]
        public String FldStr_38
        {
            get { return this._FldStr_38; }
            set { this._FldStr_38 = value; }
        }

        private string _FldStr_39;
        [SpaceProperty(AliasName = "FldStr_39")]
        public String FldStr_39
        {
            get { return this._FldStr_39; }
            set { this._FldStr_39 = value; }
        }

        private string _FldStr_40;
        [SpaceProperty(AliasName = "FldStr_40")]
        public String FldStr_40
        {
            get { return this._FldStr_40; }
            set { this._FldStr_40 = value; }
        }
        
        private double _FldDbl_1;
        [SpaceProperty(AliasName = "FldDbl_1")]
        public Double FldDbl_1
        {
            get { return this._FldDbl_1; }
            set { this._FldDbl_1 = value; }
        }

        private double _FldDbl_2;
        [SpaceProperty(AliasName = "FldDbl_2")]
        public Double FldDbl_2
        {
            get { return this._FldDbl_2; }
            set { this._FldDbl_2 = value; }
        }

        private double _FldDbl_3;
        [SpaceProperty(AliasName = "FldDbl_3")]
        public Double FldDbl_3
        {
            get { return this._FldDbl_3; }
            set { this._FldDbl_3 = value; }
        }

        private double _FldDbl_4;
        [SpaceProperty(AliasName = "FldDbl_4")]
        public Double FldDbl_4
        {
            get { return this._FldDbl_4; }
            set { this._FldDbl_4 = value; }
        }

        private double _FldDbl_5;
        [SpaceProperty(AliasName = "FldDbl_5")]
        public Double FldDbl_5
        {
            get { return this._FldDbl_5; }
            set { this._FldDbl_5 = value; }
        }

        private double _FldDbl_6;
        [SpaceProperty(AliasName = "FldDbl_6")]
        public Double FldDbl_6
        {
            get { return this._FldDbl_6; }
            set { this._FldDbl_6 = value; }
        }

        private double _FldDbl_7;
        [SpaceProperty(AliasName = "FldDbl_7")]
        public Double FldDbl_7
        {
            get { return this._FldDbl_7; }
            set { this._FldDbl_7 = value; }
        }

        private double _FldDbl_8;
        [SpaceProperty(AliasName = "FldDbl_8")]
        public Double FldDbl_8
        {
            get { return this._FldDbl_8; }
            set { this._FldDbl_8 = value; }
        }

        private double _FldDbl_9;
        [SpaceProperty(AliasName = "FldDbl_9")]
        public Double FldDbl_9
        {
            get { return this._FldDbl_9; }
            set { this._FldDbl_9 = value; }
        }

        private double _FldDbl_10;
        [SpaceProperty(AliasName = "FldDbl_10")]
        public Double FldDbl_10
        {
            get { return this._FldDbl_10; }
            set { this._FldDbl_10 = value; }
        }

        private double _FldDbl_11;
        [SpaceProperty(AliasName = "FldDbl_11")]
        public Double FldDbl_11
        {
            get { return this._FldDbl_11; }
            set { this._FldDbl_11 = value; }
        }

        private double _FldDbl_12;
        [SpaceProperty(AliasName = "FldDbl_12")]
        public Double FldDbl_12
        {
            get { return this._FldDbl_12; }
            set { this._FldDbl_12 = value; }
        }

        private double _FldDbl_13;
        [SpaceProperty(AliasName = "FldDbl_13")]
        public Double FldDbl_13
        {
            get { return this._FldDbl_13; }
            set { this._FldDbl_13 = value; }
        }

        private double _FldDbl_14;
        [SpaceProperty(AliasName = "FldDbl_14")]
        public Double FldDbl_14
        {
            get { return this._FldDbl_14; }
            set { this._FldDbl_14 = value; }
        }

        private double _FldDbl_15;
        [SpaceProperty(AliasName = "FldDbl_15")]
        public Double FldDbl_15
        {
            get { return this._FldDbl_15; }
            set { this._FldDbl_15 = value; }
        }

        private double _FldDbl_16;
        [SpaceProperty(AliasName = "FldDbl_16")]
        public Double FldDbl_16
        {
            get { return this._FldDbl_16; }
            set { this._FldDbl_16 = value; }
        }

        private double _FldDbl_17;
        [SpaceProperty(AliasName = "FldDbl_17")]
        public Double FldDbl_17
        {
            get { return this._FldDbl_17; }
            set { this._FldDbl_17 = value; }
        }

        private double _FldDbl_18;
        [SpaceProperty(AliasName = "FldDbl_18")]
        public Double FldDbl_18
        {
            get { return this._FldDbl_18; }
            set { this._FldDbl_18 = value; }
        }

        private double _FldDbl_19;
        [SpaceProperty(AliasName = "FldDbl_19")]
        public Double FldDbl_19
        {
            get { return this._FldDbl_19; }
            set { this._FldDbl_19 = value; }
        }

        private double _FldDbl_20;
        [SpaceProperty(AliasName = "FldDbl_20")]
        public Double FldDbl_20
        {
            get { return this._FldDbl_20; }
            set { this._FldDbl_20 = value; }
        }

        private double _FldDbl_21;
        [SpaceProperty(AliasName = "FldDbl_21")]
        public Double FldDbl_21
        {
            get { return this._FldDbl_21; }
            set { this._FldDbl_21 = value; }
        }

        private double _FldDbl_22;
        [SpaceProperty(AliasName = "FldDbl_22")]
        public Double FldDbl_22
        {
            get { return this._FldDbl_22; }
            set { this._FldDbl_22 = value; }
        }

        private double _FldDbl_23;
        [SpaceProperty(AliasName = "FldDbl_23")]
        public Double FldDbl_23
        {
            get { return this._FldDbl_23; }
            set { this._FldDbl_23 = value; }
        }

        private double _FldDbl_24;
        [SpaceProperty(AliasName = "FldDbl_24")]
        public Double FldDbl_24
        {
            get { return this._FldDbl_24; }
            set { this._FldDbl_24 = value; }
        }

        private double _FldDbl_25;
        [SpaceProperty(AliasName = "FldDbl_25")]
        public Double FldDbl_25
        {
            get { return this._FldDbl_25; }
            set { this._FldDbl_25 = value; }
        }

        private double _FldDbl_26;
        [SpaceProperty(AliasName = "FldDbl_26")]
        public Double FldDbl_26
        {
            get { return this._FldDbl_26; }
            set { this._FldDbl_26 = value; }
        }

        private double _FldDbl_27;
        [SpaceProperty(AliasName = "FldDbl_27")]
        public Double FldDbl_27
        {
            get { return this._FldDbl_27; }
            set { this._FldDbl_27 = value; }
        }

        private double _FldDbl_28;
        [SpaceProperty(AliasName = "FldDbl_28")]
        public Double FldDbl_28
        {
            get { return this._FldDbl_28; }
            set { this._FldDbl_28 = value; }
        }

        private double _FldDbl_29;
        [SpaceProperty(AliasName = "FldDbl_29")]
        public Double FldDbl_29
        {
            get { return this._FldDbl_29; }
            set { this._FldDbl_29 = value; }
        }

        private double _FldDbl_30;
        [SpaceProperty(AliasName = "FldDbl_30")]
        public Double FldDbl_30
        {
            get { return this._FldDbl_30; }
            set { this._FldDbl_30 = value; }
        }

        private double _FldDbl_31;
        [SpaceProperty(AliasName = "FldDbl_31")]
        public Double FldDbl_31
        {
            get { return this._FldDbl_31; }
            set { this._FldDbl_31 = value; }
        }

        private double _FldDbl_32;
        [SpaceProperty(AliasName = "FldDbl_32")]
        public Double FldDbl_32
        {
            get { return this._FldDbl_32; }
            set { this._FldDbl_32 = value; }
        }

        private double _FldDbl_33;
        [SpaceProperty(AliasName = "FldDbl_33")]
        public Double FldDbl_33
        {
            get { return this._FldDbl_33; }
            set { this._FldDbl_33 = value; }
        }

        private double _FldDbl_34;
        [SpaceProperty(AliasName = "FldDbl_34")]
        public Double FldDbl_34
        {
            get { return this._FldDbl_34; }
            set { this._FldDbl_34 = value; }
        }

        private double _FldDbl_35;
        [SpaceProperty(AliasName = "FldDbl_35")]
        public Double FldDbl_35
        {
            get { return this._FldDbl_35; }
            set { this._FldDbl_35 = value; }
        }

        private double _FldDbl_36;
        [SpaceProperty(AliasName = "FldDbl_36")]
        public Double FldDbl_36
        {
            get { return this._FldDbl_36; }
            set { this._FldDbl_36 = value; }
        }

        private double _FldDbl_37;
        [SpaceProperty(AliasName = "FldDbl_37")]
        public Double FldDbl_37
        {
            get { return this._FldDbl_37; }
            set { this._FldDbl_37 = value; }
        }

        private double _FldDbl_38;
        [SpaceProperty(AliasName = "FldDbl_38")]
        public Double FldDbl_38
        {
            get { return this._FldDbl_38; }
            set { this._FldDbl_38 = value; }
        }

        private double _FldDbl_39;
        [SpaceProperty(AliasName = "FldDbl_39")]
        public Double FldDbl_39
        {
            get { return this._FldDbl_39; }
            set { this._FldDbl_39 = value; }
        }

        private double _FldDbl_40;
        [SpaceProperty(AliasName = "FldDbl_40")]
        public Double FldDbl_40
        {
            get { return this._FldDbl_40; }
            set { this._FldDbl_40 = value; }
        }	
        
        
    }
}
