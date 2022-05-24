﻿using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class GoogleAuthenticatorGeactiveerd : EventBase
{
    public string GoogleAuthenticatorAan { get; set; }
    public string AccountStatus { get; set; }
    public string GoogleAuthenticatorSecretKey { get; set; }

}