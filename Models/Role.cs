#region header
// <copyright file="Role.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion
namespace Models
{
    public abstract class Role : Entity
    {
        public virtual Person Person { get; set; }

        public virtual string RoleName { get; protected set; }
    }
}