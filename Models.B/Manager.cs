#region header
// <copyright file="Manager.cs" company="mikegrabski.com">
//      Copyright (c) 2012 Mike Grabski. All rights reserved.
// </copyright>
#endregion
namespace Models
{
    public class Manager : Role
    {
        public virtual string Division { get; set; }

        public virtual string Status { get; set; }
    }
}