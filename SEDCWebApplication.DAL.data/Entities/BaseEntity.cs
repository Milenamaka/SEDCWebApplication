using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.data.Entities
{
    public class BaseEntity
    {
        public int? Id { get; set; }

        public EntityStateEnum EntityState { get; set; }
        protected BaseEntity(int? id)
        {
            this.EntityState = id.HasValue ? EntityStateEnum.Loaded : EntityStateEnum.New;
            this.Id = id;
        }

    }
}
