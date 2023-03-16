namespace MusicHub
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer?.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        s.Name,
                        Price = s.Price.ToString("f2"),
                        WriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.WriterName)
                    .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}")
                  .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                  .AppendLine($"-ProducerName: {a.ProducerName}");

                sb.AppendLine($"-Songs:");

                int i = 1;
                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{i}")
                      .AppendLine($"---SongName: {s.Name}")
                      .AppendLine($"---Price: {s.Price}")
                      .AppendLine($"---Writer: {s.WriterName}");
                    i++;
                }
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").OrderBy(p => p).ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{i}")
                  .AppendLine($"---SongName: {s.Name}")
                  .AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.Performers)
                {
                    sb.AppendLine($"---Performer: {p}");
                }
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                  .AppendLine($"---Duration: {s.Duration}");
                i++;
            }
            return sb.ToString().TrimEnd();
        }
    }
}
