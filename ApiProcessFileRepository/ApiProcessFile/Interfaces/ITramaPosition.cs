using ApiProcessFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessFile.Interfaces
{
    public interface ITramaPosition
    {
        public Task<List<TramaPosition>> GetTramaPosition();
    }
}
