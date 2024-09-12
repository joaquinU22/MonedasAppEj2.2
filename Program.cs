var builder = WebApplication.CreateBuilder(args);//crea builder para la aplicacion web

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//configuran Swagger para la documentacion de la api. es util para pruebas y visualizacion
builder.Services.AddControllers();//agrega soporte para controladores 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //se activan en el entorno de desarrollo para permitir el uso de Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
