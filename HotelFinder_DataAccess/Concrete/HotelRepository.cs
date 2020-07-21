﻿using HotelFinder.Entities;
using HotelFinder_DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder_DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using(var hotelDbContext=new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public  async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
               var deletedHotel=  hotelDbContext.Hotels.Find(id);
                hotelDbContext.Remove(deletedHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task< List<Hotel>> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
               return await hotelDbContext.Hotels.ToListAsync();
                
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FindAsync(id);

            }
        }

        public async Task< Hotel> GetHotelByName(string name)
        {
            using(var hotelDbContext=new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using(var hotelDbContext=new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
                
            }
        }
    }
}
