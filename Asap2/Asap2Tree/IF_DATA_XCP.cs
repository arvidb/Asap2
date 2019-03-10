﻿using System;
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

    public abstract class XCPTransportLayer : Asap2Base
    {
        protected XCPTransportLayer(Location location) : base(location)
        {
        }
    }

    public class XCP_ON_CAN : XCPTransportLayer
    {
        public XCP_ON_CAN(Location location, UInt64 version, UInt64 masterId, UInt64 slaveId, UInt64 baudrate) : base(location)
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

    public class XCP_ON_UDP_IP : XCPTransportLayer
    {
        public XCP_ON_UDP_IP(Location location, UInt64 version, UInt64 port, string hostname, string address) : base(location)
        {
            this.Version = version;
            this.Port = port;
            this.Hostname = hostname;
            this.Address = address;
        }

        public UInt64 Version { get; }
        public UInt64 Port { get; }
        public string Hostname { get; }
        public string Address { get; }
    }

    public class PROTOCOL_LAYER : Asap2Base
    {
        public PROTOCOL_LAYER(Location location, UInt64 version, UInt64 maxCTO, UInt64 maxDTO, string byteOrder, string addressGranularity) : base(location)
        {
            this.Version = version;
            this.MaxCTO = maxCTO;
            this.MaxDTO = maxDTO;
            this.ByteOrder = byteOrder;
            this.AddressGranularity = addressGranularity;
        }

        public UInt64 Version { get; }

        public UInt64 MaxCTO { get; }
        public UInt64 MaxDTO { get; }

        public string ByteOrder { get; }
        public string AddressGranularity { get; }

        public List<UInt64> Timeouts { get; } = new List<UInt64>();
    }

    public class DAQ : Asap2Base
    {
        public DAQ(Location location, string type, UInt64 maxDAQ, UInt64 maxEventChannel, UInt64 minDAQ, 
            string optimisationType, string addressExtension, string identificationField, string granularityType, UInt64 maxODTEntrySizeDAQ, string overloadIndication) : base(location)
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

        public string type { get; }

        public UInt64 maxDAQ { get; }
        public UInt64 maxEventChannel { get; }
        public UInt64 minDAQ { get; }

        public string optimisationType { get; }
        public string addressExtension { get; }
        public string identificationField { get; }
        public string granularityType { get; }

        public UInt64 maxODTEntrySizeDAQ { get; }

        public string overloadIndication { get; }

        public List<DAQList> DAQLists = new List<DAQList>();
    }

    public class DAQList : Asap2Base
    {
        public DAQList(Location location, UInt64 number, string type, UInt64 maxOdt, UInt64 maxOdtEntries, decimal? firstPID, decimal? eventFixed) : base(location)
        {
            this.Number = number;
            this.Type = type;
            this.MaxOdt = maxOdt;
            this.MaxOdtEntries = maxOdtEntries;
            this.FirstPID = (UInt64)(firstPID ?? 0);
            this.EventFixed = (UInt64)(eventFixed ?? 0);
        }

        public UInt64 Number { get; }
        public string Type { get; }
        public UInt64 MaxOdt { get; }
        public UInt64 MaxOdtEntries { get; }
        public UInt64 FirstPID { get; }
        public UInt64 EventFixed { get; }
    }
}
