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

[Table("fleet_vehicle_log_contract")]
[Index("UserId", Name = "fleet_vehicle_log_contract_user_id_index")]
public partial class FleetVehicleLogContract: IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("cost_subtype_id")]
    public long? CostSubtypeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("insurer_id")]
    public Guid? InsurerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ins_ref")]
    public string? InsRef { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("cost_frequency")]
    public string? CostFrequency { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("expiration_date")]
    public DateOnly? ExpirationDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("cost_generated")]
    public decimal? CostGenerated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("FleetVehicleLogContracts")]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CostSubtypeId")]
    [InverseProperty("FleetVehicleLogContractsNavigation")]
    public virtual FleetServiceType? CostSubtype { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("FleetVehicleLogContractCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InsurerId")]
    [InverseProperty("FleetVehicleLogContracts")]
    public virtual ResPartner? Insurer { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    [InverseProperty("FleetVehicleLogContracts")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("FleetVehicleLogContractUsers")]
    public virtual ResUser? User { get; set; }

    [ForeignKey("VehicleId")]
    [InverseProperty("FleetVehicleLogContracts")]
    public virtual FleetVehicle? Vehicle { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("FleetVehicleLogContractWriteUs")]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("FleetVehicleLogContractId")]
    [InverseProperty("FleetVehicleLogContracts")]
    public virtual ICollection<FleetServiceType> FleetServiceTypes { get; } = new List<FleetServiceType>();
}
