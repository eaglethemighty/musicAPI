﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models
{
    public class Album
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [NotMapped]
        public TimeSpan? Length 
        { 
            get
            {
                return Songs is null ? new TimeSpan(0, 0, 0) : new TimeSpan(Songs.Sum(song => song.Length.Ticks));
            }
                
        }

        [NotMapped]
        public int NumberOfSongs 
        { 
            get 
            {
                return Songs is null ? 0 : Songs.Count;
            }
        }

        [Required]
        public int RealeaseYear { get; set; }

        [Required]
        public Artist Artist { get; set; }

        public IList<Song>? Songs { get; set; }
    }
}