using Knorish.Dto;
using Knorish.Infrastructure;
using Knorish.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knorish.Service
{
   public class KnorishService: IKnorishService
    {
        private readonly DataContext _dataContext;
        public KnorishService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<CommonDto> RegisterBoat(Boat obj)
        {
            CommonDto commonDto = new CommonDto();
            try
            {
                await _dataContext.Boats.AddAsync(obj);
                await _dataContext.SaveChangesAsync();
                
                commonDto.IsSuccess = true;
                commonDto.Message = "Added Successfully Boat ID is "+obj.ID;
                
            }
            catch (Exception ex)
            {
                commonDto.IsSuccess = false;
                commonDto.Message = ex.ToString();
            }
            return commonDto;

        }

        public async Task<IList<Boat>> GetBoatList()
        {
            var v= await _dataContext.Boats.ToListAsync();
            return v;
        }
    }
}
