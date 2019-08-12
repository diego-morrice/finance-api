using System;
using Finance.Common.Events.Interfaces;

namespace Finance.Common.Events.Assets {
    public class AssetCreated : IEvent { 

        public Guid Id;      
        public string Name { get; }
        public string Symbol { get; }
        public string Type { get; }
        public string Market { get; }
        public string ISIN { get; }
        public string CUSIP { get; }
        public string Underlying { get; }
        public string Class { get; }

        protected AssetCreated () 
        {

        }

         public AssetCreated (Guid Id, string name, string symbol, string type, string market
         , string isin, string cusip, string underlying, string assetClass) {

            this.Id = Id;
            this.Name = name;
            this.Symbol = symbol;
            this.Type = type;
            this.Market = market;
            this.ISIN = isin;
            this.CUSIP = cusip;
            this.Underlying = underlying;
            this.Class = assetClass;
        }
    }
}