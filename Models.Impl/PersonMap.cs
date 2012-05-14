#region header
// <copyright file="PersonBaseMap.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion

using FluentNHibernate.Mapping;

namespace Models.Impl
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(c => c.Id)
                .GeneratedBy.HiLo("100");

            Map(c => c.FirstName);
            Map(c => c.LastName);

            HasMany(c => c.Roles)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}