using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;
        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(string userId, EventViewModel model)
        {
            var @event = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                CreatedOn = DateTime.Now,
                OrganiserId = userId,
                TypeId = model.TypeId
            };

            await context.Events.AddAsync(@event);
            await context.SaveChangesAsync();
        }

        public async Task<DetailsViewModel> Details(int id)
        {
            return (await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new DetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync())!;
        }

        public async Task EditAsync(EventViewModel model, int id)
        {
            var @event = await context.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            @event!.Name = model.Name;
            @event.Description = model.Description;
            @event.Start = model.Start;
            @event.End = model.End;
            @event.TypeId = model.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task<ICollection<AllViewModel>> GetAllAsync()
        {
            return await context.Events
                .AsNoTracking()
                .Select(e => new AllViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<EventViewModel?> GetByIdAsync(int id)
        {
            return await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel
                {
                    OrganiserId = e.Organiser.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<JoinedViewModel>> GetJoinedAsync(string userId)
        {
            return await context.Events
                .Where(e => e.EventsParticipants.FirstOrDefault(ep => ep.HelperId == userId) != null)
                .Select(e => new JoinedViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<bool> JoinAsync(int id, string userId)
        {
            var @event = await context.Events
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (@event!.EventsParticipants.FirstOrDefault(ep => ep.HelperId == userId) == null)
            {
                @event!.EventsParticipants.Add(new EventParticipant
                {
                    EventId = id,
                    HelperId = userId
                });

                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> LeaveAsync(int id, string userId)
        {
            var @event = await context.Events
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync(e => e.Id == id);

            var eventParticipant = @event!.EventsParticipants.FirstOrDefault(ep => ep.HelperId == userId);

            if (eventParticipant != null)
            {

                context.Remove(eventParticipant);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
