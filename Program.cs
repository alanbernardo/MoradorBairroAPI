using MoradorBairroAPI.Services;
var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços da API
builder.Services.AddControllers();
builder.Services.AddSingleton<MoradorService>();
builder.Services.AddSingleton<BairroService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Habilita os endpoints dos controllers

app.Run();
