﻿using System;
using System.Linq;
using DDDCinema.Application.Presentation.Authentication;

namespace DDDCinema.DataAccess.Presentation
{
    public class EfLoginRepository : ILoginViewRepository
    {
        private readonly CinemaContext _context;

        public EfLoginRepository(CinemaContext context)
        {
            _context = context;
        }

        public LoginAttemptDTO GetLoginAttemptById(Guid id)
        {
            return _context.LoginAttempts
                .Select(la => new LoginAttemptDTO
                {
                    LoginAttemptId = la.LoginAttemptId,
                    Message = la.Message,
                    Succeeded = la.Succeeded,
                    UserId = la.UserId,
					UserRole = la.UserRole,
                    UserName = la.UserId.HasValue
                        ? _context.Users.Where(u => u.Id == la.UserId).Select(u => u.Name).FirstOrDefault()
                        : null,
                }).FirstOrDefault(la => la.LoginAttemptId == id);
        }
    }
}
