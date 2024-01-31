namespace CodeCampRestora.Application.DTOs
{
    public class MenuItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public bool? Availability { get; set; }
        public int? DisplayOrder { get; set; }
        public string ImagePath { get; set; }
        public string Base64Url { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BranchId { get; set; }
    }

    public class MenuItemDisplayOrderDto
    {
        public Guid Id { get; set; }
        public int DisplayOrder { get; set; }
    }
}