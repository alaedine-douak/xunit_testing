namespace MyProject.Core;

internal class FileNotFoundException : Exception
{
   public string FileName { get; }

   public FileNotFoundException(string fileName) : base($"File '{fileName}' was not found.")
   {
      FileName = fileName;
   }
}

internal class ProcessingException : Exception
{
   public string FileName { get; }
   public int LineNumber { get; }

   public ProcessingException(string fileName, int lineNumber, string message, Exception? innerException = null) 
      : base($"Error processing file '{fileName}' at line {lineNumber}: {message}", innerException)
   {
      FileName = fileName;
      LineNumber = lineNumber;
   }
}

internal class FileProcessor
{
   internal string ProcessingFile(string fileName)
   {
      if (string.IsNullOrWhiteSpace(fileName))
         throw new ArgumentException("File name cannot be null o empty", nameof(fileName));

      if (!fileName.EndsWith(".txt"))
         throw new ArgumentException("Only .txt files are supported", nameof(fileName));

      // simulate file not found
      if (fileName.Contains("missing")) throw new FileNotFoundException(fileName);

      // simulate processing error
      if (fileName.Contains("corrupt"))
      {
         var innerException = new InvalidDataException("File contains invalid data");
         throw new ProcessingException(fileName, 42, "Data corruption detected", innerException);
      }

      return $"Processed: {fileName}";
   }

   internal async Task<string> ProcessFileAsync(string fileName, CancellationToken cancellationToken = default)
   {
      if (string.IsNullOrWhiteSpace(fileName)) 
         throw new ArgumentException("File name cannot be null or empty", nameof(fileName));

      await Task.Delay(1000, cancellationToken);

      if (fileName.Contains("timeout")) throw new TimeoutException($"Processing of '{fileName}' timed out");

      if (fileName.Contains("network")) throw new HttpRequestException($"Network error while processing '{fileName}'");

      return $"Async processed: {fileName}";
   }

}  
