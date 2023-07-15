using Moq;
using TicketDispenserAPI.Repositories;
using TicketDispenserAPI.Services;
using Xunit;

namespace TicketDispenserAPI.Tests
{
    public class TicketServiceTests
    {
        private Mock<ITicketNumberRepository> _mockTicketNumberRepository;
        private TicketService _ticketService;

        public TicketServiceTests()
        {
            _mockTicketNumberRepository = new Mock<ITicketNumberRepository>();
            _ticketService = new TicketService(_mockTicketNumberRepository.Object);
        }

        [Fact]
        public void GetTicketNumber_ReturnsUniqueNumber()
        {
            // mock setup
            _mockTicketNumberRepository.Setup(r => r.GetNextTicketNumber()).Returns(1);

            // execute method to test
            int ticketNumber = _ticketService.GetTicketNumber();

            // assert results
            Assert.Equal(1, ticketNumber);
        }

        [Fact]
        public void GetTicketNumber_ThrowsExceptionForDuplicateTicketNumber()
        {
            // mock setup
            _mockTicketNumberRepository.Setup(r => r.GetNextTicketNumber()).Returns(1);

            // execute method to test
            _ticketService.GetTicketNumber();

            // assert results
            Assert.Throws<InvalidOperationException>(() => _ticketService.GetTicketNumber());
        }
        
    }
}