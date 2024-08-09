using System;

namespace _51DegreesFullExample.Models
{
    public class DeviceDetectionDto
    {
        /// <summary>
        /// Capture the data on the device but then sort out the deserialization on the server side to prevent unnecessary client-side errors
        /// </summary>
        public string SerializedDeviceData { get; set; }
    }
}
