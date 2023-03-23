using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicaçãoContainer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerService _containerService;

        public ContainerController(IContainerService containerService)
        {
            _containerService = containerService;
        }

        [HttpGet]
        public ActionResult FindAllContainer() 
        {
            var containers = _containerService.GetAllContainers();

            return Ok(containers);
        }

   

        [HttpPost]
        public ActionResult CreateContainer(ContainerDTO container) 
        {

            var containercreate = _containerService.Create(container);

            return Ok(containercreate);

        }

        [HttpDelete]
        public ActionResult DeleteContainer(Guid id) 
        {
        
        _containerService.DeleteContainerAsync(id);

            return Ok();
        
        }

        [HttpPut]
        public ActionResult PutContainer(Container container) 
        { 
         var containeruptade = _containerService.Update(container);
            return Ok(containeruptade);
        }


    }
}
