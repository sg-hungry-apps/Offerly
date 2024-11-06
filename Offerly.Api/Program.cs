using Microsoft.AspNetCore.Mvc;
using Offerly.Api.Middleware;
using Offerly.Api.Responses;
using Offerly.Application.CommandHandlers;
using Offerly.Infrastructure.Bootstrapping;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //TODO SG clean this up by using extensions methods
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetOffersCommandHandler>());
        builder.Services.AddQueries();
        builder.Services.AddRepositories();

        var connectionString = builder.Configuration.GetConnectionString("OfferlyDbConnection");
        builder.Services.AddDbContext<OfferlyDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddMvc()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage)).ToList();

                var apiResponse = new ApiResponse(errors);

                return new BadRequestObjectResult(apiResponse);
            };
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //TODO SG add middleware for defending against XSS or SQL attacks
        //TOOD SG add middleware for checking request headers and response headers
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("origins");

        app.Run();
    }
}