﻿using TvSeriesApi.DTO.TvSeries;

namespace TvSeriesApi.DTO.Actor
{
    public class ActorWithTvSeriesDTO
    {
        public string Fullname { get; set; }
        public IEnumerable<TVSeriesReadDTO> tVSeriesReadDTOs { get; set; }
    }
}
