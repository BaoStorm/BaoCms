using System;
using System.Collections.Generic;
using System.Text;
using Identity.Domain.SeedWork;

namespace Identity.Domain.AggregatesModel.UserAggregate
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public class RoleType: Enumeration
    {
        public static RoleType Admin = new RoleType(1, "管理员");
        public static RoleType Employee = new RoleType(2, "员工");

        protected RoleType()
        {
        }

        public RoleType(int id, string name)
            : base(id, name)
        {
        }
    }
}
