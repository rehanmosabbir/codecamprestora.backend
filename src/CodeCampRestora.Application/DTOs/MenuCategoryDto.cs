namespace CodeCampRestora.Application.DTOs
{
    public class MenuCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ImagePath { get; set; }
        public Guid RestaurantId { get; set; }
    }
}