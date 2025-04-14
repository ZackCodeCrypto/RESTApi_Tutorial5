namespace RESTApi.Data;
using RESTApi.Models;

public static class StaticDb
{
    public static List<Animal> Animals { get; set; } = new()
    {
        new Animal { Id = 1, Name = "Buddy", Category = "Dog", Weight = 25.5, FurColor = "Brown" },
        new Animal { Id = 2, Name = "Mittens", Category = "Cat", Weight = 4.2, FurColor = "Black" }
    };

    public static List<Visit> Visits { get; set; } = new();
}
