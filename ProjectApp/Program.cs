using ApplicationService;
using ApplicationService.Contract;
using EfCore;
using EfCore.Bootstrapper;
using EfCore.Contract;
using EfCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();


builder.Services.AddDbContext<ProjectDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Amnban")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
