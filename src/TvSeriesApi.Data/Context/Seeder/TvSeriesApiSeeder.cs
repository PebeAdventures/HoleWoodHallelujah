using Microsoft.EntityFrameworkCore;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.Context.Seeder
{
    public static class TvSeriesApiSeeder
    {

        public static void SeedDatabase(this ModelBuilder builder)
        {
            var actorList = new List<Actor>();
            var genreList = new List<Genre>();
            //  var seasonlist = new List<Season>();
            //  var episodeList = new List<Episode>();
            var tvSeries = new List<TVSeries>();

            //Genres
            var dramaGenre = new Genre { Name = "Drama", GenreId = 1 };
            var trillingGenre = new Genre { Name = "Trilling", GenreId = 2 };
            var actiongenre = new Genre { Name = "Action", GenreId = 3 };
            var scienceFictionGenre = new Genre { Name = "Science Fiction", GenreId = 4 };
            var comedyGenre = new Genre { Name = "Comedy", GenreId = 5 };
            var crimeFiction = new Genre { Name = "Crime Fiction", GenreId = 6 };
            genreList.Add(dramaGenre);
            genreList.Add(trillingGenre);
            genreList.Add(actiongenre);
            genreList.Add(scienceFictionGenre);
            genreList.Add(comedyGenre);
            genreList.Add(crimeFiction);

            //Actors
            //gambit krolowej
            var anyaTaylor = new Actor() { Fullname = "Anya Taylor", Age = 25, TVSeries = new List<TVSeries>(), ActorId = 1 };
            var thomasBrodie = new Actor() { Fullname = "Thomas Brodie", Age = 15, TVSeries = new List<TVSeries>(), ActorId = 2 };
            var mosesIngram = new Actor() { Fullname = "Moses Ingram", Age = 20, TVSeries = new List<TVSeries>(), ActorId = 3 };
            //breaking bad
            var bryanCranston = new Actor() { Fullname = "Bryan Cranston", Age = 30, TVSeries = new List<TVSeries>(), ActorId = 4 };
            var aaronPaul = new Actor() { Fullname = "Aaron Paul", Age = 32, TVSeries = new List<TVSeries>(), ActorId = 5 };
            var annaGunn = new Actor() { Fullname = "Anna Gunn", Age = 22, TVSeries = new List<TVSeries>(), ActorId = 6 };
            //the boys
            var antonyStarr = new Actor() { Fullname = "Antony Starr", Age = 35, TVSeries = new List<TVSeries>(), ActorId = 7 };
            var karlUrban = new Actor() { Fullname = "Karl Urban", Age = 32, TVSeries = new List<TVSeries>(), ActorId = 8 };
            var jackQuaid = new Actor() { Fullname = "Jack Quaid", Age = 21, TVSeries = new List<TVSeries>(), ActorId = 9 };
            //stranger thinks
            var millieBrown = new Actor() { Fullname = "Millie Bobby Brown", Age = 14, TVSeries = new List<TVSeries>(), ActorId = 10 };
            var finnWolfhard = new Actor() { Fullname = "Finn Wolfhard", Age = 15, TVSeries = new List<TVSeries>(), ActorId = 11 };
            var noahSchnapp = new Actor() { Fullname = "Noah Schnapp", Age = 17, TVSeries = new List<TVSeries>(), ActorId = 12 };
            //Branczo
            var panSzafka = new Actor() { Fullname = "Yellow Magnetic Star", Age = 66, TVSeries = new List<TVSeries>(), ActorId = 13 };
            var ilonaOstrowska = new Actor() { Fullname = "Ilona Ostrowska", Age = 30, TVSeries = new List<TVSeries>(), ActorId = 14 };
            var cezaryZak = new Actor() { Fullname = "Cezary Żak", Age = 45, TVSeries = new List<TVSeries>(), ActorId = 15 };
            var violettaArlak = new Actor() { Fullname = "Violetta Arlak", Age = 55, TVSeries = new List<TVSeries>(), ActorId = 16 };
            //Rick Morty
            var justinRoiland = new Actor() { Fullname = "Justin Roiland", Age = 31, TVSeries = new List<TVSeries>(), ActorId = 17 };
            var chrisParnell = new Actor() { Fullname = "Chris Parnell", Age = 40, TVSeries = new List<TVSeries>(), ActorId = 18 };
            var tomKenny = new Actor() { Fullname = "Tom Kenny", Age = 61, TVSeries = new List<TVSeries>(), ActorId = 19 };

            actorList.Add(bryanCranston);
            actorList.Add(aaronPaul);
            actorList.Add(annaGunn);
            actorList.Add(antonyStarr);
            actorList.Add(karlUrban);
            actorList.Add(jackQuaid);
            actorList.Add(millieBrown);
            actorList.Add(finnWolfhard);
            actorList.Add(noahSchnapp);
            actorList.Add(ilonaOstrowska);
            actorList.Add(cezaryZak);
            actorList.Add(violettaArlak);
            actorList.Add(panSzafka);
            actorList.Add(chrisParnell);
            actorList.Add(tomKenny);
            actorList.Add(justinRoiland);
            //Tv Series

            // tvSeries.Add(new TVSeries { })
            List<Actor> gambitActorList = new List<Actor>();
            List<Season> gambitSeasons = new List<Season>();
            List<Episode> gambitEpisodes = new List<Episode>();
            var gambitTvSeries = new TVSeries() { Cast = gambitActorList, Genre = dramaGenre, Name = "Queen Gambit", Year = 2020, Seasons = gambitSeasons, TVSeriesId = 1 };
            var gambitSeason = new Season() { Name = "Season 1", Episodes = gambitEpisodes, TVSeries = gambitTvSeries, SeasonId = 1 };
            gambitSeasons.Add(gambitSeason);
            gambitEpisodes.Add(new Episode() { Name = "Opening", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "Exchanges", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "Doubled Pawns", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "Middle Game", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "Fork", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "Adjounment", Season = gambitSeason });
            gambitEpisodes.Add(new Episode() { Name = "End", Season = gambitSeason });

            gambitActorList.Add(anyaTaylor);
            gambitActorList.Add(thomasBrodie);
            gambitActorList.Add(mosesIngram);
            tvSeries.Add(gambitTvSeries);
            builder.Entity<TVSeries>().HasData(tvSeries);
            //   seasonlist.Add(new Season { Episodes=new Episode { Season} })
        }
    }
}
