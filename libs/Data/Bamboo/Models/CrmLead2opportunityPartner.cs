﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class CrmLead2opportunityPartner
{
    public Guid Id { get; set; }

    public Guid? LeadId { get; set; }

    public Guid? PartnerId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? TeamId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public string? Action { get; set; }

    public bool? ForceAssignment { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    public virtual CrmLead? Lead { get; set; }

    public virtual ResPartner? Partner { get; set; }

    public virtual CrmTeam? Team { get; set; }

    public virtual ResUser? User { get; set; }

    public virtual ResUser? WriteU { get; set; }

    //public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();
}
