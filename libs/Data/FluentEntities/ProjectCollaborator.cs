﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class ProjectCollaborator
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? PartnerId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    public virtual ResPartner? Partner { get; set; }

    public virtual ProjectProject? Project { get; set; }

    public virtual ResUser? WriteU { get; set; }
}
