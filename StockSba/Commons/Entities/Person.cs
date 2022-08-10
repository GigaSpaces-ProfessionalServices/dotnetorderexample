using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GigaSpaces.Core.Metadata;

namespace GigaSpaces.Examples.StockSba.Commons.Entities
{
    [SpaceClass(Persist = true)]
    public class Person
    {
        private long _id;
        [SpaceProperty(AliasName = "id")]
        [SpaceID]
        public long Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        private string _name;
        [SpaceProperty(AliasName = "name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private long _timestamp;
        [SpaceProperty(AliasName = "timestamp")]
        public long Timestamp
        {
            get { return this._timestamp; }
            set { this._timestamp = value; }
        }

        private string _dotnetEventContainer;
        [SpaceProperty(AliasName = "dotnetEventContainer")]
        public string DotnetEventContainer
        {
            get { return this._dotnetEventContainer; }
            set { this._dotnetEventContainer = value; }
        }
        public override string ToString()
        {
            return "Person #" + _id + ": " + _name;
        }
    }
}
