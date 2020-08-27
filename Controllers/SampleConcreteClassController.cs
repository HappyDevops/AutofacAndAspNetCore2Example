using System;
using HappyDevops.AutofacAndAspnetCore2.Dependences;
using Microsoft.AspNetCore.Mvc;

namespace HappyDevops.AutofacAndAspnetCore2.Controllers
{
    [Route("api/sample/")]
    public class SampleConcreteClassController : Controller
    {
        private readonly GenericComponent _component;

        public SampleConcreteClassController(GenericComponent component)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
        }

        [HttpGet]
        [Route("concreteSample")]
        public IActionResult Execute()
        {
            return new ObjectResult(_component.WriteCustomText());
        }
    }
}
