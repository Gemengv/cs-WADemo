using WADemo.BLL;
using WADemo.Core;
using WADemo.Core.Interfaces;
using WADemo.DAL;

namespace WADemo.App.Factories;

internal static class ServiceFactory
{
  private const string DataDir = "..{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}";
  private const string DataFile = "almanac.csv";


  internal static IRecordService GetRecordService(ApplicationMode applicationMode, LoggingMode loggingMode)
  {
    return applicationMode == ApplicationMode.Live
      ? new RecordService(new CsvRecordRepository(DataDir + DataFile, LoggerFactory.GetLogger(loggingMode)))
      : new RecordService(new MockRecordRepository());
  }
}
