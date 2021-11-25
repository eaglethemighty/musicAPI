using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository;
using MusicAPIMVC.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string ConnectionString = builder.Configuration.GetConnectionString("MusicDBAccess");

builder.Services.AddDbContext<MusicDBAccess>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IRepositoryCRUD<Album>, AlbumRepository>();
builder.Services.AddScoped<IRepositoryCRUD<Artist>, ArtistRepository>();
builder.Services.AddScoped<IRepositoryCRUD<Genre>, GenreRepository>();
builder.Services.AddScoped<IRepositoryCRUD<Playlist>, PlaylistRepository>();
builder.Services.AddScoped<IRepositoryCRUD<Song>, SongRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
