//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TollManagement.Data
{
    using System;
    
    public partial class sp_LS_Lane_Devices_GetInformation_Result
    {
        public int idLane { get; set; }
        public string codeLane { get; set; }
        public string nameLane { get; set; }
        public short directionTypeLane { get; set; }
        public int typeLane { get; set; }
        public string noteLane { get; set; }
        public bool isUseLane { get; set; }
        public int idDVs { get; set; }
        public int idLaneDeviceDVs { get; set; }
        public string deviceCodeTypeDVs { get; set; }
        public string ipAddressDVs { get; set; }
        public string stationCodeDVs { get; set; }
        public string laneCodeDVs { get; set; }
        public short StatusDVs { get; set; }
        public System.DateTime DateModifyDVs { get; set; }
        public int SequenceDVs { get; set; }
        public string noteDVs { get; set; }
        public string DeviceIDDVlane { get; set; }
        public string IpAddressDVlane { get; set; }
        public Nullable<int> MaxSequenceDVlane { get; set; }
    }
}
