﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Entities;

[Table("stock_assign_serial")]
public partial class StockAssignSerial
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("next_serial_count")]
    public long? NextSerialCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("next_serial_number")]
    public string? NextSerialNumber { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("serial_numbers")]
    public string? SerialNumbers { get; set; }

    [Column("multiple_lot_components_names")]
    public string? MultipleLotComponentsNames { get; set; }

    [Column("expected_qty")]
    public decimal? ExpectedQty { get; set; }

    [Column("produced_qty")]
    public decimal? ProducedQty { get; set; }

    [Column("show_apply")]
    public bool? ShowApply { get; set; }

    [Column("show_backorders")]
    public bool? ShowBackorders { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("StockAssignSerialCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MoveId")]
    [InverseProperty("StockAssignSerials")]
    public virtual StockMove? Move { get; set; }

    [ForeignKey("ProductionId")]
    [InverseProperty("StockAssignSerials")]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("StockAssignSerialWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
