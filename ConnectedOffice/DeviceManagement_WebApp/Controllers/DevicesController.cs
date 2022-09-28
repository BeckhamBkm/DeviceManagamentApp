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

        // GET: Devices
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(_deviceRepository.GetDevices());

        }

        public IActionResult Details(int id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            return View(device);
        }


        // GET: Devices/Create
        public IActionResult Create()
        {
            return View(new Category());
        }

        // POST: Devices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Device device)
        {
            try
            {
                device.DeviceId = Guid.NewGuid();
                _deviceRepository.InsertDevice(device);
                _deviceRepository.Save();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "");
            }
            return View(device);

        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
                Device device = _deviceRepository.GetDeviceById(id);
            return View(device);
        }
        // POST: Devices/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,DeviceId,DeviceName,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            try
            {
                _deviceRepository.UpdateDevice(device);
                _deviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "");

            }
            return View(device);



        }

        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                return NotFound();
            }

            Device device = _deviceRepository.GetDeviceById(id);
            return View(device);

        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Device device = _deviceRepository.GetDeviceById(id);
                _deviceRepository.DeleteDevice(id);
                _deviceRepository.Save();


            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToActionPermanent(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        private bool CategoryExists(Device device, Guid id)
        {
            return _deviceRepository.GetDevices().Any(x => x.CategoryId == id);
        }
    }
}
