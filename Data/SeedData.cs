using GameDevResources.Data;
using GameDevResources.Models;

public static class SeedData
{
    public static void Initialize(GameDevResourcesContext context)
    {
        if (context.Resource.Any())
        {
            return;   // DB has been seeded
        }

        context.Resource.AddRange(
            new Resource
            {
                Name = "Unity Documentation",
                Type = ResourceType.Website,
                URL = "https://docs.unity3d.com/",
                Pricing = PricingModel.Free,
                Tags = ["Documentation", "Unity"],
                Icon = "https://icons.duckduckgo.com/ip2/docs.unity3d.com.ico"
            },
            new Resource
            {
                Name = "Blender",
                Type = ResourceType.Tool,
                URL = "https://www.blender.org/",
                Pricing = PricingModel.Free,
                Tags = ["3D Modeling", "Animation"],
                Icon = "https://icons.duckduckgo.com/ip2/www.blender.org.ico"
            },
            new Resource
            {
                Name = "GIMP",
                Type = ResourceType.Tool,
                URL = "https://www.gimp.org/",
                Pricing = PricingModel.Free,
                Tags = ["Image Editing", "Open Source"],
                Icon = "https://icons.duckduckgo.com/ip2/www.gimp.org.ico"
            },
            new Resource
            {
                Name = "Unreal Engine Marketplace",
                Type = ResourceType.Website,
                URL = "https://www.unrealengine.com/marketplace",
                Pricing = PricingModel.Paid,
                Tags = ["Assets", "Marketplace"],
                Icon = "https://icons.duckduckgo.com/ip2/www.unrealengine.com.ico"
            },
            new Resource
            {
                Name = "Texture Haven",
                Type = ResourceType.Website,
                URL = "https://texturehaven.com/",
                Pricing = PricingModel.Free,
                Tags = ["Textures", "Free Resources"],
                Icon = "https://icons.duckduckgo.com/ip2/texturehaven.com.ico"
            },
            new Resource
            {
                Name = "Mixamo",
                Type = ResourceType.Tool,
                URL = "https://www.mixamo.com/",
                Pricing = PricingModel.Freemium,
                Tags = ["Animation", "Character Rigging"],
                Icon = "https://icons.duckduckgo.com/ip2/www.mixamo.com.ico"
            },
            new Resource
            {
                Name = "Sprite Sheet Generator",
                Type = ResourceType.Generator,
                URL = "https://www.codeandweb.com/free-sprite-sheet-packer",
                Pricing = PricingModel.Free,
                Tags = ["Sprite", "Generator"],
                Icon = "https://icons.duckduckgo.com/ip2/www.codeandweb.com.ico"
            },
            new Resource
            {
                Name = "Tiled Map Editor",
                Type = ResourceType.Tool,
                URL = "https://www.mapeditor.org/",
                Pricing = PricingModel.Free,
                Tags = ["Map Editor", "Tilemap"],
                Icon = "https://icons.duckduckgo.com/ip2/www.mapeditor.org.ico"
            },
            new Resource
            {
                Name = "Godot Engine Documentation",
                Type = ResourceType.Website,
                URL = "https://docs.godotengine.org/",
                Pricing = PricingModel.Free,
                Tags = ["Documentation", "Godot"],
                Icon = "https://icons.duckduckgo.com/ip2/docs.godotengine.org.ico"
            },
            new Resource
            {
                Name = "Photoshop",
                Type = ResourceType.Tool,
                URL = "https://www.adobe.com/products/photoshop.html",
                Pricing = PricingModel.Paid,
                Tags = ["Image Editing", "Adobe"],
                Icon = "https://icons.duckduckgo.com/ip2/www.adobe.com.ico"
            }
        );

        context.SaveChanges();
    }
}