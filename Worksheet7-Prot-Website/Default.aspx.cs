using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.AuthService;

namespace Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            // verificar se a password é a correta
            User[] users = client.GetUsers("admin", "123");

            // mostrar users (caso seja possível)
            if (users == null)
                Response.Write("Autenticação/autorização inválida | (ou não existem utilizadores)");
            else
            {
                foreach (User user in users)
                {
                    Literal literal = new Literal();
                    literal.Text = Server.HtmlEncode(user.ToString())+ "<br/>";
                    Panel1.Controls.Add(literal);
                }
            }
        }
    }
}