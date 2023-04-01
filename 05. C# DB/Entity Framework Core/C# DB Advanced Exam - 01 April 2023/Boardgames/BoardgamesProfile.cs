namespace Boardgames
{
    using AutoMapper;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;

    public class BoardgamesProfile : Profile
    {
        // DO NOT CHANGE OR RENAME THIS CLASS!
        public BoardgamesProfile()
        {
            CreateMap<ImportBoardgameDto, Boardgame>()
                .ForMember(d => d.CategoryType, 
                         opt => opt.MapFrom(s => (CategoryType)s.CategoryType));
            CreateMap<ImportSellerDto, Seller>();
        }
    }
}