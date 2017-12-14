using System;

namespace Pdc.System.Data.State
{
    [Flags]
    public enum EProcessing
    {
        New = 0,
        Invalid = 1,
        Seen = 2,
        //Frei      = 4,
        Ok = 8,
        Imported = 16,
        Exported = 32,
        Transmitted = 64
    }
}