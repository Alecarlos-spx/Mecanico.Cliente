using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMecanica.ClienteApi.Shared.Entities
{
    public abstract class Entity
    {
        public IList<string> _Notificacoes;

        protected Entity(IList<string> notificacoes)
        {
            //Id = id;
            _Notificacoes = notificacoes;
        }

        //public Guid Id { get; private set; }


    }
}
