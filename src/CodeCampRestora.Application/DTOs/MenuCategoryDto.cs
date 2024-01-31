namespace CodeCampRestora.Application.DTOs
{
    public class MenuCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ImagePath { get; set; }
        public string Base64Url { get; set; }
        public Guid RestaurantId { get; set; }
    }

    public class MenuCategoryGetAllDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}