namespace MyProject.Core.Tests;

public class FileProcessorTests
{
   private readonly FileProcessor _fileProcessor;

   public FileProcessorTests()
   {
      _fileProcessor = new FileProcessor();    
   }


   [Fact]
   public async Task ProcessFileAsync_WithTimeoutFile_ThrowsTimeoutException()
   {
      // Arrange
      string fileName = "timeout-file.txt";

      // Act & Assert

      var exception = await Assert.ThrowsAsync<TimeoutException>(() => 
         _fileProcessor.ProcessFileAsync(fileName, TestContext.Current.CancellationToken));

      Assert.Contains("timeout", exception.Message);
      Assert.Contains(fileName, exception.Message);
   }

   [Fact]
   public void ProcessFile_WithCorruptFile_ThrowsProcessingExceptionWithInnerException()
   {
      // Arrange
      string fileName = "corrupt-file.txt";

      // Act & Assert
      var exception = Assert.Throws<ProcessingException>(() => _fileProcessor.ProcessingFile(fileName));

      // Validate outer exception
      Assert.Equal(fileName, exception.FileName);
      Assert.Equal(42, exception.LineNumber);
      Assert.Contains("Data corruption detected", exception.Message);

      // Validate inner exception
      Assert.NotNull(exception.InnerException);
      var innerException = Assert.IsType<InvalidDataException>(exception.InnerException);
      Assert.Contains("invalid data", innerException.Message);
   }
}
