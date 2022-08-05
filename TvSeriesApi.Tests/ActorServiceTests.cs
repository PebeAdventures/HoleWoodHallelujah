using AutoMapper;
using Moq;
using TvSeriesApi.Data;
using TvSeriesApi.Data.Entities;
using TvSeriesApi.DTO.Actor;
using TvSeriesApi.Services;

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
            // Arrange
            var actorId = 1;
            var actorName = "Aaron Paul";
            var actorAge = 50;
            List<string> tvSeriesNames = new() {  "Breaking Bad" };

            var actorReadDto = new ActorReadDTO
            {
                Age = actorAge,
                Fullname = actorName,
                TVSeriesName = tvSeriesNames
            };

            //var actor = new Actor
            //{
            //    ActorId = actorId,
            //    Fullname = actorName,
            //    Age = actorAge,
            //    TVSeries = tvSeriesNames;
            //};

            var actorUnitOfWork = await _actorUnitOfWorkMock.Object.Actors.GetActorByIdAsync(actorId); //.Setup(x => x.Actors.GetActorByIdAsync(actorId));
            var mappedActor = _mapperMock.Object.Map<ActorReadDTO>(actorUnitOfWork);
            // Act
            var actor = await _serviceTested.GetActorByIdAsync(actorId);

            // Assert
            //Assert.Equals(actor.Fullname, mappedActor.Fullname);
            Assert.Equals(actorReadDto.Fullname, mappedActor.Fullname);

        }
    }
}
