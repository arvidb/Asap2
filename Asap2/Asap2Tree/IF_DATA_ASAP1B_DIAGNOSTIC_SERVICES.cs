using System;
using System.Collections.Generic;

namespace Asap2
{
    public class IF_DATA_ASAP1B_DIAGNOSTIC_SERVICES : IF_DATA
    {
        public IF_DATA_ASAP1B_DIAGNOSTIC_SERVICES(Location location) : base(location, "ASAP1B_DIAGNOSTIC_SERVICES")
        {
        }

        public List<SOURCE> Sources { get; } = new List<SOURCE>();

        public TP_BLOB TPBlob { get; set; }
    }

    public class SOURCE : Asap2Base
    {
        public SOURCE(Location location, string name, Int64 scalingUnit, Int64 rate) : base(location)
        {
            Name = name;
            ScalingUnit = scalingUnit;
            Rate = rate;
        }

        public string Name { get; }
        public Int64 ScalingUnit { get; }
        public Int64 Rate { get; }

        public QP_BLOB QPBlob { get; set; }
    }

    public class QP_BLOB : Asap2Base
    {
        public enum TRANSMISSION_MODE
        {
            TRANSMISSION_MODE_SLOW = 1, TRANSMISSION_MODE_MEDIUM = 2, TRANSMISSION_MODE_FAST = 3
        }

        public QP_BLOB(Location location, UInt64 version) : base(location)
        {
            this.Version = version;
        }

        public UInt64 Version { get; }

        public TRANSMISSION_MODE TransmissionMode { get; set; }

        public List<UUDT_CAN_IDS> UUDTRange { get; } = new List<UUDT_CAN_IDS>();
        public AVAILABLE_PERIODIC_IDENTIFIER_RANGE PRDIRange { get; set; }
    }

    public class TP_BLOB : Asap2Base
    {
        public enum BYTEORDER
        {
            BYTEORDER_MSB_FIRST = 1,
            BYTEORDER_MSB_LAST = 2,
            BYTE_ORDER_MSB_FIRST = 1,
            BYTE_ORDER_MSB_LAST = 2
        }

        public TP_BLOB(Location location, UInt64 version, string protocolVersion, BYTEORDER byteOrder) : base(location)
        {
            Version = version;
            ProtocolVersion = protocolVersion;
            ByteOrder = byteOrder;
        }

        public CAN_BLOB CANBlob { get; set; }

        public UInt64 Version { get; }
        public string ProtocolVersion { get; }
        public BYTEORDER ByteOrder { get; }
    }

    public class CAN_BLOB : Asap2Base
    {
        public CAN_BLOB(Location location, UInt64 baudrate, UInt64 samplePoint, UInt64 samplesPerBit, 
            UInt64 bTLCycles, UInt64 sJW, UInt64 syncEdge, Tuple<UInt64, UInt64> networkLimits) : base(location)
        {
            Baudrate = baudrate;
            SamplePoint = samplePoint;
            SamplesPerBit = samplesPerBit;
            BTLCycles = bTLCycles;
            SJW = sJW;
            SyncEdge = syncEdge;
            NetworkLimits = networkLimits;
        }

        public UInt64 Baudrate { get; }
        public UInt64 SamplePoint { get; }
        public UInt64 SamplesPerBit { get; }
        public UInt64 BTLCycles { get; }
        public UInt64 SJW { get; }
        public UInt64 SyncEdge { get; }

        public string TransportProtocolVersion { get; set; }

        public Tuple<UInt64, UInt64> NetworkLimits { get; }

        public UInt64 USDTSendId { get; set; }
        public UInt64 USDTReceiveId { get; set; }
    }

    public class UUDT_CAN_IDS : IdentifierRange
    {
        public UUDT_CAN_IDS(Location location, UInt64 firstId, UInt64 lastId) : base(location, firstId, lastId)
        {
        }
    }

    public class AVAILABLE_PERIODIC_IDENTIFIER_RANGE : IdentifierRange
    {
        public AVAILABLE_PERIODIC_IDENTIFIER_RANGE(Location location, UInt64 firstId, UInt64 lastId) : base(location, firstId, lastId)
        {
        }
    }

    public abstract class IdentifierRange : Asap2Base
    {
        public IdentifierRange(Location location, UInt64 firstId, UInt64 lastId) : base(location)
        {
            this.FirstId = firstId;
            this.LastId = lastId;
        }

        public UInt64 FirstId { get; }
        public UInt64 LastId { get; }
    }
}
