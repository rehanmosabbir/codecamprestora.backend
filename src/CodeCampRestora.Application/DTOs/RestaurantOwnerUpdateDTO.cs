namespace CodeCampRestora.Application.DTOs
{
    public class RestaurantOwnerUpdateDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string CurrentPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }
}
