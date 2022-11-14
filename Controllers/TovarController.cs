using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("warehouse/[controller]")]
    [ApiController]
    public class TovarController : ControllerBase
    {
        private static readonly IList<Tovar> tovars = new List<Tovar>();

        [HttpGet]
        public IEnumerable<Tovar> Get()
        {
            return tovars;
        }

        [HttpGet("statistic")]
        public TovarStatisticModel GetStatistic()
        {
            var result = new TovarStatisticModel
            {
                Count = tovars.Count,
                PriceWithNDS = tovars.Sum(x=>(x.kolvo*x.price)+(x.kolvo*x.price)*0.2m),
                PriceWithoutNDS = tovars.Sum(x=> x.kolvo * x.price)
            };
            return result;
        }
        [HttpPost]
        public Tovar Add(AddTovar model)
        {
            var tovar = new Tovar
            {
                ID = Guid.NewGuid(),
                FullName = model.FullName,
                Razmer = model.Razmer,
                Material = model.Material,
                kolvo = model.kolvo,
                minpr = model.minpr,
                price = model.price,
                summa = (model.kolvo * model.price)
            };
            tovars.Add(tovar);
            return tovar;
        }

        [HttpPut("{id:guid}")]
        public Tovar Update([FromRoute] Guid id, [FromBody] AddTovar model)
        {
            var targetTovar = tovars.FirstOrDefault(x => x.ID == id);
            if (targetTovar != null)
            {
                targetTovar.FullName = model.FullName;
                targetTovar.Razmer = model.Razmer;
                targetTovar.Material = model.Material;
                targetTovar.kolvo = model.kolvo;
                targetTovar.minpr = model.minpr;
                targetTovar.price = model.price;
                targetTovar.summa = (model.kolvo * model.price);
            }
            return targetTovar;
        }

        [HttpDelete("{id:guid}")]
        public bool Remove(Guid id)
        {
            var targetTovar = tovars.FirstOrDefault(x => x.ID == id);
            if (targetTovar!=null)
            {
                return tovars.Remove(targetTovar);
            }
            return false;
        }
    }
}
