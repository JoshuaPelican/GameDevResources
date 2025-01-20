using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameDevResources.Models
{
    public class Resource
    {
        public int ID { get; set; }

        [Required, StringLength(60, MinimumLength = 2)]
        public required string Name { get; set; }

        [EnumDataType(typeof(ResourceType))]
        public ResourceType Type { get; set; }

        [Required, Url]
        public required string URL { get; set; }

        [Required, EnumDataType(typeof(PricingModel))]
        public PricingModel Pricing { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        [Url]
        public string? Icon { get; set; }
    }
}

public enum ResourceType
{
    File,
    Website,
    Tool,
    Generator
}

public enum PricingModel
{
    Free,
    Freemium,
    Paid
}

public static class ResourceTypeExtensions
{
    public static string ToColor(this ResourceType category)
    {
        switch (category)
        {
            case ResourceType.File: return "#10c469";
            case ResourceType.Website: return "#f9c851";
            case ResourceType.Tool: return "#188ae2";
            case ResourceType.Generator: return "#5b69bc";
        }
        return string.Empty;
    }
}