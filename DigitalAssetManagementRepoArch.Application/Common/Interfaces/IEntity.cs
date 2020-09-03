using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
