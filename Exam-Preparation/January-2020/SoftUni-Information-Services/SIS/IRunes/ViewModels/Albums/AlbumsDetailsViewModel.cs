﻿using IRunes.Models;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.ViewModels.Albums
{
    public class AlbumsDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}
