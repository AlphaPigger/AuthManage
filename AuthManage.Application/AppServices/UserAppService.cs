﻿using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class UserAppService:AppService<UserDto>,IUserAppService
    {
        public UserDto CheckUser(string username,string password)
        {
            return null;
        }
    }
}
