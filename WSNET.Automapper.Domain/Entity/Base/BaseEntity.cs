using System;

namespace WSNET.Automapper.Domain.Entity.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }
    }
}
