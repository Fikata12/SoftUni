using Homies.Data;
using Homies.Models;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
	public class TypeService : ITypeService
	{
		private readonly HomiesDbContext context;
		public TypeService(HomiesDbContext context)
		{
			this.context = context;
		}

		public async Task<ICollection<TypeViewModel>> GetAllAsync()
		{
			return await context.Types
				.AsNoTracking()
				.Select(t => new TypeViewModel
				{
					Id = t.Id,
					Name = t.Name
				})
				.ToListAsync();
		}
	}
}
