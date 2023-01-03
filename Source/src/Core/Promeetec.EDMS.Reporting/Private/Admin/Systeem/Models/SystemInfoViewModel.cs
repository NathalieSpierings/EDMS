using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Systeem.Models;

public class SystemInfoViewModel : ModelBase
{
    [DisplayName("EDMS versie")]
    public string AppVersion => ConfigurationManager.AppSettings["AppVersion"];

    [UIHint("Date")]
    [DisplayName("Gemaakt op")]
    public DateTime AppDate { get; set; }


    [DisplayName("Operating systeem")]
    public string OperatingSystem { get; set; }


    [DisplayName("ASP.NET Info")]
    public string AspNetInfo { get; set; }


    [DisplayName("Full trust level")]
    public string IsFullTrust { get; set; }


    [DisplayName("Server tijd zone")]
    public string ServerTimeZone { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [DisplayName("Server locale tijd")]
    public DateTime ServerLocalTime { get; set; }

    [DisplayName("GMT/UTC")]
    public DateTime UtcTime { get; set; }


    [DisplayName("HTTP_HOST")]
    public string HttpHost { get; set; }

    public string Dataprovider => "SQL Server";

    public long DatabaseSize { get; set; }

    [DisplayName("Database grootte")]
    public string DatabaseSizeString => DatabaseSize == 0 ? "" : StringExtensions.BytesToString(DatabaseSize);


    public long UsedMemorySize { get; set; }


    [DisplayName("Gebruikte geheugen")]
    public string UsedMemorySizeString => StringExtensions.BytesToString(UsedMemorySize);



    [DisplayName("Geladen assemblies")]
    public IList<LoadedAssembly> LoadedAssemblies { get; set; } = new List<LoadedAssembly>();






    public bool ShrinkDatabaseEnabled { get; set; }

    public IDictionary<string, long> MemoryCacheStats { get; set; }

    public class LoadedAssembly : ModelBase
    {
        public string FullName { get; set; }
        public string Location { get; set; }
    }

}