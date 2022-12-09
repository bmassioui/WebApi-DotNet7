using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Produces("application/json")]
public class CatalogEntityController : ApiBaseController
{
    private static List<Product> _inMemoryDb = new()
    {
        new Product { Id = Guid.Parse("bd2ae998-e95a-45d7-8cbe-61934c85d6b1"), ImageUrl = new Uri("https://m.media-amazon.com/images/I/61IiCJ7QggS._AC_SL1500_.jpg"),Name = "Logitech G305 LIGHTSPEED Wireless Gaming Mouse", Rating = 4.5f, Description="Logitech G305 LIGHTSPEED Wireless Gaming Mouse, Hero 12K Sensor, 12,000 DPI, Lightweight, 6 Programmable Buttons, 250h Battery Life, On-Board Memory, PC/Mac - Mint", Price = 41.90m },
        new Product { Id = Guid.Parse("b0d711dd-5867-42f7-bc76-41605f9f20df"), ImageUrl = new Uri("https://m.media-amazon.com/images/I/61AuRwdIkrL._AC_SL1500_.jpg"),Name = "Portable 60% Mechanical Gaming Keyboard", Rating = 4.5f, Description="Portable 60% Mechanical Gaming Keyboard, MageGee MK-Box LED Backlit Compact 68 Keys Mini Wired Office Keyboard with Red Switch for Windows Laptop PC Mac - White/Blue.", Price = 29.99m },
        new Product { Id = Guid.Parse("b8082aca-0dc6-47ec-94c3-d4e7a88239c4"), ImageUrl = new Uri("https://m.media-amazon.com/images/I/61qItTcisGL._AC_SL1000_.jpg"),Name = "ZD-V+ USB Wired Gaming Controller Gamepad", Rating = 4, Description="ZD-V+ USB Wired Gaming Controller Gamepad For PC/Laptop Computer(Windows XP/7/8/10/11) & PS3 & Android & Steam - [Black].", Price = 19.99m },
        new Product { Id = Guid.Parse("b4ddafbe-317d-4206-8e5e-403316c98ae3"), ImageUrl = new Uri("https://m.media-amazon.com/images/I/61O7HHu181L._AC_SL1500_.jpg"),Name = "Logitech G920 Driving Force Racing Wheel and Floor Pedals", Rating = 5, Description="Logitech G920 Driving Force Racing Wheel and Floor Pedals, Real Force Feedback, Stainless Steel Paddle Shifters, Leather Steering Wheel Cover for Xbox Series X|S, Xbox One, PC, Mac - Black", Price = 299.99m },
        new Product { Id = Guid.Parse("23552541-7ee2-44ec-9002-b8cd61a6988c"), ImageUrl = new Uri("https://m.media-amazon.com/images/I/71wXQyxCENL._AC_SL1500_.jpg"),Name = "Tatybo Gaming Headset", Rating = 4.5f, Description="Tatybo Gaming Headset for PS4 PS5 Xbox One Switch PC with Noise Canceling Mic, Deep Bass Stereo Sound", Price = 21.99m },
    };

    /// <summary>
    /// Get CatalogEntitys
    /// </summary>
    /// <returns>List of CatalogEntitys sorted by creation date DESC</returns>
    /// <response code="200">Returns the list of CatalogEntitys sorted by creation date DESC</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(_inMemoryDb);
    }

    /// <summary>
    /// Get CatalogEntity by Id
    /// </summary>
    /// <param name="id">CatalogEntity's Id</param>
    /// <returns>CatalogEntity details</returns>
    /// <response code="200">Returns the CatalogEntity's details</response>
    /// <response code="404">If no CatalogEntity found</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> Get(Guid id)
    {
        return Ok(_inMemoryDb.Find(CatalogEntity => CatalogEntity.Id == id));
    }

    /// <summary>
    /// Add CatalogEntity
    /// </summary>
    /// <param name="CatalogEntity"></param>
    /// <returns>The created CatalogEntity</returns>
    /// <response code="201">The created CatalogEntity's details</response>
    /// <response code="400">Unable to create CatalogEntity</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Product> Add(Product CatalogEntity)
    {
        _inMemoryDb.Add(CatalogEntity);

        return CreatedAtAction(nameof(Get), new { CatalogEntity.Id }, CatalogEntity);
    }

    /// <summary>
    /// Update an existing CatalogEntity
    /// </summary>
    /// <returns></returns>
    /// <response code="204">The update done successfully</response>
    /// <response code="404">If no CatalogEntity found</response>
    /// <response code="400">Unable to update CatalogEntity</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put()
    {
        return NoContent();
    }

    /// <summary>
    /// Delete an existing CatalogEntity by Id
    /// </summary>
    /// <param name="id">CatalogEntity's Id</param>
    /// <returns></returns>
    /// <response code="204">The deletion done successfully</response>
    /// <response code="404">If no CatalogEntity found</response>
    /// <response code="400">Unable to delete CatalogEntity</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }
}