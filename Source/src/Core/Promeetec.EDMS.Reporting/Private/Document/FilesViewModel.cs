using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document;

public enum UploadType
{
    Onbekend = 0,
    Voorraadbestand = 1,
    Overigbestand = 2,
    Rapportage = 3
}

public class ExistingFile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class UploadResult
{
    public List<string> Feedback { get; set; } = new();
    public bool Overwrite { get; set; }
    public List<Guid> FileIds { get; set; } = new();
    public List<Guid> ExistingFileIds { get; set; } = new();
    public List<ExistingFile> ExsistingFiles { get; set; } = new();
}

public class FilesViewModel : ViewModelBase
{
    [HiddenInput(DisplayValue = false)]
    public string FileIds { get; set; }

    public UploadType UploadType { get; set; }

    [HiddenInput(DisplayValue = false)]
    public string ExistingFileIds { get; set; }

    public string CssClass { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid AanleveringId { get; set; }

    public string MaxFiles => ConfigurationExtensions.GetString("MaxFiles");
    public string FileSizeLimitMB => ConfigurationExtensions.GetString("FileSizeLimitMB");

    public string BlockedFileExtensions => ConfigurationExtensions.GetString("BlockFileExtensions");
}