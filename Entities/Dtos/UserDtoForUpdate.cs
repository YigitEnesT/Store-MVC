namespace Entities.Dtos
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<String> UserRoles { get; set; }   = new HashSet<string>();
    }
}