﻿using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>,IDeviceRepository
    {    
        private readonly ConnectedOfficeContext _context;
    
        public DeviceRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        public IEnumerable<Device> GetDevices()
        {
            return _context.Device.ToList();
        }

        public Device GetDeviceId(int id)
        {
            return _context.Device.Find(id);
        }

        public void InsertDevice(Device device)
        {
            _context.Device.Add(device);
        }

        public void DeleteDevice(int deviceId)
        {
            Device device = _context.Device.Find(deviceId);
            _context.Device.Remove(device);
        }

        public void UpdateDevice(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
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

        public Device GetDeviceById(int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
