﻿using AuthManage.Application.DTOModel;
using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IUserAppService:IAppService<UserDto>
    {
        UserDto CheckUser(string username,string password);
    }
}
