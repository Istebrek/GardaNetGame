using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs
{
    public class RolesDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
