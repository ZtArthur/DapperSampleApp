using Dapper;
using DapperAppSample.Entities;
using DapperAppSample.Entities.Types;

namespace DapperAppSample.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(IConfiguration configuration) 
            : base(configuration) { }

        public Task<IEnumerable<User>> GetAll()
        {
            var connection = CreateConnection();
            return connection.QueryAsync<User>("select * from users");
        }

        public Task<User> GetById(int id)
        {
            var connection = CreateConnection();
            return connection.QueryFirstOrDefaultAsync<User>("select * from users where id = @Id", new { Id = id });
        }

        public Task<int> Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var connection = CreateConnection();
            return connection.ExecuteAsync("insert into users (name, city, document) values (@Name, @City, @Document)",
                new { user.Name, user.City, user.Document });
        }

        public Task<int> Update(User user)
        {
            var connection = CreateConnection();
            return connection.ExecuteAsync("update users set name = @Name, city = @City where id = @Id",
                new { user.Name, user.City, user.Id });
        }

        public Task<int> Delete(int id)
        {
            var connection = CreateConnection();
            return connection.ExecuteAsync("delete from users where id = @Id", new { Id = id });
        }
    }
}
