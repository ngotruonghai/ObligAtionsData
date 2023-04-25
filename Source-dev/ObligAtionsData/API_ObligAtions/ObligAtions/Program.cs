using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ObligAtions.DependencyInjection;
using ObligAtions.Middlewares;
using ObligAtions.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new DependencyRegister());
    });

#region JWT

builder.Services.AddSwaggerGen(swag =>
{
    swag.SwaggerDoc("v1", new OpenApiInfo { Title = "ObligAtions", Version = "v1.0" });
    swag.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "ObligAtions",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.",
        Scheme = "Bearer"
    });
    swag.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    swag.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    // Set the comments path for the Swagger JSON and UI.
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //swag.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#endregion

#region  Configure strongly typed settings object (use key value for appsetting file)

builder.Services.Configure<UserConnectSqlViewModel>(builder.Configuration.GetSection("UserConnectSqlViewModel"));
builder.Services.Configure<JwtViewModel>(builder.Configuration.GetSection("JwtViewModel"));

#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorWrapping();

app.UseAuthentication();

app.UseStatusCodePages();

app.UseRouting();

app.MapControllers();

app.Run();
