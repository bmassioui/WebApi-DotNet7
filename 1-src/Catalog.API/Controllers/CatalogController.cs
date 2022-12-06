namespace Catalog.API.Controllers;

public class CatalogController : ApiBaseController
{
    private static List<Catalog> _inMemoryDb = new List<Catalog> {
        new Catalog { ImageUrl = "https://m.media-amazon.com/images/I/61IiCJ7QggS._AC_SL1500_.jpg",Name = "Logitech G305 LIGHTSPEED Wireless Gaming Mouse", Rating = 4.5f, Description="Logitech G305 LIGHTSPEED Wireless Gaming Mouse, Hero 12K Sensor, 12,000 DPI, Lightweight, 6 Programmable Buttons, 250h Battery Life, On-Board Memory, PC/Mac - Mint", Price = 41.90m },
        new Catalog { ImageUrl = "https://m.media-amazon.com/images/I/61AuRwdIkrL._AC_SL1500_.jpg",Name = "Portable 60% Mechanical Gaming Keyboard", Rating = 4.5f, Description="Portable 60% Mechanical Gaming Keyboard, MageGee MK-Box LED Backlit Compact 68 Keys Mini Wired Office Keyboard with Red Switch for Windows Laptop PC Mac - White/Blue.", Price = 29.99m },
        new Catalog { ImageUrl = "https://m.media-amazon.com/images/I/61qItTcisGL._AC_SL1000_.jpg",Name = "ZD-V+ USB Wired Gaming Controller Gamepad", Rating = 4, Description="ZD-V+ USB Wired Gaming Controller Gamepad For PC/Laptop Computer(Windows XP/7/8/10/11) & PS3 & Android & Steam - [Black].", Price = 19.99m },
        new Catalog { ImageUrl = "https://m.media-amazon.com/images/I/61O7HHu181L._AC_SL1500_.jpg",Name = "Logitech G920 Driving Force Racing Wheel and Floor Pedals", Rating = 5, Description="Logitech G920 Driving Force Racing Wheel and Floor Pedals, Real Force Feedback, Stainless Steel Paddle Shifters, Leather Steering Wheel Cover for Xbox Series X|S, Xbox One, PC, Mac - Black", Price = 299.99m },
        new Catalog { ImageUrl = "https://m.media-amazon.com/images/I/71wXQyxCENL._AC_SL1500_.jpg",Name = "Tatybo Gaming Headset", Rating = 4.5f, Description="Tatybo Gaming Headset for PS4 PS5 Xbox One Switch PC with Noise Canceling Mic, Deep Bass Stereo Sound", Price = 21.99m },
    };


}
record Catalog
{
    public Guid Id => Guid.NewGuid();
    public required string ImageUrl { get; set; }
    public required string Name { get; set; }
    public float Rating { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

