﻿using AutoMapper;
using GameShop.Application.Common;
using GameShop.Application.Mapper;
using GameShop.Data.EF;
using GameShop.Data.Entities;
using GameShop.Utilities.Exceptions;
using GameShop.ViewModels.Catalog.Comments;
using GameShop.ViewModels.Catalog.Games;
using GameShop.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Application.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly GameShopDbContext _context;
        private readonly IStorageService _storageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CommentService(GameShopDbContext context, IStorageService storageService,UserManager<AppUser> userManager,IMapper mapper)
        {
            _context = context;
            _storageService = storageService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CommentDTO> CreateComment(CommentCreateReqDTO req)
        {
            if(req == null)
            {
                throw new GameShopException("Yêu cầu không được rỗng");
            }
            var user = await _userManager.FindByIdAsync(req.UserId.ToString());
            if(user == null)
            {
                throw new GameShopException("Không tìm thấy user");
            }
            var game = await _context.Games.Where(x => x.Id == req.GameId).FirstOrDefaultAsync();
            if(game == null)
            {
                throw new GameShopException("không tìm thấy game");
            }
            if (await _context.Comments.Where(x => x.UserId == req.UserId && x.GameId == req.GameId).FirstOrDefaultAsync() != null)
            {
                throw new GameShopException("Bạn đã bình luận rồi");
            }
            if (await _context.Ratings.Where(x => x.UserId == req.UserId && x.GameId == req.GameId).FirstOrDefaultAsync() != null)
            {
                throw new GameShopException("Bạn đã đánh giá rồi");
            }
            var checkBought = await _context.Checkouts.Where(x => x.Username == user.UserName && x.SoldGames.Any(x => x.GameID == req.GameId)).FirstOrDefaultAsync();
            if (checkBought == null)
            {
                throw new GameShopException("Bạn chưa mua game này");
            }
          
            var newComment = new Comment()
            {
               Game = game,
               AppUser = user,
                Content = req.Content,
                UserId = user.Id,
                Status = true,
               
            };
            var newRating = new Rating()
            {
                Game = game,
                AppUser = user,
                Point = req.Point,
                UserId = user.Id,
                Status = true
            };
            await _context.Ratings.AddAsync(newRating);
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
           return _mapper.Map<CommentDTO>(newComment);

        }

        public async Task<PagedResult<CommentDTO>> GetComment(GetCommentRequest req)
        {
            var game = await _context.Games.Where(x => x.Id ==req.GameId ).FirstOrDefaultAsync();
            if (game == null)
            {
                throw new GameShopException("không tìm thấy game");
            }
            var commentList = await _context.Comments.Where(x=>x.GameId == req.GameId).ToListAsync();
            var totalRow = commentList.Count();
            var comments = _mapper.Map<List<CommentDTO>>(commentList);          
                comments = comments.Skip((req.PageIndex - 1) * req.PageSize)
              .Take(req.PageSize).ToList();
            foreach ( var comment in comments)
            {
                var rating =  await _context.Ratings.Where(x=>x.UserId== comment.UserId).FirstOrDefaultAsync();
                if(rating == null)
                {
                    comment.Rating = 0;
                }
                else
                {
                    comment.Rating = rating.Point;
                }
                var userImage = await _context.UserAvatar.Where(x=>x.UserID == comment.UserId).FirstOrDefaultAsync();
                if(userImage != null) 
                {
                    comment.ImagePath = userImage.ImagePath;
                }
            }
                //select and projection
                var pagedResult = new PagedResult<CommentDTO>()
            {
                TotalRecords = totalRow,
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                Items = comments
            };
            return pagedResult;
        }
    }
}
