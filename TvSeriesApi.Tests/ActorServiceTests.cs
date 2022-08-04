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
        //private readonly ActorService _serviceTested; 
        //private readonly Mock<IUnitOfWork> _actorUnitOfWorkMock = new();
        //private readonly Mock<IMapper> _mapperMock = new();

        //public ActorServiceTests()
        //{
        //    _serviceTested = new ActorService(_actorUnitOfWorkMock.Object, _mapperMock.Object);
        //}

        //[Test]
        //public async Task GetActorByIdAsync_ShouldReturnActor_WhenActorExist()
        //{
        //    // Arrange
        //    var actorId = 1;
        //    var actorName = "Aaron Paul";
        //    var actorAge = 50;
        //    List<string> tvSeriesNames = new() { "Breaking Bad" };

        //    var actorReadDto = new ActorReadDTO
        //    {
        //        ActorId = actorId,
        //        Age = actorAge,
        //        Fullname = actorName,
        //        TVSeries = tvSeriesNames
        //    };

        //    var actor = new Actor
        //    {

        //    };
        //    _actorUnitOfWorkMock.Setup(x => x.Actors.GetActorByIdAsync(actorId))
        //        .Returns(actorReadDto);
        //    // Act
        //    var actor = await _serviceTested.GetActorByIdAsync(actorId);

        //    // Assert
        //    Assert.Equals(actor.ActorId, actorId);

        //}
    }
}
