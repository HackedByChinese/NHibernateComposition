#region header
// <copyright file="RoleMap.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion

using FluentNHibernate.Mapping;

namespace Models.Impl
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(c => c.Id)
                .GeneratedBy.HiLo("100");

            DiscriminateSubClassesOnColumn<string>("RoleName");

            References(c => c.Person);
        }
    }
}