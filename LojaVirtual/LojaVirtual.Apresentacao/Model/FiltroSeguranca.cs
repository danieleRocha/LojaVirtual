using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Model
{
    public class FiltroSeguranca:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/NaoAutorizado");
            }
        }
    }
}
