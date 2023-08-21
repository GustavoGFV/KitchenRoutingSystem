using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Services;
using Kitchen_Routing_System.Services.Queue;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
/// </summary>
///In this setup this is a non stop process, it is always running and logging any possible error that happens in the threads.
///I usually dont use this types of storage, so its something "new" to me.
///
///Neste setup ele é um processo sem pausas, sempre esta rodando e registrando log de qualquer erro que ocorra dentro da fila.
///Geralmente eu não utilizo esse tipo de armazenamento então é como se fosse algo "novo" para mim.
/// </summary>

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderQueue, OrderQueue>();
builder.Services.AddHostedService<OrderService>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Storage/app.log")
    .CreateLogger();

builder.Logging.AddSerilog();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
