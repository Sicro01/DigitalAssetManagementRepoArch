using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
    }
}
