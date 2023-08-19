using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

    // Configure the HTTP request pipeline.
    // 非開發模式會進入此內容
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


//下列程式碼會啟用Middleware(中介軟體)
app.UseHttpsRedirection();      //將HTTP請求重新導向至HTTPS
app.UseStaticFiles();           //允許使用靜態檔案，例如HTML, CSS, JS, 影像檔案

app.UseRouting();               //將Routing(路由)比對新增至Middleware管線。

app.UseAuthorization();         //授權使用者存取安全資源。

app.MapRazorPages();            //設定頁面的Razor端點路由

app.Run();                      //執行應用程式
