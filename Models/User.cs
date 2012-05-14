#region header
// <copyright file="User.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion
namespace Models
{
    public class User : Role
    {
        public virtual string LoginName { get; set; }

        public virtual string Password { get; set; }
    }
}