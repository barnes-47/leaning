using WebApi.Infrastructure.DataAccess.Base;

namespace WebApi.Infrastructure.Dto
{
    public class User : Entity
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Branch { get; set; }
    }
}
