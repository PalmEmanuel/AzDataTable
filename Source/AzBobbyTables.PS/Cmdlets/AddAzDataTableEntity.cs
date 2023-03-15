﻿using PipeHow.AzBobbyTables.Validation;
using System.Collections;
using System.Management.Automation;

namespace PipeHow.AzBobbyTables.Cmdlets;

/// <summary>
/// <para type="synopsis">Add one or more entities to an Azure Table.</para>
/// </summary>
[Cmdlet(VerbsCommon.Add, "AzDataTableEntity", DefaultParameterSetName = "TableOperation")]
public class AddAzDataTableEntity : AzDataTableOperationCommand
{
    /// <summary>
    /// <para type="description">The entities to add to the table.</para>
    /// </summary>
    [Parameter(Mandatory = true, ParameterSetName = "TableOperation", ValueFromPipeline = true)]
    [ValidateEntity]
    public Hashtable[] Entity { get; set; }

    /// <summary>
    /// <para type="description">Overwrites provided entities if they exist.</para>
    /// </summary>
    [Parameter(ParameterSetName = "TableOperation")]
    public SwitchParameter Force { get; set; }

    /// <summary>
    /// The process step of the pipeline.
    /// </summary>
    protected override void ProcessRecord() => tableService.AddEntitiesToTable(Entity, Force.IsPresent);
}
