namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand;

[Serializable]
public class FileUploadStates : List<FileUploadState>
{
}

[Serializable]
public class FileUploadState
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string Extension { get; set; }
    public string Path { get; set; }
    public byte[] Data { get; set; }
    public int FileSize { get; set; }
    public Guid? EiStandaardId { get; set; }
    public string EiStandaardCode { get; set; }
    public string EiStandaardNaam { get; set; }
}