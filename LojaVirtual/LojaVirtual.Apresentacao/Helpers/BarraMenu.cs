using System;
using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Helpers
{
    public class BarraMenu
    {
        public static MvcHtmlString Administrador(string titulo)
        {
            string html = "";

            html = String.Format("<div class=\"navbar\">");
            html = String.Format("{0}    <div class=\"navbar-inner\">", html);
            html = String.Format("{0}        <a class=\"brand\">{1}</a>", html, titulo);
            html = String.Format("{0}        <ul class=\"nav\" role=\"navigation\">", html);
            html = String.Format("{0}            <li class=\"dropdown\">", html);
            html = String.Format("{0}                <a href=\"#\" id=\"drop1\" role=\"button\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Mercadorias<b class=\"caret\"></b></a>", html);
            html = String.Format("{0}                <ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"drop2\">", html);
            html = String.Format("{0}                    <li><a tabindex=\"-1\" href=\"/Mercadoria/Adicionar/\">Adicionar Mercadoria</a></li>", html);
            html = String.Format("{0}                    <li><a tabindex=\"-1\" href=\"/Mercadoria/Listar/\">Listar Mercadorias</a></li>", html);
            html = String.Format("{0}                </ul>", html);
            html = String.Format("{0}            </li>", html);
            html = String.Format("{0}            <li class=\"dropdown\">", html);
            html = String.Format("{0}                <a href=\"#\" id=\"drop2\" role=\"button\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Categorias<b class=\"caret\"></b></a>", html);
            html = String.Format("{0}                <ul class=\"dropdown-menu\" role=\"menu\" aria-labelledby=\"drop2\">", html);
            html = String.Format("{0}                    <li><a tabindex=\"-1\" href=\"/Categoria/Adicionar/\">Adicionar Categoria</a></li>", html);
            html = String.Format("{0}                    <li><a tabindex=\"-1\" href=\"/Categoria/Listar/\">Listar Categorias</a></li>", html);
            html = String.Format("{0}                </ul>", html);
            html = String.Format("{0}            </li>", html);
            html = String.Format("{0}            <li><a tabindex=\"-1\" href=\"/Home/Index/\">Voltar</a></li>", html);//Menu Voltar
            html = String.Format("{0}        </ul>", html);
            html = String.Format("{0}    </div>", html);
            html = String.Format("{0}</div>", html);

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString Principal()
        {
            string html = "";

            html = String.Format("<div class=\"navbar\">");
            html = String.Format("{0}    <div class=\"navbar-inner\">", html);
            html = String.Format("{0}        <ul class=\"nav  pull-right\" role=\"navigation\">", html);
            html = String.Format("{0}            <li><a tabindex=\"-1\" href=\"/Login/Login/\"><i class=\"icon-user\"></i> Entrar</a></li>", html);//Menu Entrar
            html = String.Format("{0}        </ul>", html);
            html = String.Format("{0}    </div>", html);
            html = String.Format("{0}</div>", html);

            return new MvcHtmlString(html);
        }

    }
}