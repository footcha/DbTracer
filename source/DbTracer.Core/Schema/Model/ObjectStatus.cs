using System;

namespace DbTracer.MsSql
{
    /// <summary>
    /// OriginalStatus = El objeto no sufrio modificaciones.
    /// CreateStatus = El objeto se debe crear.
    /// DropStatus = El objeto se debe eliminar.
    /// AlterStatus = El objeto sufrio modificaciones.
    /// AlterRebuildStatus = El objeto sufrio modificaciones, pero se debe hacer un DROP y ADD.
    /// AlterPropertiesStatus = El objeto sufrio modificaciones en sus propiedades, pero no en su estructura.
    /// </summary>
    [Flags]
    public enum ObjectStatus
    {
        OriginalStatus = 0,
        AlterStatus = 2,
        AlterBodyStatus = 4,
        RebuildStatus = 8,
        RebuildDependenciesStatus = 16,
        UpdateStatus = 32,
        CreateStatus = 64,
        DropStatus = 128,
        DisabledStatus = 256,
        ChangeOwner = 512,
        DropOlderStatus = 1024,
        BindStatus = 2048,
        PermisionSet = 4096
    }
}