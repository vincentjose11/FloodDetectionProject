Flood Detection Project - Assumptions

1. CSV File Format:
   - Device CSV contains headers: Device ID, Device Name, Location
   - Rainfall CSV contains headers: Device ID, Time, Rainfall
   - CSV files are consistent and properly formatted.

2. Time Handling:
   - The latest timestamp across all rainfall records is treated as the current time.
   - All timestamps are assumed to be in the same timezone.

3. Data Scope:
   - Only rainfall readings from the last 4 hours from the latest timestamp are considered.

4. Device Matching:
   - Device ID is used as the key to join rainfall data with device details.
   - If a device exists in rainfall data but not in the device list, it will still be processed but may show missing device details.

5. Status Calculation:
   - Green: Average rainfall < 10mm
   - Amber: Average rainfall < 15mm
   - Red: Average rainfall >= 15mm OR any reading in last 4 hours > 30mm

6. Trend Calculation:
   - Trend is determined by comparing the first and last rainfall values in the last 4-hour window.
   - If last > first → Increasing
   - If last < first → Decreasing
   - Otherwise → Stable

7. Missing Data:
   - Devices with no readings in the last 4 hours are not displayed.

8. CSV Files:
   - Multiple rainfall CSV files may exist in the folder and are all processed together.

9. Error Handling:
   - Basic error handling is applied for file reading.
   - It is assumed that files are accessible and not corrupted.

10. External Libraries:
   - CsvHelper library is used for CSV parsing.
