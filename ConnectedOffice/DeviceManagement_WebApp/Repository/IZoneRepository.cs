using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZoneRepository : IDisposable
    {
        IEnumerable<Zone> GetZones();
        Zone GetZoneById(Guid ZoneId);
        void InsertZone(Zone zone);
        void DeleteZone(Guid ZoneId);
        void UpdateZone(Zone zone);
        void Save();
    }
}
