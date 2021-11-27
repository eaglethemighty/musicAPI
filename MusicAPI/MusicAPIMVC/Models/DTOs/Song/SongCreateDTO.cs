using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPIMVC.Models.DTOs.Song
{
    public class SongCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan Length { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}
