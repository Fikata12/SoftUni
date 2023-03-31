namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using Data;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities.XmlConvert;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TrucksProfile>();
        }));

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var importDespatcherDtos = XmlConvert.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            StringBuilder sb = new StringBuilder();
            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();
            foreach (var despatcherDto in importDespatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();
                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validTrucks.Add(mapper.Map<Truck>(truckDto));
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };
                validDespatchers.Add(despatcher);

                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}