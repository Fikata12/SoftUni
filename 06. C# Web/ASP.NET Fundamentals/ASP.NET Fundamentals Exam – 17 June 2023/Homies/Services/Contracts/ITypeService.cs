using Homies.Models;

namespace Homies.Services.Contracts
{
	public interface ITypeService
	{
		Task<ICollection<TypeViewModel>> GetAllAsync();
	}
}
