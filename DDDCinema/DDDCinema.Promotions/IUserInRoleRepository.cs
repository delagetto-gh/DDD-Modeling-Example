﻿using System.Collections.Generic;

namespace DDDCinema.Promotions
{
    public interface IUserInRoleRepository
    {
        List<Editor> GetAllEditors();
    }
}