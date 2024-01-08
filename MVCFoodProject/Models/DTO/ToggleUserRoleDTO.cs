using System.Text.Json.Serialization;

namespace MVCFoodProject.Models.DTO
{
    public class ToggleUserRoleDTO
    {
            public int Id { get; set; }

            [JsonConverter(typeof(JsonStringEnumConverter))]
            public ACTION action { get; set; }

            public enum ACTION
            {
                role_courier,
                role_customer
            }
    }
}
