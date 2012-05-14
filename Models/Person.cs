#region header
// <copyright file="Person.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion

using System.Collections.Generic;

namespace Models
{
    public class Person : Entity, IPerson
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual IList<Role> Roles { get; protected set; }

        public Person()
        {
            Roles = new List<Role>();
        }

        public virtual void AddRole(Role role)
        {
            if (Roles.Contains(role)) return;

            role.Person = this;

            Roles.Add(role);
        }

        public virtual void RemoveRole(Role role)
        {
            if (!Roles.Contains(role)) return;

            role.Person = null;

            Roles.Remove(role);
        }
    }
}