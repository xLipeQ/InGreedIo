using InGreed_API.Enums;

namespace InGreed_API.Dtos
{
    public class Person
    {
        public int Id { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
