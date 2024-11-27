var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container.
builder.Services.AddControllers(); // Suporte para controladores MVC.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS (se necessário).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configurar o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Aplica a política de CORS.
app.UseAuthorization();

app.MapControllers(); // Mapeia controladores para endpoints.

app.Run();
