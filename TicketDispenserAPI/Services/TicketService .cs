using TicketDispenserAPI.Repositories;

namespace TicketDispenserAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketNumberRepository _ticketNumberRepository;
        private readonly HashSet<int> _issuedTickets;


        public TicketService(ITicketNumberRepository ticketNumberRepository)
        {
            _ticketNumberRepository = ticketNumberRepository;
            _issuedTickets = new HashSet<int>();
        }

        public int GetTicketNumber()
        {
            int ticketNumber = _ticketNumberRepository.GetNextTicketNumber();

            lock (_issuedTickets)
            {
                if (_issuedTickets.Contains(ticketNumber))
                {
                    string errorMessage = "Duplicate ticket number.";
                    throw new InvalidOperationException(errorMessage);
                }

                _issuedTickets.Add(ticketNumber);
            }

            return ticketNumber;
        }
    }
}