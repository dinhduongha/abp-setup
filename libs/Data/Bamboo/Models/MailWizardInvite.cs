﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class MailWizardInvite
{
    public Guid Id { get; set; }

    public Guid? ResId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? ResModel { get; set; }

    public string? Message { get; set; }

    public bool? SendMail { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    public virtual ResUser? WriteU { get; set; }

    //public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
