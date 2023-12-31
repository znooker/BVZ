﻿using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class TourRepository : BaseRepository, ITourRepository
    {
        private readonly ZooDbContext _context;
        public TourRepository(ZooDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddZooTour(ZooTour zootour)
        {
            _context.Add(zootour);
            return await Save();
        }

        public async Task<List<Tour>> GetAllTours()
        {
            return await _context.Tours
                .Where(t => t.IsArchived == false || t.IsArchived == null)
                .Include(t => t.Guide)
                .Include(tp => tp.TourParticipants)
                .ToListAsync();
        }

        public async Task<List<ZooTour>> GetZooToursByDate(DateTime day)
        {
            return await _context.ZooTours
                        .Include(z => z.Tour)
                            .ThenInclude(t => t.Guide)
                        .Where(z => z.DateOfTour.Date == day.Date 
                        && (z.Tour.IsArchived == false || z.Tour.IsArchived == null)
                        && (z.Tour.Guide.IsArchived == false)
                        && z.NrOfParticipants < 5)
                        .ToListAsync();
        }

        public async Task<ZooTour> GetZooTourById(Guid id)
        {
            return await _context.ZooTours
                            .Include(z => z.Tour)
                               .ThenInclude(t => t.Guide)
                            .Include(z => z.ZooDay)
                            .Where(zt => zt.Id == id).SingleOrDefaultAsync();   
        }

        public async Task<bool> UpdateZooTour(ZooTour zootour)
        {
            _context.ZooTours.Update(zootour);
            return await Save();
        }

        public Task<bool> CreateTour(Tour zootour)
        {
            _context.Tours.Add(zootour);
            return Save();
        }

        public async Task<List<Tour>> GetToursAvailableToday(DateTime date)
        {
            return await _context.Tours
                             .Include(t => t.Guide)
                             .Include(t => t.ZooTours)
                             .Where(t => t.ZooTours.Count(zt => zt.DateOfTour.Date == date.Date) <= 1)
                             .ToListAsync();
        }

        public async Task<ZooTour> GetBookingOptionsForTour(Guid id, DateTime date)
        {
            try
            {
                return await _context.ZooTours
                           .Where(zt => zt.DateOfTour.Date == date.Date
                            &&
                           zt.TourID == id)
                           .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Db-operation failed for fetching zootour-info for schedeuling.");
            }
        }

        public async Task<Tour> GetTourById(Guid id)
        {
            return await _context.Tours
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateTour(Tour tour)
        {
            _context.Tours.Update(tour);
            return await Save();
        }
    }
}
