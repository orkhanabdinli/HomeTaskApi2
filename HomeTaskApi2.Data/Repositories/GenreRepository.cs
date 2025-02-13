﻿using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Core.Repositories;
using HomeTaskApi2.Data.Contexts;

namespace HomeTaskApi2.Data.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(HomeTaskApi2DbContext context) : base(context)
    {
    }
}
