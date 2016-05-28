using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.AuthService;

namespace Website.AuthService
{
    // permite "continuar" a escrever código da classe User (tem que se usar o mesmo namespace)
    //sem ser no ficheiro gerado automaticamente (para não perder o código na próxima atualização)
    public partial class User
    {

        public override string ToString()
        {
            return "Nome: " + this.Name + " | Descrição: " + this.Description;
        }

    }
}