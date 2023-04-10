﻿using System;
using System.Collections.Generic;

namespace Bamboo.Core.Entities;

public partial class NoteStage
{
    public long Id { get; set; }

    public long Sequence { get; set; }

    public Guid? UserId { get; set; }

    public Guid? CreatorId { get; set; }

    public Guid? LastModifierId { get; set; }

    public string? Name { get; set; }

    public bool? Fold { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public virtual ResUser? CreateU { get; set; }

    public virtual ResUser? User { get; set; }

    public virtual ResUser? WriteU { get; set; }

    //public virtual ICollection<NoteNote> Notes { get; } = new List<NoteNote>();
}
