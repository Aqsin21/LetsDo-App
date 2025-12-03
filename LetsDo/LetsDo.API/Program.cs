using LetsDo.DAL.Extension;
using LetsDo.BLL.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.builder.Services.AddDal(builder.Configuration);
builder.Services.AddDal(builder.Configuration);
builder.Services.AddBll();
builder.Services.AddControllers();
                
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
