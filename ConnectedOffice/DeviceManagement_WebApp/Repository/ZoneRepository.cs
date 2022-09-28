using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        private readonly ConnectedOfficeContext _context;

        public ZoneRepository(ConnectedOfficeContext context) 
        {
            _context = context;
        }

        public IEnumerable<Zone> GetZones()
        {
            return _context.Zone.ToList();
        }

        public Zone GetZoneById(int id)
        {
            return _context.Zone.Find(id);
        }

        public void InsertZone(Zone zone)
        {
            _context.Zone.Add(zone);
        }

        public void DeleteZone(int zoneId)
        {
            Zone zone = _context.Zone.Find(zoneId);
            _context.Zone.Remove(zone);
        }

        public void UpdateZone(Zone zone)
        {
            _context.Entry(zone).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

    
