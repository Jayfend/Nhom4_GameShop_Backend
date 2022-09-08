﻿using GameShop.Data.EF;
using GameShop.Data.Entities;
using GameShop.Data.Enums;
using GameShop.ViewModels.Catalog.Carts;
using GameShop.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Application.Catalog.Carts
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
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserID.ToString() == UserID && x.Status.Equals((Status)1));
            if (getCart != null)
            {
                var check = await _context.OrderedGames.FirstOrDefaultAsync(x => x.CartID == getCart.CartID && x.GameID == cartCreateRequest.GameID);
                if (check != null)
                {
                    return new ApiErrorResult<bool>("Bạn đã thêm game này rồi");
                }
                else
                {
                    OrderedGame newgame = new OrderedGame()
                    {
                        GameID = cartCreateRequest.GameID,
                        CartID = getCart.CartID,
                    };
                    _context.OrderedGames.Add(newgame);
                    await _context.SaveChangesAsync();
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                Cart newcart = new Cart()
                {
                    UserID = new Guid(UserID),
                    Status = Data.Enums.Status.Active,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                OrderedGame newgame = new OrderedGame()
                {
                    GameID = cartCreateRequest.GameID,
                    Cart = newcart
                };
                _context.OrderedGames.Add(newgame);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<bool>> DeleteItem(string UserID, OrderItemDelete orderItemDelete)
        {
            var orderitem = await _context.OrderedGames.FirstOrDefaultAsync(x => x.Cart.UserID.ToString() == UserID && x.GameID == orderItemDelete.GameID);
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

        public async Task<ApiResult<List<OrderItemResponse>>> GetCart(string UserID)
        {
            var getCart = await _context.OrderedGames.Where(x => x.Cart.UserID.ToString() == UserID && x.Cart.Status.Equals((Status)1))
                .Select(x => new OrderItemResponse()
                {
                    GameId = x.GameID,
                    Name = x.Game.GameName,
                    Price = x.Game.Price,
                    Discount = x.Game.Discount,
                    ImageList = new List<string>()
                }).ToListAsync();

            var thumbnailimage = _context.GameImages.AsQueryable();
            foreach (var item in getCart)
            {
                var listgame = thumbnailimage.Where(x => x.GameID == item.GameId).Select(y => y.ImagePath).ToList();
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