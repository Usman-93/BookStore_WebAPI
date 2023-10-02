using BookStore_WebAPI.EndPoints;
using BookStore_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapBooksEndPoints();

app.Run();
