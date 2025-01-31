﻿using GameShop.Data.EF;
using GameShop.Data.Entities;
using GameShop.ViewModels.Catalog.Carts;
using GameShop.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Application.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly GameShopDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CartService(GameShopDbContext context, UserManager<AppUser> useManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = useManager;
            _signInManager = signInManager;
        }

        public async Task<ApiResult<bool>> AddToCart(string UserID, CartCreateRequest cartCreateRequest)
        {
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserID.ToString() == UserID && x.Status == true);
            if (getCart != null)
            {
                var check = await _context.OrderedGames.FirstOrDefaultAsync(x => x.CartID == getCart.Id && x.GameID == cartCreateRequest.GameID);
                if (check != null)
                {
                    return new ApiErrorResult<bool>("Bạn đã thêm game này rồi");
                }
                else
                {
                    OrderedGame newgame = new OrderedGame()
                    {
                        GameID = cartCreateRequest.GameID,
                        CartID = getCart.Id,
                        CreatedDate = DateTime.Now,
                    };
                    _context.OrderedGames.Add(newgame);
                    await _context.SaveChangesAsync();
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var orderedgames = await _context.OrderedGames.ToListAsync();
                var bills = await _context.Checkouts.Where(x => x.Cart.UserID.ToString() == UserID).Select(y => y.CartID).ToListAsync();
                if (bills.Count > 0)
                {
                    foreach (var item in bills)
                    {
                        var check = orderedgames.FirstOrDefault(x => x.CartID == item && x.GameID == cartCreateRequest.GameID);
                        if (check != null)
                        {
                            return new ApiErrorResult<bool>("Bạn đã mua game này rồi");
                        }
                    }
                    Cart cart = new Cart()
                    {
                        UserID = new Guid(UserID),
                        Status = true,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    };
                    OrderedGame game = new OrderedGame()
                    {
                        GameID = cartCreateRequest.GameID,
                        Cart = cart,
                        CreatedDate = DateTime.Now
                    };
                    _context.OrderedGames.Add(game);
                    await _context.SaveChangesAsync();
                    return new ApiSuccessResult<bool>();
                }

                Cart newcart = new Cart()
                {
                    UserID = new Guid(UserID),
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                OrderedGame newgame = new OrderedGame()
                {
                    GameID = cartCreateRequest.GameID,
                    Cart = newcart,
                    CreatedDate = DateTime.Now
                };
                _context.OrderedGames.Add(newgame);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<bool>> DeleteItem(string UserID, OrderItemDelete orderItemDelete)
        {
            var orderitem = await _context.OrderedGames.FirstOrDefaultAsync(x => x.Cart.UserID.ToString() == UserID && x.GameID == orderItemDelete.Id);
            if (orderitem == null)
            {
                return new ApiErrorResult<bool>("Không tìm thấy game");
            }
            else
            {
                _context.OrderedGames.Remove(orderitem);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<List<OrderItemResponse>>> GetCart(string userId)
        {
            var getCart = await _context.OrderedGames.Where(x => x.Cart.UserID.ToString() == userId && x.Cart.Status == true)
                .Select(x => new OrderItemResponse()
                {
                    Id = x.GameID,
                    Name = x.Game.GameName,
                    Price = x.Game.Price,
                    Discount = x.Game.Discount,
                    ImageList = new List<string>(),
                    AddedDate = x.CreatedDate,
                    GenreName = new List<string>(),
                    GenreIds = x.Game.GameInGenres.Select(y => y.GenreID).ToList(),
                }).ToListAsync();
            var genres = _context.Genres.AsQueryable();

            foreach (var item in getCart)
            {
                foreach (var genre in item.GenreIds)
                {
                    var name = genres.Where(x => x.Id == genre).Select(y => y.GenreName).FirstOrDefault();
                    item.GenreName.Add(name);
                }
            }
            var thumbnailimage = _context.GameImages.AsQueryable();
            foreach (var item in getCart)
            {
                var listgame = thumbnailimage.Where(x => x.GameID == item.Id).Select(y => y.ImagePath).ToList();
                item.ImageList = listgame;
            }

            if (getCart == null)
            {
                return new ApiErrorResult<List<OrderItemResponse>>("Không tìm thấy giỏ hàng");
            }

            return new ApiSuccessResult<List<OrderItemResponse>>(getCart);
        }
    }
}