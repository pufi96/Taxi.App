using Taxi.Aplication.Contracts.Infrastructure;

namespace Taxi.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    //public byte[] ExportEventsToCsv(List<ShiftExportDto> eventExportDtos)
    //{
    //    using var memoryStream = new MemoryStream();
    //    using (var streamWriter = new StreamWriter(memoryStream))
    //    {
    //        using var csvWriter = new CsvWriter(streamWriter);
    //        csvWriter.WriteRecords(eventExportDtos);
    //    }

    //    return memoryStream.ToArray();
    //}
}