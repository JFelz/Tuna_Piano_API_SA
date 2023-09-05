using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Tuna_Piano.Models;
using Tuna_Piano;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost",
                              "https://localhost")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

/*builder.Services.AddNpgsql*/
builder.Services.AddNpgsql<Tuna_PianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

//JSON Serializer
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

//APIEndpoints

app.MapGet("/songs", (Tuna_PianoDbContext db) =>
{
    return db.Songs.ToList();
});

app.MapGet("/songs/{SongId}", (Tuna_PianoDbContext db, int SongId) =>
{
    return db.Songs.Where(s => s.Id == SongId)
                    .Include(s => s.Artists)
                    .Include(g => g.SonGen)
                    .ThenInclude(g => g.Genres)
                    .ToList();
});

app.MapPost("/songs/new", (Tuna_PianoDbContext db, Song AddSong) =>
{
    Song NewSong = AddSong;
    db.Songs.Add(NewSong);
    db.SaveChanges();

    return Results.Created($"/songs/new", AddSong);
});

app.MapPut("/songs/{SongId}", (Tuna_PianoDbContext db, int SongId, Song song) =>
{
    //Selecting the song to update
    Song SelectedSong = db.Songs.FirstOrDefault(s => s.Id == SongId);
    if (SelectedSong == null)
    {
        Results.NotFound("Sorry. Song does not exist!");
    }
    //Updating the song the user selected
    SelectedSong.Title = song.Title;
    SelectedSong.ArtistId = song.ArtistId;
    SelectedSong.Album = song.Album;
    SelectedSong.length = song.length;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/songs/{Id}", (Tuna_PianoDbContext db, int Id ) =>
{
    Song SelectedSong = db.Songs.FirstOrDefault(s => s.Id == Id);
    if (SelectedSong == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(SelectedSong);
    db.SaveChanges();
    return Results.NoContent();
});

//Artists
app.MapGet("/artists", (Tuna_PianoDbContext db) =>
{
    return db.Artists.ToList();
});

app.MapPost("/artists/new", (Tuna_PianoDbContext db, Artist NewArtist) =>
{
    Artist AddedArtist = NewArtist;
    db.Artists.Add(AddedArtist);
    db.SaveChanges();
    return Results.Ok();
});

app.MapPut("artists/{Id}", (Tuna_PianoDbContext db, int Id, Artist editArtist) =>
{
    Artist SelectedArtist = db.Artists.FirstOrDefault(a => a.Id == Id);
    if (SelectedArtist == null)
    {
        return Results.NotFound("Sorry, the artist does not exist");
    }

    SelectedArtist.Name = editArtist.Name;
    SelectedArtist.Age = editArtist.Age;
    SelectedArtist.Bio = editArtist.Bio;
    db.SaveChanges();
    return Results.NoContent();

});

app.MapDelete("/artists/{Id}", (Tuna_PianoDbContext db, int Id) =>
{
    Artist DeletedArtist = db.Artists.FirstOrDefault(d => d.Id == Id);
    if (DeletedArtist == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(DeletedArtist);
    db.SaveChanges();
    return Results.Ok();
});

// Return to this one
// Get Artists with their respective songs
app.MapGet("/artists/{Id}", (Tuna_PianoDbContext db, int Id) =>
{
    return db.Artists.Where(a => a.Id == Id);
                     //.Include(s => s.ArtSon)
                     //.ThenInclude(s => s.Songs)
                     //.ToList();
});

//Genres
app.MapGet("/genres", (Tuna_PianoDbContext db) =>
{
    return db.Genres.ToList();
});

app.MapPost("", () =>
{

});

app.MapPut("", () =>
{

});

app.MapDelete("", () =>
{

});

app.MapGet("", () =>
{

});


app.Run();
