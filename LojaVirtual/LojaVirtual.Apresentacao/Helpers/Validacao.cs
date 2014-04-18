using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Helpers
{
    public static class Validacao
    {
        /// <summary>
        /// Returns an error alert that lists each model error, much like the standard ValidationSummary only with
        /// altered markup for the Twitter bootstrap styles.
        /// </summary>
        public static MvcHtmlString ValidationSummaryBootstrap(this HtmlHelper helper, bool closeable)
        {
            var errors = helper.ViewContext.ViewData.ModelState.SelectMany(state => state.Value.Errors.Select(error => error.ErrorMessage));

            int errorCount = errors.Count();

            if (errorCount == 0)
            {
                return new MvcHtmlString(string.Empty);
            }

            var div = new TagBuilder("div");
            div.AddCssClass("alert");
            div.AddCssClass("alert-error");

            string message;

            if (errorCount == 1)
            {
                //message = errors.First();
                message = "O campo indicado abaixo deve ser preenchido. Por favor preencha-o e tente novamente.";
                div.AddCssClass("alert-block");
            }
            else
            {
                message = "Os campos indicados abaixo devem ser preenchidos. Por favor preencha-os e tente novamente.";
                div.AddCssClass("alert-block");
            }

            if (closeable)
            {
                var button = new TagBuilder("button");
                button.AddCssClass("close");
                button.MergeAttribute("type", "button");
                button.MergeAttribute("data-dismiss", "alert");
                button.SetInnerText("x");
                div.InnerHtml += button.ToString();
            }

            div.InnerHtml += "<strong>Atenção!</strong> - " + message;

            if (errorCount > 0)
            {
                var ul = new TagBuilder("ul");

                foreach (var error in errors)
                {
                    var li = new TagBuilder("li");
                    li.AddCssClass("text-error");
                    var erro = error;
                    if (erro.Contains("*"))
                        erro = erro.Substring(erro.IndexOf('*') + 1);
                    li.SetInnerText(erro);
                    ul.InnerHtml += li.ToString();
                }

                div.InnerHtml += ul.ToString();
            }

            return new MvcHtmlString(div.ToString());
        }

        /// <summary>
        /// Overload allowing no arguments.
        /// </summary>
        public static MvcHtmlString ValidationSummaryBootstrap(this HtmlHelper helper)
        {
            return ValidationSummaryBootstrap(helper, true);
        }
    }
}