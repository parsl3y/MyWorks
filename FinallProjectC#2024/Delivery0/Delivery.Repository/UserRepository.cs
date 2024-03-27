using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;

namespace Delivery.Repository
{
    public class UsersRepository
    {
        private readonly DeliveryContextDB _context;

        public UsersRepository(DeliveryContextDB context)
        {
            _context = context;
        }
        public async Task AddUserAsync(Users user)
        {
            if (user.Password == "1admin1")
            {
                user.RoleId = 1;
            }
            else if (user.Password == "1deliver1")
            {
                user.RoleId = 3;
            }
            else
            {
                user.RoleId = 2;
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<Users> GetUserByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == login);
        }
        public async Task<int?> GetRoleIdByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
            return user?.RoleId;
        }
        public async Task<int?> GetUserIdByPhoneNumberAsync(string phoneNumber)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
                return user?.Id;
            }

        }
    }
