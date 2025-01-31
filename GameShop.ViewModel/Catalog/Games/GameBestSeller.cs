﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.ViewModels.Catalog.Games
{
    public class GameBestSeller
    {
        public Guid GameID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string Gameplay { get; set; }
        public List<string> GenreName { get; set; }
        public List<Guid> GenreIDs { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public SystemRequireMin SRM { get; set; }
        public SystemRequirementRecommend SRR { get; set; }
        public List<string> ListImage { get; set; }
        public int BuyCount { get; set; }
        public Guid PublisherId { get; set; }
    }
}