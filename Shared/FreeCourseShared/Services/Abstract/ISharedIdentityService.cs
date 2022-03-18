using System;
using System.Collections.Generic;
using System.Text;

namespace FreeCourseShared.Services.Abstract
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }
    }
}
