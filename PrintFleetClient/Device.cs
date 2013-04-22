using System;

namespace PrintFleetClient
{
    public class Device
    {
        public Device() { }

        public Guid Id { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public string Status { get; set; }
        public DateTime LastReportedAt { get; set; }
    }
}
