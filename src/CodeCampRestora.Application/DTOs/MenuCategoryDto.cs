namespace CodeCampRestora.Application.DTOs
{
    public class MenuCategoryDto
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public Guid RestaurantId { get; set; }
    }
}