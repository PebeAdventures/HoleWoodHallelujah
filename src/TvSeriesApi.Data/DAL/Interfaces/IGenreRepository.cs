﻿using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre> GetGenreByIdAsync(int id);
    }
}