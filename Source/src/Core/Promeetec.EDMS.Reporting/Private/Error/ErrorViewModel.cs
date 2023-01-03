using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Error;

public class ErrorViewModel : ModelBase
{
    public override bool ShowRightbar => false;
    public override bool ShowMenu => false;
    public override bool ShowBreadcrumb => false;
    public override bool ShowNavbar => false;
    public override bool ShowMainSidebar => false;

    public string Message { get; set; }

    public string ErrorMessage
    {
        get
        {
            if (ErrorInfo?.Exception != null)
                return $"{ErrorInfo.Exception}".Replace("\r\n", "<br/>");

            return null;
        }
    }

    public HandleErrorInfo ErrorInfo { get; set; }
}