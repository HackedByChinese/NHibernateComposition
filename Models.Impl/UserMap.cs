#region header
// <copyright file="UserMap.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion

using FluentNHibernate.Mapping;

namespace Models.Impl
{
    public class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            DiscriminatorValue("User");

            Join("User", joined =>
                             {
                                 joined.Map(c => c.LoginName);
                                 joined.Map(c => c.Password);
                             });
        }
    }
}