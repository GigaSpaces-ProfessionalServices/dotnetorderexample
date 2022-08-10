﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GigaSpaces.Examples.StockSba.Commons
{
    public class TestDataHelper
    {
        public const string ActionBuy = "Buy";
        public const string ActionSell = "Sell";

        public static readonly string[] Actions = { ActionBuy, ActionSell };

        public static readonly string[] Symbols =
            {
                "IBM", "MSFT", "DELL", "ABI", "ADM", "ADBE", "GM", "GE", "DE", "DHR", "DIS",
                "GGP", "GLW", "GS", "LOW", "LSI", "LGM", "PDCO", "PAYX", "PEG", "RAU",
                "RK", "ROH", "TAP", "TEK", "THC", "TEX", "TJX", "VAR", "VLO", "VMC",
                "WAG", "WFMI", "WFR", "XEL", "XTO"
            };

        public static readonly string[] Currency = 
        { 
           "Albanian Lek (ALL)","Algerian Dinar (DZD)","Aluminium Ounces (XAL)","Argentine Peso (ARS)","Aruba Florin (AWG)",
           "Australian Dollar (AUD)","Bahamian Dollar (BSD)","Bahraini Dinar (BHD)","Bangladesh Taka (BDT)","Barbados Dollar (BBD)","Belarus Ruble (BYR)","Belize Dollar (BZD)",
           "Bermuda Dollar (BMD)","Bhutan Ngultrum (BTN)","Bolivian Boliviano (BOB)","Botswana Pula (BWP)","Brazilian Real (BRL)","British Pound (GBP)","Brunei Dollar (BND)",
           "Bulgarian Lev (BGN)","Burundi Franc (BIF)","Cambodia Riel (KHR)","Canadian Dollar (CAD)","Cape Verde Escudo (CVE)","Cayman Islands Dollar (KYD)","CFA Franc (BCEAO) (XOF)",
           "CFA Franc (BEAC) (XAF)","Chilean Peso (CLP)","Chinese Yuan (CNY)","Colombian Peso (COP)","Comoros Franc (KMF)","Copper Pounds (XCP)","Costa Rica Colon (CRC)","Croatian Kuna (HRK)",
           "Cuban Peso (CUP)","Cyprus Pound (CYP)","Czech Koruna (CZK)","Danish Krone (DKK)","Dijibouti Franc (DJF)","Dominican Peso (DOP)","East Caribbean Dollar (XCD)","Ecuador Sucre (ECS)",
           "Egyptian Pound (EGP)","El Salvador Colon (SVC)","Eritrea Nakfa (ERN)","Estonian Kroon (EEK)","Ethiopian Birr (ETB)","Euro (EUR)","Falkland Islands Pound (FKP)","Fiji Dollar (FJD)",
           "Gambian Dalasi (GMD)","Ghanian Cedi (GHC)","Gibraltar Pound (GIP)","Gold Ounces (XAU)","Guatemala Quetzal (GTQ)","Guinea Franc (GNF)","Guyana Dollar (GYD)","Haiti Gourde (HTG)",
           "Honduras Lempira (HNL)","Hong Kong Dollar (HKD)","Hungarian Forint (HUF)","Iceland Krona (ISK)","Indian Rupee (INR)","Indonesian Rupiah (IDR)","Iran Rial (IRR)","Iraqi Dinar (IQD)",
           "Israeli Shekel (ILS)","Jamaican Dollar (JMD)","Japanese Yen (JPY)","Jordanian Dinar (JOD)","Kazakhstan Tenge (KZT)","Kenyan Shilling (KES)","Korean Won (KRW)","Kuwaiti Dinar (KWD)",
           "Lao Kip (LAK)","Latvian Lat (LVL)","Lebanese Pound (LBP)","Lesotho Loti (LSL)","Liberian Dollar (LRD)","Libyan Dinar (LYD)","Lithuanian Lita (LTL)","Macau Pataca (MOP)","Macedonian Denar (MKD)",
           "Malawi Kwacha (MWK)","Malaysian Ringgit (MYR)","Maldives Rufiyaa (MVR)","Maltese Lira (MTL)","Mauritania Ougulya (MRO)","Mauritius Rupee (MUR)","Mexican Peso (MXN)","Moldovan Leu (MDL)",
           "Mongolian Tugrik (MNT)","Moroccan Dirham (MAD)","Myanmar Kyat (MMK)","Namibian Dollar (NAD)","Nepalese Rupee (NPR)","Neth Antilles Guilder (ANG)","New Turkish Lira (TRY)","New Zealand Dollar (NZD)",
           "Nicaragua Cordoba (NIO)","Nigerian Naira (NGN)","North Korean Won (KPW)","Norwegian Krone (NOK)","Omani Rial (OMR)","Pacific Franc (XPF)","Pakistani Rupee (PKR)","Palladium Ounces (XPD)",
           "Panama Balboa (PAB)","Papua New Guinea Kina (PGK)","Paraguayan Guarani (PYG)","Peruvian Nuevo Sol (PEN)","Philippine Peso (PHP)","Platinum Ounces (XPT)","Polish Zloty (PLN)","Qatar Rial (QAR)",
           "Romanian New Leu (RON)","Russian Rouble (RUB)","Rwanda Franc (RWF)","Samoa Tala (WST)","Sao Tome Dobra (STD)","Saudi Arabian Riyal (SAR)","Seychelles Rupee (SCR)","Sierra Leone Leone (SLL)",
           "Silver Ounces (XAG)","Singapore Dollar (SGD)","Slovak Koruna (SKK)","Slovenian Tolar (SIT)","Solomon Islands Dollar (SBD)","Somali Shilling (SOS)","South African Rand (ZAR)","Sri Lanka Rupee (LKR)",
           "St Helena Pound (SHP)","Sudanese Dinar (SDD)","Swaziland Lilageni (SZL)","Swedish Krona (SEK)","Swiss Franc (CHF)","Syrian Pound (SYP)","Taiwan Dollar (TWD)","Tanzanian Shilling (TZS)","Thai Baht (THB)",
           "Tonga Pa'anga (TOP)","Trinidad&Tobago Dollar (TTD)","Tunisian Dinar (TND)","U.S. Dollar (USD)","UAE Dirham (AED)","Ugandan Shilling (UGX)","Ukraine Hryvnia (UAH)","Uruguayan New Peso (UYU)","Vanuatu Vatu (VUV)",
           "Venezuelan Bolivar (VEB)","Vietnam Dong (VND)","Yemen Riyal (YER)","Zambian Kwacha (ZMK)","Zimbabwe Dollar (ZWD)","Albanian Lek (ALL)","Algerian Dinar (DZD)","Aluminium Ounces (XAL)","Argentine Peso (ARS)",
           "Aruba Florin (AWG)","Australian Dollar (AUD)","Bahamian Dollar (BSD)","Bahraini Dinar (BHD)","Bangladesh Taka (BDT)","Barbados Dollar (BBD)","Belarus Ruble (BYR)","Belize Dollar (BZD)","Bermuda Dollar (BMD)",
           "Bhutan Ngultrum (BTN)","Bolivian Boliviano (BOB)","Botswana Pula (BWP)","Brazilian Real (BRL)","British Pound (GBP)","Brunei Dollar (BND)","Bulgarian Lev (BGN)","Burundi Franc (BIF)","Cambodia Riel (KHR)",
           "Canadian Dollar (CAD)","Cape Verde Escudo (CVE)","Cayman Islands Dollar (KYD)","CFA Franc (BCEAO) (XOF)","CFA Franc (BEAC) (XAF)","Chilean Peso (CLP)","Chinese Yuan (CNY)","Colombian Peso (COP)",
           "Comoros Franc (KMF)","Copper Pounds (XCP)","Costa Rica Colon (CRC)","Croatian Kuna (HRK)","Cuban Peso (CUP)","Cyprus Pound (CYP)","Czech Koruna (CZK)","Danish Krone (DKK)","Dijibouti Franc (DJF)",
           "Dominican Peso (DOP)","East Caribbean Dollar (XCD)","Ecuador Sucre (ECS)","Egyptian Pound (EGP)","El Salvador Colon (SVC)","Eritrea Nakfa (ERN)","Estonian Kroon (EEK)","Ethiopian Birr (ETB)",
           "Euro (EUR)","Falkland Islands Pound (FKP)","Fiji Dollar (FJD)","Gambian Dalasi (GMD)","Ghanian Cedi (GHC)","Gibraltar Pound (GIP)","Gold Ounces (XAU)","Guatemala Quetzal (GTQ)","Guinea Franc (GNF)",
           "Guyana Dollar (GYD)","Haiti Gourde (HTG)","Honduras Lempira (HNL)","Hong Kong Dollar (HKD)","Hungarian Forint (HUF)","Iceland Krona (ISK)","Indian Rupee (INR)","Indonesian Rupiah (IDR)",
           "Iran Rial (IRR)","Iraqi Dinar (IQD)","Israeli Shekel (ILS)","Jamaican Dollar (JMD)","Japanese Yen (JPY)","Jordanian Dinar (JOD)","Kazakhstan Tenge (KZT)","Kenyan Shilling (KES)",
           "Korean Won (KRW)","Kuwaiti Dinar (KWD)","Lao Kip (LAK)","Latvian Lat (LVL)","Lebanese Pound (LBP)","Lesotho Loti (LSL)","Liberian Dollar (LRD)","Libyan Dinar (LYD)","Lithuanian Lita (LTL)",
           "Macau Pataca (MOP)","Macedonian Denar (MKD)","Malawi Kwacha (MWK)","Malaysian Ringgit (MYR)","Maldives Rufiyaa (MVR)","Maltese Lira (MTL)","Mauritania Ougulya (MRO)","Mauritius Rupee (MUR)",
           "Mexican Peso (MXN)","Moldovan Leu (MDL)","Mongolian Tugrik (MNT)","Moroccan Dirham (MAD)","Myanmar Kyat (MMK)","Namibian Dollar (NAD)","Nepalese Rupee (NPR)","Neth Antilles Guilder (ANG)",
           "New Turkish Lira (TRY)","New Zealand Dollar (NZD)","Nicaragua Cordoba (NIO)","Nigerian Naira (NGN)","North Korean Won (KPW)","Norwegian Krone (NOK)","Omani Rial (OMR)","Pacific Franc (XPF)",
           "Pakistani Rupee (PKR)","Palladium Ounces (XPD)","Panama Balboa (PAB)","Papua New Guinea Kina (PGK)","Paraguayan Guarani (PYG)","Peruvian Nuevo Sol (PEN)","Philippine Peso (PHP)","Platinum Ounces (XPT)",
           "Polish Zloty (PLN)","Qatar Rial (QAR)","Romanian New Leu (RON)","Russian Rouble (RUB)","Rwanda Franc (RWF)","Samoa Tala (WST)","Sao Tome Dobra (STD)","Saudi Arabian Riyal (SAR)","Seychelles Rupee (SCR)",
           "Sierra Leone Leone (SLL)","Silver Ounces (XAG)","Singapore Dollar (SGD)","Slovak Koruna (SKK)","Slovenian Tolar (SIT)","Solomon Islands Dollar (SBD)","Somali Shilling (SOS)","South African Rand (ZAR)",
           "Sri Lanka Rupee (LKR)","St Helena Pound (SHP)","Sudanese Dinar (SDD)","Swaziland Lilageni (SZL)","Swedish Krona (SEK)","Swiss Franc (CHF)","Syrian Pound (SYP)","Taiwan Dollar (TWD)","Tanzanian Shilling (TZS)",
           "Thai Baht (THB)","Tonga Pa'anga (TOP)","Trinidad&Tobago Dollar (TTD)","Tunisian Dinar (TND)","U.S. Dollar (USD)","UAE Dirham (AED)","Ugandan Shilling (UGX)","Ukraine Hryvnia (UAH)","Uruguayan New Peso (UYU)",
           "Vanuatu Vatu (VUV)","Venezuelan Bolivar (VEB)","Vietnam Dong (VND)","Yemen Riyal (YER)","Zambian Kwacha (ZMK)","Zimbabwe Dollar (ZWD)"};
    }
}
