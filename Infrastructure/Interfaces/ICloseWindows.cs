using System;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
