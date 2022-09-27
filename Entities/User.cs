using DapperAppSample.Entities.Types;

namespace DapperAppSample.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public MedicalCard Document { get; set; }
    }
}
