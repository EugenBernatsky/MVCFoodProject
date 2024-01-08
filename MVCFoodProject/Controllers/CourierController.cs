using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MVCFoodProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "courier")]
    [Route("api/[controller]")]
    [ApiController]

    public class CourierController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CourierController(ApplicationDbContext context)
        {
            _db = context;
        }

        [HttpPost("/orders/toggle")]
        public async Task<ActionResult<Orders>> ToggleOrders([FromBody] ToggleOrderDTO body)
        {
            var contextUser = (Users)HttpContext.Items["User"];

            var courier = await _db.Courier
                .Where(c => c.User.Id == contextUser.Id)
                .FirstOrDefaultAsync();

            if (body.action == ToggleOrderDTO.ACTION.take)
            {
                try
                {
                    var order = await _db.Order
                        .Where(o => o.Id == body.Id)
                        .FirstOrDefaultAsync();

                    if (order != null)
                    {
                        order.status = Orders.Status.Taken;
                        order.Courier = courier;
                        order.CourierId = courier.Id;

                        courier.Order.Add(order);

                        if (_db.ChangeTracker.HasChanges())
                        {
                            await _db.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            if (body.action == ToggleOrderDTO.ACTION.untake)
            {
                try
                {
                    var order = await _db.Order
                        .Where(o => o.Id == body.Id)
                        .FirstOrDefaultAsync();

                    if (order != null)
                    {
                        order.status = Orders.Status.Canceled;
                        order.Courier = null;
                        order.CourierId = null;

                        courier.Order.Remove(order);

                        if (!courier.Order.Any())
                        {
                            courier.status = Courier.Status.free;
                        }

                        if (_db.ChangeTracker.HasChanges())
                        {
                            await _db.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return Ok();
        }

        [HttpPost("/orders/complete")]
        public async Task<ActionResult> CompleteOrders([FromBody] ToggleOrderDTO body)
        {
            var contextUser = (Users)HttpContext.Items["User"];

            var order = await _db.Order
                .Where(o => o.Id == body.Id)
                .FirstOrDefaultAsync();

            var courier = await _db.Courier
                .Where(c => c.User.Id == contextUser.Id)
                .FirstOrDefaultAsync();

            try
            {
                order.status = Orders.Status.Completed;

                if (!courier.Order.Any())
                {
                    courier.status = Courier.Status.free;
                }

                if (_db.ChangeTracker.HasChanges())
                {
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
