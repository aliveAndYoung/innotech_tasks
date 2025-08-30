using System;
using System.Management;
using System.Runtime.Versioning;
using System.Text;

namespace SystemDetailsCollector
{
    [SupportedOSPlatform("windows")]
    public class SystemInfoCollector
    {
        public string GetComprehensiveSystemInfo()
        {
            var systemReport = new StringBuilder();

            // Get processor information
            systemReport.AppendLine("=== PROCESSOR INFORMATION ===");
            systemReport.AppendLine(GetProcessorInfo());

            // Get processor temperature (if available)
            systemReport.AppendLine("=== PROCESSOR TEMPERATURE ===");
            systemReport.AppendLine(GetProcessorTemperature());

            // Get operating system information
            systemReport.AppendLine("=== OPERATING SYSTEM INFORMATION ===");
            systemReport.AppendLine(GetOperatingSystemInfo());

            // Get RAM information
            systemReport.AppendLine("=== RAM INFORMATION ===");
            systemReport.AppendLine(GetRamInfo());

            // Get hard disk information
            systemReport.AppendLine("=== HARD DISK INFORMATION ===");
            systemReport.AppendLine(GetHardDiskInfo());

            return systemReport.ToString();
        }

        private string GetProcessorInfo()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                var result = new StringBuilder();

                foreach (ManagementObject processor in searcher.Get())
                {
                    result.AppendLine($"Name: {processor["Name"]}");
                    result.AppendLine($"Manufacturer: {processor["Manufacturer"]}");
                    result.AppendLine($"Architecture: {processor["Architecture"]}");
                    result.AppendLine($"NumberOfCores: {processor["NumberOfCores"]}");
                    result.AppendLine(
                        $"NumberOfLogicalProcessors: {processor["NumberOfLogicalProcessors"]}"
                    );
                    result.AppendLine($"MaxClockSpeed: {processor["MaxClockSpeed"]} MHz");
                    result.AppendLine($"CurrentClockSpeed: {processor["CurrentClockSpeed"]} MHz");
                    result.AppendLine($"L2CacheSize: {processor["L2CacheSize"]} KB");
                    result.AppendLine($"L3CacheSize: {processor["L3CacheSize"]} KB");
                    result.AppendLine($"SocketDesignation: {processor["SocketDesignation"]}");
                    result.AppendLine($"ProcessorId: {processor["ProcessorId"]}");
                    result.AppendLine();
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving processor information: {ex.Message}";
            }
        }

        private string GetProcessorTemperature()
        {
            try
            {
                // Try multiple WMI classes for temperature data
                string[] temperatureClasses =
                {
                    "Win32_TemperatureProbe",
                    "Win32_Processor",
                    "MSAcpi_ThermalZoneTemperature",
                };

                var result = new StringBuilder();

                foreach (string className in temperatureClasses)
                {
                    try
                    {
                        using var searcher = new ManagementObjectSearcher(
                            $"SELECT * FROM {className}"
                        );
                        var collection = searcher.Get();

                        if (collection.Count > 0)
                        {
                            result.AppendLine($"Temperature data from {className}:");
                            foreach (ManagementObject obj in collection)
                            {
                                if (obj["CurrentReading"] != null)
                                {
                                    double temp = Convert.ToDouble(obj["CurrentReading"]);
                                    // Convert from tenths of Kelvin to Celsius
                                    double tempCelsius = (temp / 10.0) - 273.15;
                                    result.AppendLine($"Current Temperature: {tempCelsius:F1}°C");
                                }
                                else if (obj["CurrentTemperature"] != null)
                                {
                                    result.AppendLine(
                                        $"Current Temperature: {obj["CurrentTemperature"]}°C"
                                    );
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Continue to next class if this one fails
                    }
                }

                if (result.Length == 0)
                {
                    result.AppendLine(
                        "Processor temperature not accessible due to security restrictions or hardware limitations."
                    );
                    result.AppendLine("This is common on Windows 10/11 systems.");
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving processor temperature: {ex.Message}";
            }
        }

        private string GetOperatingSystemInfo()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_OperatingSystem"
                );
                var result = new StringBuilder();

                foreach (ManagementObject os in searcher.Get())
                {
                    result.AppendLine($"Name: {os["Name"]}");
                    result.AppendLine($"Version: {os["Version"]}");
                    result.AppendLine($"BuildNumber: {os["BuildNumber"]}");
                    result.AppendLine($"Manufacturer: {os["Manufacturer"]}");
                    result.AppendLine($"OSArchitecture: {os["OSArchitecture"]}");
                    result.AppendLine(
                        $"TotalVirtualMemorySize: {Convert.ToDouble(os["TotalVirtualMemorySize"]) / (1024 * 1024):F2} GB"
                    );
                    result.AppendLine(
                        $"FreeVirtualMemory: {Convert.ToDouble(os["FreeVirtualMemory"]) / (1024 * 1024):F2} GB"
                    );
                    result.AppendLine(
                        $"TotalVisibleMemorySize: {Convert.ToDouble(os["TotalVisibleMemorySize"]) / (1024 * 1024):F2} GB"
                    );
                    result.AppendLine(
                        $"FreePhysicalMemory: {Convert.ToDouble(os["FreePhysicalMemory"]) / (1024 * 1024):F2} GB"
                    );
                    result.AppendLine($"InstallDate: {os["InstallDate"]}");
                    result.AppendLine($"LastBootUpTime: {os["LastBootUpTime"]}");
                    result.AppendLine($"SystemDirectory: {os["SystemDirectory"]}");
                    result.AppendLine();
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving OS information: {ex.Message}";
            }
        }

        private string GetRamInfo()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PhysicalMemory"
                );
                var result = new StringBuilder();

                foreach (ManagementObject ram in searcher.Get())
                {
                    result.AppendLine($"DeviceLocator: {ram["DeviceLocator"]}");
                    result.AppendLine(
                        $"Capacity: {Convert.ToDouble(ram["Capacity"]) / (1024 * 1024 * 1024):F2} GB"
                    );
                    result.AppendLine($"Speed: {ram["Speed"]} MHz");
                    result.AppendLine($"Manufacturer: {ram["Manufacturer"]}");
                    result.AppendLine($"PartNumber: {ram["PartNumber"]}");
                    result.AppendLine($"SerialNumber: {ram["SerialNumber"]}");
                    result.AppendLine($"MemoryType: {ram["MemoryType"]}");
                    result.AppendLine($"FormFactor: {ram["FormFactor"]}");
                    result.AppendLine($"DataWidth: {ram["DataWidth"]} bits");
                    result.AppendLine($"TotalWidth: {ram["TotalWidth"]} bits");
                    result.AppendLine();
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving RAM information: {ex.Message}";
            }
        }

        private string GetHardDiskInfo()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                var result = new StringBuilder();

                foreach (ManagementObject disk in searcher.Get())
                {
                    result.AppendLine($"Model: {disk["Model"]}");
                    result.AppendLine($"Manufacturer: {disk["Manufacturer"]}");
                    result.AppendLine($"SerialNumber: {disk["SerialNumber"]}");
                    result.AppendLine(
                        $"Size: {Convert.ToDouble(disk["Size"]) / (1024 * 1024 * 1024):F2} GB"
                    );
                    result.AppendLine($"InterfaceType: {disk["InterfaceType"]}");
                    result.AppendLine($"MediaType: {disk["MediaType"]}");
                    result.AppendLine($"Partitions: {disk["Partitions"]}");
                    result.AppendLine($"BytesPerSector: {disk["BytesPerSector"]}");
                    result.AppendLine($"SectorsPerTrack: {disk["SectorsPerTrack"]}");
                    result.AppendLine($"TotalCylinders: {disk["TotalCylinders"]}");
                    result.AppendLine($"TotalHeads: {disk["TotalHeads"]}");
                    result.AppendLine($"TotalSectors: {disk["TotalSectors"]}");
                    result.AppendLine($"TotalTracks: {disk["TotalTracks"]}");
                    result.AppendLine($"FirmwareRevision: {disk["FirmwareRevision"]}");
                    result.AppendLine($"Status: {disk["Status"]}");
                    result.AppendLine();
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving hard disk information: {ex.Message}";
            }
        }
    }
}
