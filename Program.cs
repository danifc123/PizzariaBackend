using Microsoft.EntityFrameworkCore;
using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Adicionar os serviços ao contêiner
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<SubcategoriaService>();
builder.Services.AddScoped<CuponsService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ConfiguracoesService>();

// Adicionar suporte a controladores
builder.Services.AddControllers();

// Adicionar Swagger e configurar
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Pizzaria API",
        Version = "v1",
        Description = "API para gerenciar uma pizzaria"
    });
});

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizzaria API v1");
        c.RoutePrefix = string.Empty; // Deixa o Swagger acessível na raiz "/"
    });
}

// Middleware padrão
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

app.Run();
