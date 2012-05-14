#region header
// <copyright file="ManagerMap.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion

using FluentNHibernate.Mapping;

namespace Models.Impl
{
    public class ManagerMap : SubclassMap<Manager>
    {
        public ManagerMap()
        {
            DiscriminatorValue("Manager");

//            Map(c => c.Division);
//            Map(c => c.Status);

            Join("Manager", joined =>
                                {
                                    joined.Map(c => c.Division);
                                    joined.Map(c => c.Status);
                                });
        }
    }
}