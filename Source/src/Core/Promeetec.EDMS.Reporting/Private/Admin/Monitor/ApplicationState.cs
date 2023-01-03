using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using Promeetec.EDMS.Domain.Extensions;

namespace Promeetec.EDMS.Reporting.Private.Admin.Monitor;

public class ApplicationState
{
    private const string CookieKey = "__PROMEETEC";
    private const string CookieValueKey = "MachineID";
    private const string SessionStateKey = "__SESSIONSTATE";
    private static readonly Dictionary<string, SessionInformation> Sessions = new();

    public static SessionInformation GetSession(string key)
    {
        return Sessions.ContainsKey(key) ? Sessions[key] : null;
    }



    public static int OnlineUsers()
    {
        return Sessions.Values.OrderByDescending(s => s.LastActivity).ToList().Count;
    }

    public static List<SessionInformation> GetSessions()
    {
        return Sessions.Values.OrderByDescending(s => s.LastActivity).ToList();
    }

    public static void AbandonSession(HttpSessionState session)
    {
        if (session != null)
        {
            string key = session.SessionID;
            if (Sessions.ContainsKey(key))
                Sessions.Remove(key);
            session.Abandon();
        }
    }

    private static TimeSpan GetSessionTimeout()
    {
        var sessionState = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
        return sessionState.Timeout;
    }

    public static SessionInformation CreateOrUpdateSession(HttpContext current)
    {
        var sessionInfo = GetSession(current.Session.SessionID);
        try
        {
            // first, check if already in singleton dictionary
            if (sessionInfo == null)
            {
                // check if already in session
                if (current.Session[SessionStateKey] != null)
                {
                    sessionInfo = (SessionInformation)current.Session[SessionStateKey];
                }
                else
                {
                    // check persistent cookie for device identification
                    string machineId;
                    var cookie = current.Request.Cookies[CookieKey];
                    if (!string.IsNullOrEmpty(cookie?.Values[CookieValueKey]))
                    {
                        machineId = cookie.Values[CookieValueKey];
                    }
                    else
                    {
                        machineId = Guid.NewGuid().ToString();

                        // add new machine ID to response
                        var responseCookie = new HttpCookie(CookieKey);
                        responseCookie.Values.Add(CookieValueKey, machineId);
                        responseCookie.Expires = DateTime.Now.AddMinutes(GetSessionTimeout().TotalMinutes);
                        responseCookie.Secure = true;
                        responseCookie.HttpOnly = true;
                        responseCookie.SameSite = SameSiteMode.Strict;
                        current.Response.Cookies.Add(responseCookie);
                    }

                    sessionInfo = new SessionInformation
                    {
                        Connected = true,
                        CreatedOn = DateTime.Now,
                        UserHostAddress = current.Request.UserHostAddress,
                        ForwardedFor = current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"],
                        LastActivity = DateTime.Now,
                        Locked = false,
                        SessionId = current.Session.SessionID,
                        MachineId = machineId,
                        UserAgent = current.Request.UserAgent,
                    };
                }

                Sessions.Add(sessionInfo.SessionId, sessionInfo);
            }

            // remove any other sessions for this device; these have been abandoned
            var result = Sessions.Values.Where(asi => asi.MachineId == sessionInfo.MachineId && asi.SessionId != sessionInfo.SessionId).ToList();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Sessions.Remove(item.SessionId);
                }
            }


            // update information
            sessionInfo.LastActivity = DateTime.Now;

            if (sessionInfo.UserId == Guid.Empty)
                sessionInfo.UserId = current.User.Identity.GetUserId();

            sessionInfo.UserName = !string.IsNullOrEmpty(current.User.Identity.Name) ? current.User.Identity.Name : current.User.Identity.GetVolledigeNaam();

            // store updated instance in session
            current.Session[SessionStateKey] = sessionInfo;
            return sessionInfo;
        }
        catch (Exception)
        {
            return sessionInfo;
        }
    }
}