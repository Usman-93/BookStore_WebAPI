using BookStore_WebAPI.EndPoints;
using BookStore_WebAPI.Entities;
using BookStore_WebAPI.Respositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBooksRepository, InMemBooksRepository>();


var app = builder.Build();

app.MapBooksEndPoints();

app.Run();
