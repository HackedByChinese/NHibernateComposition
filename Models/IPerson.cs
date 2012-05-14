using System;

namespace Models
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        /// <summary>
        /// Gets the ID of the entity.
        /// </summary>
        Int32 Id { get; }
    }
}