using System;

namespace Asap2
{
    public class IF_DATA_ASAP1B_DIAGNOSTIC_SERVICES : IF_DATA
    {
        public IF_DATA_ASAP1B_DIAGNOSTIC_SERVICES(Location location) : base(location, "ASAP1B_DIAGNOSTIC_SERVICES")
        {
        }

        public TP_BLOB TPBlob { get; set; }
    }

    public class TP_BLOB : Asap2Base
    {
        public TP_BLOB(Location location) : base(location)
        {
        }

        public CAN_BLOB CANBlob { get; set; }
    }

    public class CAN_BLOB : Asap2Base
    {
        public CAN_BLOB(Location location) : base(location)
        {
        }

        public UInt64 USDTSendId { get; set; }
        public UInt64 USDTReceiveId { get; set; }
    }
}
