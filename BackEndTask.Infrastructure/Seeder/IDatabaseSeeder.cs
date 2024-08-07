using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Infrastructure.Seeder
{
    public interface IDatabaseSeeder
    {
        Task Seed();
    }
}