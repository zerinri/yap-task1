using System;

namespace Server.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime ModifedDate { get; set; }
    }
}
