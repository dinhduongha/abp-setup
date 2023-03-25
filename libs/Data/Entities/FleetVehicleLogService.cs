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

[Table("fleet_vehicle_log_services")]
public partial class FleetVehicleLogService: IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("vehicle_id")]
    public Guid VehicleId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("odometer_id")]
    public Guid? OdometerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("purchaser_id")]
    public Guid? PurchaserId { get; set; }

    [Column("vendor_id")]
    public Guid? VendorId { get; set; }

    [Column("service_type_id")]
    public long ServiceTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("inv_ref")]
    public string? InvRef { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("purchaser_employee_id")]
    public Guid? PurchaserEmployeeId { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("FleetVehicleLogServiceCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ManagerId")]
    [InverseProperty("FleetVehicleLogServiceManagers")]
    public virtual ResUser? Manager { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("OdometerId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual FleetVehicleOdometer? Odometer { get; set; }

    [ForeignKey("PurchaserId")]
    [InverseProperty("FleetVehicleLogServicePurchasers")]
    public virtual ResPartner? Purchaser { get; set; }

    [ForeignKey("PurchaserEmployeeId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual HrEmployee? PurchaserEmployee { get; set; }

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual FleetServiceType ServiceType { get; set; } = null!;

    [ForeignKey("VehicleId")]
    [InverseProperty("FleetVehicleLogServices")]
    public virtual FleetVehicle Vehicle { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("FleetVehicleLogServiceVendors")]
    public virtual ResPartner? Vendor { get; set; }

    [ForeignKey("LastModifierId")]
    [InverseProperty("FleetVehicleLogServiceWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
