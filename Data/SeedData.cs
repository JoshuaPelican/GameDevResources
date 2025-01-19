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
                Tags = ["Documentation", "Unity"]
            },
            new Resource
            {
                Name = "Blender",
                Type = ResourceType.Tool,
                URL = "https://www.blender.org/",
                Pricing = PricingModel.Free,
                Tags = ["3D Modeling", "Animation"]
            },
            new Resource
            {
                Name = "GIMP",
                Type = ResourceType.Tool,
                URL = "https://www.gimp.org/",
                Pricing = PricingModel.Free,
                Tags = ["Image Editing", "Open Source"]
            },
            new Resource
            {
                Name = "Unreal Engine Marketplace",
                Type = ResourceType.Website,
                URL = "https://www.unrealengine.com/marketplace",
                Pricing = PricingModel.Paid,
                Tags = ["Assets", "Marketplace"]
            },
            new Resource
            {
                Name = "Texture Haven",
                Type = ResourceType.Website,
                URL = "https://texturehaven.com/",
                Pricing = PricingModel.Free,
                Tags = ["Textures", "Free Resources"]
            },
            new Resource
            {
                Name = "Mixamo",
                Type = ResourceType.Tool,
                URL = "https://www.mixamo.com/",
                Pricing = PricingModel.Freemium,
                Tags = ["Animation", "Character Rigging"]
            },
            new Resource
            {
                Name = "Sprite Sheet Generator",
                Type = ResourceType.Generator,
                URL = "https://www.codeandweb.com/free-sprite-sheet-packer",
                Pricing = PricingModel.Free,
                Tags = ["Sprite", "Generator"]
            },
            new Resource
            {
                Name = "Tiled Map Editor",
                Type = ResourceType.Tool,
                URL = "https://www.mapeditor.org/",
                Pricing = PricingModel.Free,
                Tags = ["Map Editor", "Tilemap"]
            },
            new Resource
            {
                Name = "Godot Engine Documentation",
                Type = ResourceType.Website,
                URL = "https://docs.godotengine.org/",
                Pricing = PricingModel.Free,
                Tags = ["Documentation", "Godot"]
            },
            new Resource
            {
                Name = "Photoshop",
                Type = ResourceType.Tool,
                URL = "https://www.adobe.com/products/photoshop.html",
                Pricing = PricingModel.Paid,
                Tags = ["Image Editing", "Adobe"]
            }
        );

        context.SaveChanges();
    }
}