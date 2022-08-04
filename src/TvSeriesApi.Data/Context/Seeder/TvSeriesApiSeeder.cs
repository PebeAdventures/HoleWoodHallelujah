namespace TvSeriesApi.Data.Context.Seeder
{
    public static class TvSeriesApiSeeder
    {

        public static void SeedDatabase(this ModelBuilder builder)
        {
            //@GENRE
            var genreList = new List<Genre>();
            var dramaGenre = new Genre { GenreId = 1, Name = "Drama", TVSeries = new List<TVSeries>() };
            var trillingGenre = new Genre { Name = "Trilling", GenreId = 2, TVSeries = new List<TVSeries>() };
            var actiongenre = new Genre { Name = "Action", GenreId = 3, TVSeries = new List<TVSeries>() };
            var scienceFictionGenre = new Genre { Name = "Science Fiction", GenreId = 4, TVSeries = new List<TVSeries>() };
            var comedyGenre = new Genre { Name = "Comedy", GenreId = 5 };
            var crimeFiction = new Genre { Name = "Crime Fiction", GenreId = 6, TVSeries = new List<TVSeries>() };
            genreList.Add(dramaGenre);
            genreList.Add(trillingGenre);
            genreList.Add(actiongenre);
            genreList.Add(scienceFictionGenre);
            genreList.Add(comedyGenre);
            genreList.Add(crimeFiction);
            builder.Entity<Genre>().HasData(genreList);

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
            var actorList = new List<Actor>();
            actorList.Add(anyaTaylor);
            actorList.Add(thomasBrodie);
            actorList.Add(mosesIngram);
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
            builder.Entity<Actor>().HasData(actorList);

            //@TVSeries
            var tvSeriesList = new List<TVSeries>();
            tvSeriesList.Add(new TVSeries() { GenreId = 1, Name = "GambitSuko", Year = 2020, TVSeriesId = 1 });
            tvSeriesList.Add(new TVSeries() { GenreId = 2, Name = "Breaking Bad", Year = 2002, TVSeriesId = 2 });
            tvSeriesList.Add(new TVSeries() { GenreId = 3, Name = "Branczo", Year = 2022, TVSeriesId = 3 });
            builder.Entity<TVSeries>().HasData(tvSeriesList);

            // var actorTvSeries = new List<ActorTvSeries>
            //@SEASON
            List<Season> seasons = new List<Season>();

            var gambitSeason = new Season() { Name = "Season 1", SeasonId = 1, TVSeriesId = 1 };
            var breakingBads1 = new Season() { Name = "Season 1", SeasonId = 2, TVSeriesId = 2 };
            var breakingBads2 = new Season() { Name = "Season 2", SeasonId = 3, TVSeriesId = 2 };
            var branczoS1 = new Season() { Name = "Season 1", SeasonId = 4, TVSeriesId = 3 };
            seasons.Add(gambitSeason);
            seasons.Add(breakingBads1);
            seasons.Add(breakingBads2);
            seasons.Add(branczoS1);
            builder.Entity<Season>().HasData(seasons);

            //@EPISODES
            List<Episode> episodes = new List<Episode>();
            episodes.Add(new Episode() { Name = "Opening", SeasonId = 1, EpisodeId = 1 });
            episodes.Add(new Episode() { Name = "Exchanges", SeasonId = 1, EpisodeId = 2 });
            episodes.Add(new Episode() { Name = "Doubled Pawns", SeasonId = 1, EpisodeId = 3 });
            episodes.Add(new Episode() { Name = "Middle Game", SeasonId = 1, EpisodeId = 4 });
            episodes.Add(new Episode() { Name = "Fork", SeasonId = 1, EpisodeId = 5 });
            episodes.Add(new Episode() { Name = "Adjounment", SeasonId = 1, EpisodeId = 6 });
            episodes.Add(new Episode() { Name = "End", SeasonId = 1, EpisodeId = 7 });
            episodes.Add(new Episode() { Name = "breakings1", SeasonId = 2, EpisodeId = 8 });
            episodes.Add(new Episode() { Name = "breakings2", SeasonId = 3, EpisodeId = 9 });
            episodes.Add(new Episode() { Name = "branczoAndMateusz", SeasonId = 3, EpisodeId = 10 });

            builder.Entity<Episode>().HasData(episodes);

        }
    }
}
