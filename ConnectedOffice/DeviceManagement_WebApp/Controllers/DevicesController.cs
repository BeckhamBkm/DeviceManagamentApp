using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository DeviceRepository)
        {
            _deviceRepository = DeviceRepository;
        }

       // GET: Device
        public IActionResult Index()
        {
            IEnumerable<Device> devices = _deviceRepository.GetDevices();
            return View(devices);
        }

        // GET: Device/Details/5
        public IActionResult Details(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Device device)
        {
            if (ModelState.IsValid)
            {
                _deviceRepository.InsertDevice(device);
                _deviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

       // GET: Device/Edit/5
        public IActionResult Edit(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _deviceRepository.UpdateDevice(device);
                _deviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }


       // GET: Device/Delete/5
        public IActionResult Delete(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            if (device != null)
            {
                _deviceRepository.DeleteDevice(id);
                _deviceRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(Device device, Guid id)
        {
            return _deviceRepository.GetDevices().Any(x => x.CategoryId == id);
        }
    }
}
