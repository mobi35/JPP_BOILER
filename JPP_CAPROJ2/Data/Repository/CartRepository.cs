﻿using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly JPPDbContext _context;

        public CartRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Cart FindCart(Func<Cart, bool> predicate)
        {
            return _context.Carts
                   .FirstOrDefault(predicate);
        }
    }
}
