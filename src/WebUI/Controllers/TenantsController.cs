using Microsoft.AspNetCore.Mvc;
using Queuer.Application.Tenants.Queries.GetTenantBySlug;
using Queuer.Application.TodoLists.Queries.GetTodos;
using System.Threading.Tasks;

namespace Queuer.WebUI.Controllers
{
    public class TenantsController : ApiController
    {
        [HttpGet("{slug}")]
        public async Task<ActionResult<TenantDto>> GetBySlug([FromRoute] string slug)
        {
            return await Mediator.Send(new GetTenantBySlugQuery() { Slug = slug });
        }
    }
}
