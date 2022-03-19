using Dapper;
using FreeCourseProjectServicesDiscountAPI.Models;
using FreeCourseProjectServicesDiscountAPI.Services.Abstract;
using FreeCourseShared.Concrete;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourseProjectServicesDiscountAPI.Services.Conrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> CreateAsync(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("Insert into discount (userid,rate,code) values(@UserId,@Rate,@Code)", discount);

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("An error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id });

            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<Discount>>> GetAllAsync()
        {
            var discounts = await _dbConnection.QueryAsync<Discount>("Select * from discount");

            return Response<List<Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Discount>> GetByCodeAndUserIdAsync(string code, string userId)
        {
            var status=(await _dbConnection.QueryAsync<Discount>("Select * from discount where userid=@UserId and code=@Code", new {UserId=userId,Code=code})).FirstOrDefault();

            if (status == null)
            {
                return Response<Discount>.Fail("Discount not found", 404);
            }

            return Response<Discount>.Success(status, 200);
        }

        public async Task<Response<Discount>> GetByIdAsync(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Discount>("Select * from discount where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<Discount>.Fail("Discount not found", 404);
            }

            return Response<Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id", new { Id = discount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Discount not found", 404);
        }
    }
}
