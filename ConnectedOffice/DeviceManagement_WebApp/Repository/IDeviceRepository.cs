using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IDisposable
    {
        IEnumerable<Device> GetDevices();
        Device GetDeviceById(Guid DeviceId);
        void InsertDevice(Device device);
        void DeleteDevice(Guid DeviceId);
        void UpdateDevice(Device device);
        void Save();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
