using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder_DataAccess.Abstract
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> GetHotelByName(string name);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task<Hotel> CreateHotel(Hotel hotel);
        Task DeleteHotel(int id);
    }
}
