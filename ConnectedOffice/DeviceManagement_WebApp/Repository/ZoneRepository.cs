using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;
namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(Zone => Zone.DateCreated).FirstOrDefault();
        }
    }
}
