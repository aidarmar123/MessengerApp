using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Domain.Constants;
using MessengerApi.Domain.Entities;
using MessengerApi.Domain.Enums;
using MessengerApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MessengerApi.Infrastructure.Data;



public class ApplicationDbContextInitialiser
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;


    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
       
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при заполнении БД тестовыми данными.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // 1. Тестовые пользователи (из твоего Supabase)
        var userAidarId = Guid.Parse("cd0d5407-7b09-453f-a7ee-799dd3860a5d");
        var userAidaId = Guid.Parse("a1db7283-0792-40ad-9d99-6b71f9594213");

        if (!await _context.User.AnyAsync())
        {
            var users = new List<User>
            {
                new User { Id = userAidarId, Displayname = "adi", FirstName = "Aidar", Alice = "ajdar@mail.com" },
                new User { Id = userAidaId, Displayname = "Aida", FirstName = "Aida", Alice = "test@gmail.com" }
            };
            _context.User.AddRange(users);
        }

        // 2. Тестовые чаты (MovieId = ChatId из твоего SQL)
        if (!await _context.Chats.AnyAsync())
        {
            var chatHarryPotter = new Chat
            {
                Id = Guid.Parse("0dac2cc4-fe3f-4af3-bbb7-b9399c3269f9"),
                Title = "Гарри Поттер и Философский камень",
                Type = ChatType.Group // Допустим, обсуждение фильма — это группа
            };

            var chatInterstellar = new Chat
            {
                Id = Guid.Parse("30747689-746a-4c45-9466-46046adcbea5"),
                Title = "Интерстеллар",
                Type = ChatType.Group
            };

            var chatDune = new Chat
            {
                Id = Guid.Parse("feb50081-1804-4587-9899-25b8321fa87f"),
                Title = "Дюна: Часть вторая",
                Type = ChatType.Group
            };

            _context.Chats.AddRange(chatHarryPotter, chatInterstellar, chatDune);

            // 3. Автоматически добавляем пользователей в эти чаты (ChatMembers)
            // Чтобы во Flutter чаты сразу отобразились в списке
            var members = new List<ChatMember>
            {
                new ChatMember { ChatId = chatHarryPotter.Id, UserId = userAidarId, Role = ChatRole.Admin },
                new ChatMember { ChatId = chatHarryPotter.Id, UserId = userAidaId, Role = ChatRole.Member },
                new ChatMember { ChatId = chatInterstellar.Id, UserId = userAidarId, Role = ChatRole.Admin },
                new ChatMember { ChatId = chatDune.Id, UserId = userAidaId, Role = ChatRole.Admin }
            };

            _context.ChatMembers.AddRange(members);
        }

        await _context.SaveChangesAsync(default);
    }
}
