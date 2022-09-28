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

        // GET: Zones
        public async Task<IActionResult> Index()
        {
            return View(_zoneRepository.GetZones());
        }

        // GET: Zones/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);


            return View(zone);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {
            return View(new Zone());
        }

        // POST: Zones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            try
            {
                zone.ZoneId = Guid.NewGuid();
                _zoneRepository.InsertZone(zone);
                _zoneRepository.Save();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "");
            }
            return View(zone);
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Zone zone = _zoneRepository.GetZoneById(id);

            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            try
            {
                _zoneRepository.UpdateZone(zone);
                _zoneRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "");

            }
            return View(zone);

        }

            // GET: Zones/Delete/5
            public async Task<IActionResult> Delete(int id, bool? saveChangesError)
            {
                if (saveChangesError.GetValueOrDefault())
                {
                    return NotFound();
                }

                Zone zone = _zoneRepository.GetZoneById(id);
                return View(zone);
            }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Zone zone = _zoneRepository.GetZoneById(id);
                _zoneRepository.DeleteZone(id);
                _zoneRepository.Save();


            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound(id);
            }
            return RedirectToAction(nameof(Index));
        }


        private bool ZoneExists(Guid id, Zone zone)
            {
                return _zoneRepository.GetZones().Any(e => e.ZoneId == id);
            }
        }

}
