

namespace TvSeriesApi.Tests
{
    public class ActorServiceTests
    {
        private readonly ActorService _serviceTested;
        private readonly Mock<IUnitOfWork> _actorUnitOfWorkMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public ActorServiceTests()
        {
            _serviceTested = new ActorService(_actorUnitOfWorkMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetActorByIdAsync_ShouldReturnActor_WhenActorExist()
        {
            var actorId = 1;
            var actorName = "Aaron Paul";
            var actorAge = 50;
            List<string> tvSeriesNames = new() {  "Breaking Bad" };

            var actor = new ActorReadDTO
            {
                Age = actorAge,
                Fullname = actorName,
                TVSeriesName = tvSeriesNames
            };

            var actorUnitOfWork = _actorUnitOfWorkMock.Setup(x => x.Actors.GetActorByIdAsync(actorId)); 
            var mappedActor = _mapperMock.Setup(x => x.Map<ActorReadDTO>(actorUnitOfWork));

            var actorService = _serviceTested.GetActorByIdAsync(actorId);
            
            Assert.That(actorId, Is.EqualTo(actorService.Id));
        }

        [Test]
        public async Task GetActorByIdAsync_ShouldReturnActorIsNotNull_WhenActorIsNotNull()
        {
            var actorId = 1;
            var actorName = "JeniferLopez";
            var actorAge = 60;
            List<string> tvSeriesNames = new() { "Jery Ho" };

            var actor = new ActorReadDTO
            {
                Age = actorAge,
                Fullname = actorName,
                TVSeriesName = tvSeriesNames
            };

            var actorUnitOfWork = _actorUnitOfWorkMock.Setup(x => x.Actors.GetActorByIdAsync(actorId));
            var mappedActor = _mapperMock.Setup(x => x.Map<ActorReadDTO>(actorUnitOfWork));

            var actorService = _serviceTested.GetActorByIdAsync(actorId);
            Assert.That(actorService, Is.Not.Null);
        }
    }
}
