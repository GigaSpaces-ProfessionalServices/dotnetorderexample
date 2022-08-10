using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    [SpaceClass(Persist = true)]
    public class Fills
    {
        private long _FillID;
        [SpaceProperty(AliasName = "FillID")]
        [SpaceID]
        public long FillID
        {
            get { return this._FillID; }
            set { this._FillID = value; }
        }
        
        private long _OrderID;
        [SpaceProperty(AliasName = "OrderID")]
        public long OrderID
        {
            get { return this._OrderID; }
            set { this._OrderID = value; }
        }
        
        private long _LastShares;
        [SpaceProperty(AliasName = "LastShares")]
        public long LastShares
        {
            get { return this._LastShares; }
            set { this._LastShares = value; }
        }
        
        private double _LastPrice;
        [SpaceProperty(AliasName = "LastPrice")]
        public double LastPrice
        {
            get { return this._LastPrice; }
            set { this._LastPrice = value; }
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
        
        	private String _FldStr_1;
        [SpaceProperty(AliasName = "FldStr_1")]
        public String FldStr_1
        {
            get { return this._FldStr_1; }
            set { this._FldStr_1 = value; }
        }

        private String _FldStr_2;
        [SpaceProperty(AliasName = "FldStr_2")]
        public String FldStr_2
        {
            get { return this._FldStr_2; }
            set { this._FldStr_2 = value; }
        }

        private String _FldStr_3;
        [SpaceProperty(AliasName = "FldStr_3")]
        public String FldStr_3
        {
            get { return this._FldStr_3; }
            set { this._FldStr_3 = value; }
        }

        private String _FldStr_4;
        [SpaceProperty(AliasName = "FldStr_4")]
        public String FldStr_4
        {
            get { return this._FldStr_4; }
            set { this._FldStr_4 = value; }
        }

        private String _FldStr_5;
        [SpaceProperty(AliasName = "FldStr_5")]
        public String FldStr_5
        {
            get { return this._FldStr_5; }
            set { this._FldStr_5 = value; }
        }

        private String _FldStr_6;
        [SpaceProperty(AliasName = "FldStr_6")]
        public String FldStr_6
        {
            get { return this._FldStr_6; }
            set { this._FldStr_6 = value; }
        }

        private String _FldStr_7;
        [SpaceProperty(AliasName = "FldStr_7")]
        public String FldStr_7
        {
            get { return this._FldStr_7; }
            set { this._FldStr_7 = value; }
        }

        private String _FldStr_8;
        [SpaceProperty(AliasName = "FldStr_8")]
        public String FldStr_8
        {
            get { return this._FldStr_8; }
            set { this._FldStr_8 = value; }
        }

        private String _FldStr_9;
        [SpaceProperty(AliasName = "FldStr_9")]
        public String FldStr_9
        {
            get { return this._FldStr_9; }
            set { this._FldStr_9 = value; }
        }

        private String _FldStr_10;
        [SpaceProperty(AliasName = "FldStr_10")]
        public String FldStr_10
        {
            get { return this._FldStr_10; }
            set { this._FldStr_10 = value; }
        }

        private String _FldStr_11;
        [SpaceProperty(AliasName = "FldStr_11")]
        public String FldStr_11
        {
            get { return this._FldStr_11; }
            set { this._FldStr_11 = value; }
        }

        private String _FldStr_12;
        [SpaceProperty(AliasName = "FldStr_12")]
        public String FldStr_12
        {
            get { return this._FldStr_12; }
            set { this._FldStr_12 = value; }
        }

        private String _FldStr_13;
        [SpaceProperty(AliasName = "FldStr_13")]
        public String FldStr_13
        {
            get { return this._FldStr_13; }
            set { this._FldStr_13 = value; }
        }

        private String _FldStr_14;
        [SpaceProperty(AliasName = "FldStr_14")]
        public String FldStr_14
        {
            get { return this._FldStr_14; }
            set { this._FldStr_14 = value; }
        }

        private String _FldStr_15;
        [SpaceProperty(AliasName = "FldStr_15")]
        public String FldStr_15
        {
            get { return this._FldStr_15; }
            set { this._FldStr_15 = value; }
        }

        private String _FldStr_16;
        [SpaceProperty(AliasName = "FldStr_16")]
        public String FldStr_16
        {
            get { return this._FldStr_16; }
            set { this._FldStr_16 = value; }
        }

        private String _FldStr_17;
        [SpaceProperty(AliasName = "FldStr_17")]
        public String FldStr_17
        {
            get { return this._FldStr_17; }
            set { this._FldStr_17 = value; }
        }

        private String _FldStr_18;
        [SpaceProperty(AliasName = "FldStr_18")]
        public String FldStr_18
        {
            get { return this._FldStr_18; }
            set { this._FldStr_18 = value; }
        }

        private String _FldStr_19;
        [SpaceProperty(AliasName = "FldStr_19")]
        public String FldStr_19
        {
            get { return this._FldStr_19; }
            set { this._FldStr_19 = value; }
        }

        private String _FldStr_20;
        [SpaceProperty(AliasName = "FldStr_20")]
        public String FldStr_20
        {
            get { return this._FldStr_20; }
            set { this._FldStr_20 = value; }
        }

        private String _FldStr_21;
        [SpaceProperty(AliasName = "FldStr_21")]
        public String FldStr_21
        {
            get { return this._FldStr_21; }
            set { this._FldStr_21 = value; }
        }

        private String _FldStr_22;
        [SpaceProperty(AliasName = "FldStr_22")]
        public String FldStr_22
        {
            get { return this._FldStr_22; }
            set { this._FldStr_22 = value; }
        }

        private String _FldStr_23;
        [SpaceProperty(AliasName = "FldStr_23")]
        public String FldStr_23
        {
            get { return this._FldStr_23; }
            set { this._FldStr_23 = value; }
        }

        private String _FldStr_24;
        [SpaceProperty(AliasName = "FldStr_24")]
        public String FldStr_24
        {
            get { return this._FldStr_24; }
            set { this._FldStr_24 = value; }
        }

        private String _FldStr_25;
        [SpaceProperty(AliasName = "FldStr_25")]
        public String FldStr_25
        {
            get { return this._FldStr_25; }
            set { this._FldStr_25 = value; }
        }

        private String _FldStr_26;
        [SpaceProperty(AliasName = "FldStr_26")]
        public String FldStr_26
        {
            get { return this._FldStr_26; }
            set { this._FldStr_26 = value; }
        }

        private String _FldStr_27;
        [SpaceProperty(AliasName = "FldStr_27")]
        public String FldStr_27
        {
            get { return this._FldStr_27; }
            set { this._FldStr_27 = value; }
        }

        private String _FldStr_28;
        [SpaceProperty(AliasName = "FldStr_28")]
        public String FldStr_28
        {
            get { return this._FldStr_28; }
            set { this._FldStr_28 = value; }
        }

        private String _FldStr_29;
        [SpaceProperty(AliasName = "FldStr_29")]
        public String FldStr_29
        {
            get { return this._FldStr_29; }
            set { this._FldStr_29 = value; }
        }

        private String _FldStr_30;
        [SpaceProperty(AliasName = "FldStr_30")]
        public String FldStr_30
        {
            get { return this._FldStr_30; }
            set { this._FldStr_30 = value; }
        }

        private String _FldStr_31;
        [SpaceProperty(AliasName = "FldStr_31")]
        public String FldStr_31
        {
            get { return this._FldStr_31; }
            set { this._FldStr_31 = value; }
        }

        private String _FldStr_32;
        [SpaceProperty(AliasName = "FldStr_32")]
        public String FldStr_32
        {
            get { return this._FldStr_32; }
            set { this._FldStr_32 = value; }
        }

        private String _FldStr_33;
        [SpaceProperty(AliasName = "FldStr_33")]
        public String FldStr_33
        {
            get { return this._FldStr_33; }
            set { this._FldStr_33 = value; }
        }

        private String _FldStr_34;
        [SpaceProperty(AliasName = "FldStr_34")]
        public String FldStr_34
        {
            get { return this._FldStr_34; }
            set { this._FldStr_34 = value; }
        }

        private String _FldStr_35;
        [SpaceProperty(AliasName = "FldStr_35")]
        public String FldStr_35
        {
            get { return this._FldStr_35; }
            set { this._FldStr_35 = value; }
        }

        private String _FldStr_36;
        [SpaceProperty(AliasName = "FldStr_36")]
        public String FldStr_36
        {
            get { return this._FldStr_36; }
            set { this._FldStr_36 = value; }
        }

        private String _FldStr_37;
        [SpaceProperty(AliasName = "FldStr_37")]
        public String FldStr_37
        {
            get { return this._FldStr_37; }
            set { this._FldStr_37 = value; }
        }

        private String _FldStr_38;
        [SpaceProperty(AliasName = "FldStr_38")]
        public String FldStr_38
        {
            get { return this._FldStr_38; }
            set { this._FldStr_38 = value; }
        }

        private String _FldStr_39;
        [SpaceProperty(AliasName = "FldStr_39")]
        public String FldStr_39
        {
            get { return this._FldStr_39; }
            set { this._FldStr_39 = value; }
        }

        private String _FldStr_40;
        [SpaceProperty(AliasName = "FldStr_40")]
        public String FldStr_40
        {
            get { return this._FldStr_40; }
            set { this._FldStr_40 = value; }
        }
        
        private String _FldStr_41;
        [SpaceProperty(AliasName = "FldStr_41")]
        public String FldStr_41
        {
            get { return this._FldStr_41; }
            set { this._FldStr_41 = value; }
        }

        private String _FldStr_42;
        [SpaceProperty(AliasName = "FldStr_42")]
        public String FldStr_42
        {
            get { return this._FldStr_42; }
            set { this._FldStr_42 = value; }
        }

        private String _FldStr_43;
        [SpaceProperty(AliasName = "FldStr_43")]
        public String FldStr_43
        {
            get { return this._FldStr_43; }
            set { this._FldStr_43 = value; }
        }

        private String _FldStr_44;
        [SpaceProperty(AliasName = "FldStr_44")]
        public String FldStr_44
        {
            get { return this._FldStr_44; }
            set { this._FldStr_44 = value; }
        }

        private String _FldStr_45;
        [SpaceProperty(AliasName = "FldStr_45")]
        public String FldStr_45
        {
            get { return this._FldStr_45; }
            set { this._FldStr_45 = value; }
        }

        private String _FldStr_46;
        [SpaceProperty(AliasName = "FldStr_46")]
        public String FldStr_46
        {
            get { return this._FldStr_46; }
            set { this._FldStr_46 = value; }
        }

        private String _FldStr_47;
        [SpaceProperty(AliasName = "FldStr_47")]
        public String FldStr_47
        {
            get { return this._FldStr_47; }
            set { this._FldStr_47 = value; }
        }

        private String _FldStr_48;
        [SpaceProperty(AliasName = "FldStr_48")]
        public String FldStr_48
        {
            get { return this._FldStr_48; }
            set { this._FldStr_48 = value; }
        }

        private String _FldStr_49;
        [SpaceProperty(AliasName = "FldStr_49")]
        public String FldStr_49
        {
            get { return this._FldStr_49; }
            set { this._FldStr_49 = value; }
        }

        private String _FldStr_50;
        [SpaceProperty(AliasName = "FldStr_50")]
        public String FldStr_50
        {
            get { return this._FldStr_50; }
            set { this._FldStr_50 = value; }
        }
        
    }
}
