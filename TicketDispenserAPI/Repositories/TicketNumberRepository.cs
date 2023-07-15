using TicketDispenserAPI.Repositories;

namespace TicketDispenserAPI.Providers
{
    public class TicketNumberRepository : ITicketNumberRepository
    {
        private int _lastTicketNumber = 0;

        public int GetNextTicketNumber()
        {
            return Interlocked.Increment(ref _lastTicketNumber);
        }
    }
}