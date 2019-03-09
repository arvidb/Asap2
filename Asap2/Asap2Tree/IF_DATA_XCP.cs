using System;
using System.Collections.Generic;

namespace Asap2
{
    public class IF_DATA_XCP : IF_DATA
    {
        public IF_DATA_XCP(Location location) : base(location, "XCP")
        {
        }

        public PROTOCOL_LAYER ProtocolLayer { get; set; }

        public List<DAQ> DAQInfo = new List<DAQ>();

        public List<XCPTransportLayer> TransportLayer = new List<XCPTransportLayer>();
    }

    public class IF_DATA_SEGMENT_XCP : IF_DATA
    {
        public IF_DATA_SEGMENT_XCP(Location location) : base(location, "XCP")
        {
        }
    }

    public class XCPTransportLayer : Asap2Base
    {
        public XCPTransportLayer(Location location) : base(location)
        {
        }
    }

    public class XCP_ON_CAN : XCPTransportLayer
    {
        public XCP_ON_CAN(Location location, ulong version, ulong masterId, ulong slaveId, ulong baudrate) : base(location)
        {
            this.Version = version;
            this.MasterId = masterId;
            this.SlaveId = slaveId;
            this.Baudrate = baudrate;
        }

        public UInt64 Version { get; }
        public UInt64 MasterId { get; }
        public UInt64 SlaveId { get; }
        public UInt64 Baudrate { get; }
    }

    public class PROTOCOL_LAYER : Asap2Base
    {
        public PROTOCOL_LAYER(Location location, ulong version, ulong maxCTO, ulong maxDTO, string byteOrder, string addressGranularity) : base(location)
        {
            this.Version = version;
            this.MaxCTO = maxCTO;
            this.MaxDTO = maxDTO;
            this.ByteOrder = byteOrder;
            this.AddressGranularity = addressGranularity;
        }

        public UInt64 Version { get; private set; }

        public UInt64 MaxCTO { get; private set; }
        public UInt64 MaxDTO { get; private set; }

        public string ByteOrder { get; private set; }
        public string AddressGranularity { get; private set; }

        public List<UInt64> Timeouts { get; private set; } = new List<UInt64>();
    }

    public class DAQ : Asap2Base
    {
        public DAQ(Location location, string type, ulong maxDAQ, ulong maxEventChannel, ulong minDAQ, 
            string optimisationType, string addressExtension, string identificationField, string granularityType, ulong maxODTEntrySizeDAQ, string overloadIndication) : base(location)
        {
            this.type = type;
            this.maxDAQ = maxDAQ;
            this.maxEventChannel = maxEventChannel;
            this.minDAQ = minDAQ;
            this.optimisationType = optimisationType;
            this.addressExtension = addressExtension;
            this.identificationField = identificationField;
            this.granularityType = granularityType;
            this.maxODTEntrySizeDAQ = maxODTEntrySizeDAQ;
            this.overloadIndication = overloadIndication;
        }

        public string type { get; private set; }

        public UInt64 maxDAQ { get; private set; }
        public UInt64 maxEventChannel { get; private set; }
        public UInt64 minDAQ { get; private set; }

        public string optimisationType { get; private set; }
        public string addressExtension { get; private set; }
        public string identificationField { get; private set; }
        public string granularityType { get; private set; }

        public UInt64 maxODTEntrySizeDAQ { get; private set; }

        public string overloadIndication { get; private set; }

        public List<DAQList> DAQLists = new List<DAQList>();
    }

    public class DAQList : Asap2Base
    {
        public DAQList(Location location, UInt64 number, string type, UInt64 maxOdt, UInt64 maxOdtEntries, Nullable<decimal> firstPID, Nullable<decimal> eventFixed) : base(location)
        {
            this.Number = number;
            this.Type = type;
            this.MaxOdt = maxOdt;
            this.MaxOdtEntries = maxOdtEntries;
            this.FirstPID = (UInt64)(firstPID ?? 0);
            this.EventFixed = (UInt64)(eventFixed ?? 0);
        }

        public UInt64 Number { get; private set; }
        public string Type { get; private set; }
        public UInt64 MaxOdt { get; private set; }
        public UInt64 MaxOdtEntries { get; private set; }
        public UInt64 FirstPID { get; private set; }
        public UInt64 EventFixed { get; private set; }
    }
}
