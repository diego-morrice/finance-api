using System;
using Finance.Common.Commands.Infertaces;

namespace Finance.Common.Commands.Assets
{
    public class CreateAsset : ICommand
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Symbol {get; set;}
        public string Type {get; set;}
        public string Market {get; set;}
        public string Issuer {get; set;}
        public string ISIN {get; set;}
        public string CUSIP {get; set;}
        public string Underlying {get; set;}
        public string Class {get; set;}
    }
}