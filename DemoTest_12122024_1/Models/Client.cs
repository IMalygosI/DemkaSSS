using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientFirstName { get; set; } = null!;

    public string ClientLastName { get; set; } = null!;

    public string? ClientPatronymic { get; set; }

    public DateOnly? ClientBirthDay { get; set; }

    public DateOnly ClientRegistrationDate { get; set; }

    public string? ClientEmail { get; set; }

    public string ClientPhone { get; set; } = null!;

    public int ClientGenderCode { get; set; }

    public string? ClientPhotoPath { get; set; }

    public virtual Gender ClientGenderCodeNavigation { get; set; } = null!;

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

    public virtual TagOfClient? TagOfClient { get; set; }
}
