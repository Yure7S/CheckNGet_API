﻿using CheckNGet.Data;
using CheckNGet.Interface;
using CheckNGet.Models;

namespace CheckNGet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }
        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetUser(string username)
        {
            return _context.Users.Where(u => u.UserName == username).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public ICollection<Order> GetOrdersByUser(int userId)
        {
            return _context.Orders.Where(o => o.User.Id == userId).ToList();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }
        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
    }
}
