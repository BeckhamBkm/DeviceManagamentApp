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
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zoneRepository;

        public ZonesController(IZoneRepository ZoneRepository)
        {
            _zoneRepository = ZoneRepository;
        }

       // GET: Zone
        public IActionResult Index()
        {
            IEnumerable<Zone> zones = _zoneRepository.GetZones();
            return View(zones);
        }

        // GET: Zones/Details/5
        public async Task<IActionResult> Details(Guid guid)
        {
            Zone zone = _zoneRepository.GetZoneById(guid);
            return View(zone);
        }

       // GET: Zone/Details/5
        public IActionResult Details(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

        // GET: Zone/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zone/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zone zone)
        {
            if (ModelState.IsValid)
            {
                _zoneRepository.InsertZone(zone);
                _zoneRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(zone);
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(Guid ZoneId)
        {
            Zone zone = _zoneRepository.GetZoneById(ZoneId);

            return View(zone);
        }

       // GET: Zone/Edit/5
        public IActionResult Edit(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

            // GET: Zones/Delete/5
            public async Task<IActionResult> Delete(Guid ZoneId, bool? saveChangesError)
            {
                if (saveChangesError.GetValueOrDefault())
                {
                    return NotFound();
                }

                Zone zone = _zoneRepository.GetZoneById(ZoneId);
                return View(zone);
            }

            // POST: Zone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _zoneRepository.UpdateZone(zone);
                _zoneRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(zone);
        }

        // GET: Zone/Delete/5
        public IActionResult Delete(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

       // POST: Zone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);
            if (zone != null)
            {
                _zoneRepository.DeleteZone(id);
                _zoneRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneExists(Guid ZoneId, Zone zone)
            {
                return _zoneRepository.GetZones().Any(e => e.ZoneId == ZoneId);
            }
        }

}
