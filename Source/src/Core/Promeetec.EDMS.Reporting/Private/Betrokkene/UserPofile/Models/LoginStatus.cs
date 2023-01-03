namespace Promeetec.EDMS.Reporting.Private.Betrokkene.User.Models;

public enum LoginStatus
{
    Success = 0,
    LockedOut = 1,
    RequiresVerification = 2,
    Failure = 3,
    EmailVerification = 4,
    PhoneVerification = 5,
    RequiresAccountActivation = 6,
    EmailUnconfirmed = 7,
    PhoneNumberUnconfirmed = 8,
    InvalidToken = 9
}