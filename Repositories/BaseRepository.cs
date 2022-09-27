using System.Data;
using DapperAppSample.Entities.Types;
using Npgsql;
using Npgsql.NameTranslation;

namespace DapperAppSample.Repositories
{
    public abstract class BaseRepository
    {
        private static readonly INpgsqlNameTranslator Translator = new NpgsqlSnakeCaseNameTranslator();

        protected readonly IConfiguration Configuration;
        protected readonly string ConnectionString;

        protected BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ConnectionString = Configuration.GetValue<string>("Database:ConnectionString");

            MapCompositeTypes();
        }

        protected virtual NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        private static void MapCompositeTypes()
        {
            var mapper = NpgsqlConnection.GlobalTypeMapper;
            mapper.MapComposite<MedicalCard>("medical_card", Translator);

            Dapper.SqlMapper.AddTypeMap(typeof(MedicalCard), DbType.Object);
        }
    }
}
