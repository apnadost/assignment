using Knorish.Dto;
using Knorish.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knorish.Service.Interfaces
{
    public interface IKnorishService
    {
        Task<CommonDto> RegisterBoat(Boat boat);
        Task<IList<Boat>> GetBoatList();
    }
}
