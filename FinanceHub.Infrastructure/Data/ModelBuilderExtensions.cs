using FinanceGub.Application.Helpers;
using FinanceHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Define fixed Guids for users
        var oleksiiId = Guid.NewGuid();
        var olenaId = Guid.NewGuid();
        var maksymId = Guid.NewGuid();
        var katerynaId = Guid.NewGuid();
        var andriyId = Guid.NewGuid();
        var yuliaId = Guid.NewGuid();
        var lisaId = Guid.NewGuid();
        var finhubId = Guid.NewGuid();

        var hub1Id = Guid.NewGuid();
        var hub2Id = Guid.NewGuid();

        var postIds = Enumerable.Range(0, 24).Select(_ => Guid.NewGuid()).ToList();

        var comment1Id = Guid.NewGuid();
        var comment2Id = Guid.NewGuid();
        var comment3Id = Guid.NewGuid();

        var joinRequestId = Guid.NewGuid();

        var roleAdminId = Guid.NewGuid();
        var roleUserId = Guid.NewGuid();
        var roleModeratorId = Guid.NewGuid();

        modelBuilder.Entity<AppRole>().HasData(
            new AppRole
            {
                Id = roleAdminId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new AppRole
            {
                Id = roleUserId,
                Name = "Member",
                NormalizedName = "MEMBER"
            },
            new AppRole
            {
                Id = roleModeratorId,
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            }
        );

        // modelBuilder.Entity<AppUserRole>().HasData(
        //     new AppUserRole
        //     {
        //         UserId = user1Id, // johndoe
        //         RoleId = roleUserId
        //     },
        //     new AppUserRole
        //     {
        //         UserId = user2Id, // admin
        //         RoleId = roleAdminId
        //     },
        //     new AppUserRole
        //     {
        //         UserId = user3Id, // admin
        //         RoleId = roleUserId
        //     }
        // );


        // Seed data for Users 7
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = oleksiiId,
                UserName = "олексій",
                Email = "oleksii@gmail.com",
                PasswordHash = PasswordHasher.HashPassword("User123!"),
                Bio = "Цікаво дізнатися більше про фінанси.",
                Country = "Україна",
                CreatedAt = DateTime.UtcNow.AddDays(-50),
                LastActive = DateTime.UtcNow.AddDays(-2)
            },
            new User
            {
                Id = olenaId,
                UserName = "олена_інвест",
                Email = "olena.p@gmail.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Люблю інвестиції і фінанси.",
                Country = "Україна",
                CreatedAt = DateTime.UtcNow.AddDays(-50),
                LastActive = DateTime.UtcNow.AddDays(-2)
            },
            new User
            {
                Id = finhubId,
                UserName = "finhub",
                Email = "finhub@gmail.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Твоя комфортна фінансова соціальна мережа.",
                Country = "Україна",
                CreatedAt = DateTime.UtcNow.AddDays(-50)
            },
            new User
            {
                Id = maksymId,
                UserName = "трейдер_макс",
                Email = "maks.t@gmail.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Досвідчений трейдер, ділюся аналітикою та ідеями.",
                Country = "Польща",
                CreatedAt = DateTime.UtcNow.AddDays(-45),
                LastActive = DateTime.UtcNow.AddHours(-5)
            },
            new User
            {
                Id = katerynaId,
                UserName = "крипто_катя",
                Email = "kate.c@gmail.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Все про блокчейн, NFT та криптовалюти. Слідкуйте за оновленнями!",
                Country = "Україна",
                CreatedAt = DateTime.UtcNow.AddDays(-30),
                LastActive = DateTime.UtcNow.AddHours(-1)
            },
            new User
            {
                Id = andriyId,
                UserName = "аналітик_андрій",
                Email = "andriy.a@emgmailil.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Фінансовий аналітик. Розбираю звітності компаній та макроекономічні тренди.",
                Country = "Німеччина",
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                LastActive = DateTime.UtcNow.AddDays(-3)
            },
            new User
            {
                Id = yuliaId,
                UserName = "фінанси_юлія",
                Email = "yulia.f@gmail.com",
                PasswordHash = FinanceGub.Application.Helpers.PasswordHasher.HashPassword("User123!"),
                Bio = "Веду блог про особисті фінанси, бюджетування та заощадження.",
                Country = "Україна",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                LastActive = DateTime.UtcNow.AddHours(-12)
            },
            new User
            {
                Id = lisaId,
                UserName = "Ліза",
                Email = "lisa@1",
                PasswordHash = PasswordHasher.HashPassword("1"),
                Country = "Україна",
                Bio =
                    "Passionate about smart money management and personal growth. Tracking goals, budgeting wisely, and always learning something new about finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                LastActive = DateTime.UtcNow.AddHours(-12)
            }
        );

        // Seed data for Profiles
        // modelBuilder.Entity<Profile>().HasData(
        //     new Profile
        //     {
        //         Id = Guid.NewGuid(),
        //         UserId = user1Id, 
        //         PhoneNumber = "+1234567890",
        //         Country = "USA",
        //         CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         DateOfBirth =  DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc)
        //     },
        //     new Profile
        //     {
        //         Id = Guid.NewGuid(),
        //         UserId = user2Id, 
        //         PhoneNumber = "+9876543210",
        //         Country = "Canada",
        //         CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         DateOfBirth =  DateTime.SpecifyKind(new DateTime(2000, 10, 10), DateTimeKind.Utc)
        //     }
        // );

        //Seed data for Post
        // modelBuilder.Entity<Post>().HasData(
        //     new Post
        //     {
        //         Id = post1Id,
        //         AuthorId = olenaId,
        //         Content = "Всім привіт! Написала статтю про те, як вибрати свого першого брокера."
        //         CreatedAt = DateTime.UtcNow.AddDays(-10),
        //         UpdatedAt = DateTime.UtcNow.AddDays(-5),
        //     },
        //     new Post
        //     {
        //         Id = post2Id,
        //         AuthorId = user2Id,
        //         Content = "Exploring advanced strategies in finance.",
        //         CreatedAt = DateTime.UtcNow.AddDays(-20),
        //         UpdatedAt = DateTime.UtcNow.AddDays(-2)
        //     });

        var hub3Id = Guid.NewGuid();
        var hub4Id = Guid.NewGuid();
        var hub5Id = Guid.NewGuid();

        // --- 5. Створення Хабів ---
        modelBuilder.Entity<Hub>().HasData(
    // Існуючі хаби
    new Hub
    {
        Id = hub1Id,
        Name = "Інвестиції для початківців",
        Description = "Спільнота для тих, хто робить перші кроки у світі інвестицій.",
        PostPermission = "public"
    },
    new Hub
    {
        Id = hub2Id,
        Name = "Криптотрейдинг 24/7",
        Description = "Простір для активних трейдерів, де ринок ніколи не спить.",
        PostPermission = "public"
    },

    // --- ДОДАНО 3 НОВІ ХАБИ ---
    new Hub
    {
        Id = hub3Id,
        Name = "Особистий бюджет та заощадження",
        Description = "Поради та лайфхаки про те, як ефективно управляти грошима і досягати фінансових цілей.",
        PostPermission = "public"
    },
    new Hub
    {
        Id = hub4Id,
        Name = "Аналіз фондового ринку",
        Description = "Глибокий аналіз компаній, секторів та ринкових трендів. Ділимося звітами та прогнозами.",
        PostPermission = "moderated"
    },
    new Hub
    {
        Id = hub5Id,
        Name = "Інвестиції в нерухомість",
        Description = "Все про купівлю, продаж та оренду нерухомості в Україні та за кордоном.",
        PostPermission = "public"
    }
);

        // --- 6. Додавання Учасників до Хабів ---
        modelBuilder.Entity<HubMember>().HasData(
            // Існуючі учасники
            new HubMember { Id = Guid.NewGuid(), HubId = hub1Id, UserId = olenaId, Role = "Admin", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-40) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub1Id, UserId = yuliaId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-10) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub2Id, UserId = maksymId, Role = "Admin", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-20) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub2Id, UserId = katerynaId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-18) },

            // --- ДОДАНО УЧАСНИКІВ ДО НОВИХ ХАБІВ ---

            // Учасники хабу "Особистий бюджет та заощадження"
            new HubMember { Id = Guid.NewGuid(), HubId = hub3Id, UserId = yuliaId, Role = "Admin", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-30) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub3Id, UserId = olenaId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-25) },

            // Учасники хабу "Аналіз фондового ринку"
            new HubMember { Id = Guid.NewGuid(), HubId = hub4Id, UserId = andriyId, Role = "Admin", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-22) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub4Id, UserId = maksymId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-15) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub4Id, UserId = olenaId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-14) },

            // Учасники хабу "Інвестиції в нерухомість"
            new HubMember { Id = Guid.NewGuid(), HubId = hub5Id, UserId = maksymId, Role = "Admin", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-19) },
            new HubMember { Id = Guid.NewGuid(), HubId = hub5Id, UserId = andriyId, Role = "Member", IsApproved = true, JoinedAt = DateTime.UtcNow.AddDays(-17) }
        );

        // --- 7. Створення Підписок (Following) ---
        modelBuilder.Entity<Following>().HasData(
            new Following
            {
                Id = Guid.NewGuid(),
                FollowerId = olenaId,
                FollowingUserId = maksymId
            },
            new Following
            {
                Id = Guid.NewGuid(),
                FollowerId = maksymId,
                FollowingUserId = olenaId
            },
            new Following
            {
                Id = Guid.NewGuid(),
                FollowerId = yuliaId,
                FollowingUserId = olenaId
            },
            new Following
            {
                Id = Guid.NewGuid(),
                FollowerId = katerynaId,
                FollowingHubId = hub1Id
            }
        );

        #region Posts
        modelBuilder.Entity<Post>().HasData(
            // Пости від Олени (інвестиції для початківців)
            new Post
            {
                Id = postIds[0],
                AuthorId = olenaId,
                HubId = hub1Id,
                Content = "Друзі, як диверсифікуєте свій портфель? Скільки відсотків тримаєте в акціях, а скільки в облігаціях?",
                CreatedAt = DateTime.UtcNow.AddDays(-12)
            },
            new Post
            {
                Id = postIds[1],
                AuthorId = olenaId,
                HubId = hub1Id,
                Content = "Для початківців ETF – чудовий старт. Купуючи один інструмент, ви одразу інвестуєте в сотні компаній. Наприклад, в індекс S&P 500.",
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            },
            new Post
            {
                Id = postIds[2],
                AuthorId = olenaId,
                Content = "Сьогодні вперше отримала дивіденди. Невелика сума, але як же приємно розуміти, що твої гроші працюють!",
                CreatedAt = DateTime.UtcNow.AddDays(-8)
            },
            new Post
            {
                Id = postIds[3],
                AuthorId = olenaId,
                HubId = hub1Id,
                Content = "Хто що думає про акції Microsoft на довгострок? Здається, їхній фокус на AI дасть хороші плоди.",
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },

            // Пости від Максима (трейдинг)
            new Post
            {
                Id = postIds[4],
                AuthorId = maksymId,
                HubId = hub2Id,
                Content = "Ринок сьогодні дуже волатильний. Фіксую частину прибутку, краще синиця в руках.",
                CreatedAt = DateTime.UtcNow.AddDays(-7)
            },
            new Post
            {
                Id = postIds[5],
                AuthorId = maksymId,
                Content = "Найважче в трейдингу – це дисципліна. Вміння чекати на свій сетап і не піддаватися FOMO – ключ до успіху.",
                CreatedAt = DateTime.UtcNow.AddDays(-6)
            },
            new Post
            {
                Id = postIds[6],
                AuthorId = maksymId,
                HubId = hub2Id,
                Content = "На графіку EUR/USD формується 'голова і плечі'. Схоже, насувається корекція. Будьте обережні.",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
            },

            // Пости від Каті (криптовалюти)
            new Post
            {
                Id = postIds[7],
                AuthorId = katerynaId,
                HubId = hub2Id,
                Content = "Що думаєте про перспективи Solana (SOL)? Технологія вражає, але чи зможе вона конкурувати з Ethereum?",
                CreatedAt = DateTime.UtcNow.AddDays(-9)
            },
            new Post
            {
                Id = postIds[8],
                AuthorId = katerynaId,
                Content = "HODL – це не просто мем, це стратегія. В довгостроковій перспективі віра в технологію винагороджується.",
                CreatedAt = DateTime.UtcNow.AddDays(-7)
            },
            new Post
            {
                Id = postIds[9],
                AuthorId = katerynaId,
                HubId = hub2Id,
                Content = "Не забувайте переводити крипту з бірж на холодні гаманці. 'Not your keys, not your coins!' – золоте правило.",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },
            new Post
            {
                Id = postIds[10],
                AuthorId = katerynaId,
                Content = "Ринок NFT зараз переживає не найкращі часи, але це гарна можливість придивитися до фундаментально сильних проєктів.",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },

            // Пости від Юлії (особисті фінанси)
            new Post
            {
                Id = postIds[11],
                AuthorId = yuliaId,
                Content = "Спробувала правило 50/30/20 для бюджетування (50% – потреби, 30% – бажання, 20% – заощадження). Дуже дисциплінує!",
                CreatedAt = DateTime.UtcNow.AddDays(-11)
            },
            new Post
            {
                Id = postIds[12],
                AuthorId = yuliaId,
                HubId = hub1Id,
                Content = "Де ви зберігаєте свою фінансову подушку? Депозит, ОВДП чи просто на картці? Шукаю найнадійніший варіант.",
                CreatedAt = DateTime.UtcNow.AddDays(-9)
            },
            new Post
            {
                Id = postIds[13],
                AuthorId = yuliaId,
                Content = "Найкраща інвестиція – це інвестиція в себе. Курси, книги, здоров'я – це те, що завжди окупиться.",
                CreatedAt = DateTime.UtcNow.AddDays(-6)
            },
            new Post
            {
                Id = postIds[14],
                AuthorId = yuliaId,
                Content = "Щоб не робити імпульсивних покупок, завжди чекаю 24 години перед тим, як щось купити онлайн. Часто бажання зникає.",
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },

            // Пости від Андрія (аналітика)
            new Post
            {
                Id = postIds[15],
                AuthorId = andriyId,
                HubId = hub1Id,
                Content = "Сектор напівпровідників виглядає перегрітим. P/E коефіцієнти деяких компаній, як-от Nvidia, просто захмарні.",
                CreatedAt = DateTime.UtcNow.AddDays(-8)
            },
            new Post
            {
                Id = postIds[16],
                AuthorId = andriyId,
                Content = "Інфляція в єврозоні сповільнюється, але повільніше, ніж очікувалося. Це може змусити ЄЦБ тримати ставки високими довше.",
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Post
            {
                Id = postIds[17],
                AuthorId = andriyId,
                HubId = hub1Id,
                Content = "Згідно зі звітом Goldman Sachs, ринки, що розвиваються, можуть показати кращу динаміку в наступному році. Погоджуєтесь?",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },
            new Post
            {
                Id = postIds[18],
                AuthorId = andriyId,
                Content = "Ніколи не інвестуйте в бізнес, який ви не розумієте. Це просте правило Воррена Баффета врятувало мені багато грошей.",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new Post
            {
                Id = postIds[19],
                AuthorId = finhubId,
                Content = "Вітаємо на FinanceHub! Ми оновили правила спільноти. Будь ласка, ознайомтеся.",
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            },
            new Post
            {
                Id = postIds[20], // <-- Переконайтесь, що індекс вільний
                AuthorId = andriyId,
                HubId = hub1Id,
                Content = "Microsoft ($MSFT) продовжує вражати. Їхній сегмент 'Intelligent Cloud' з Azure зростає шаленими темпами. Це вже не просто 'Windows і Office', а справжній хмарний гігант.",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },

            // Пост про Google від аналітика
            new Post
            {
                Id = postIds[21], // <-- Переконайтесь, що індекс вільний
                AuthorId = andriyId,
                HubId = hub1Id,
                Content = "Alphabet ($GOOGL) — це машина для друку грошей. Монополія в пошуку та доходи від YouTube/Android дають їм змогу фінансувати будь-які 'інші ставки'. Поки їхній рекламний бізнес сильний, акції залишатимуться фундаментально міцними.",
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },

            // Пост про Binance від крипто-ентузіаста
            new Post
            {
                Id = postIds[22], // <-- Переконайтесь, що індекс вільний
                AuthorId = katerynaId,
                HubId = hub2Id,
                Content = "Попри всі регуляторні виклики, Binance залишається найбільшою біржею за обсягом торгів. Їхня екосистема з BNB Chain, Launchpad та іншими сервісами все ще домінує на ринку.",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },

            // Пост про заощадження та інвестиції від блогера
            new Post
            {
                Id = postIds[23], // <-- Переконайтесь, що індекс вільний
                AuthorId = yuliaId,
                Content = "Багато хто питає, з чого почати інвестувати. Відповідь проста: почніть заощаджувати. Неможливо інвестувати гроші, яких у вас немає. Створіть 'фонд для інвестицій', відкладаючи хоча б 10% доходу.",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        );
        #endregion

        modelBuilder.Entity<PostImage>().HasData(
            new PostImage
            {
                Id = Guid.NewGuid(),
                PostId = postIds[20], // <-- Прив'язка до першого поста Олени
                ImageUrl = "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post3.jpg" // <-- Ваше посилання на фото
            },
            new PostImage
            {
                Id = Guid.NewGuid(),
                PostId = postIds[21], // <-- Прив'язка до поста Максима
                ImageUrl = "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/poat4.webp" // <-- Ваше посилання на інше фото
            },
            new PostImage
            {
                Id = Guid.NewGuid(),
                PostId = postIds[22], // <-- Прив'язка до поста Максима
                ImageUrl = "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post2.webp" // <-- Ваше посилання на інше фото
            },
            new PostImage
            {
                Id = Guid.NewGuid(),
                PostId = postIds[23], // <-- Прив'язка до поста Максима
                ImageUrl = "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post1.webp" // <-- Ваше посилання на інше фото
            }
        );

        // --- 9. Створення Коментарів ---
        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = comment1Id,
                PostId = postIds[0],
                AuthorId = yuliaId,
                Content = "Дуже корисна стаття, дякую! Особливо для новачків.",
                CreatedAt = DateTime.UtcNow.AddDays(-9)
            },
            new Comment
            {
                Id = comment2Id,
                PostId = postIds[3],
                AuthorId = olenaId,
                ParentId = comment1Id,
                Content = "Рада, що було корисно!",
                CreatedAt = DateTime.UtcNow.AddDays(-9).AddHours(2)
            },
            new Comment
            {
                Id = comment3Id,
                PostId = postIds[2],
                AuthorId = maksymId,
                Content = "Дякую за детальний аналіз!",
                CreatedAt = DateTime.UtcNow.AddHours(-6)
            }
        );

        // --- 10. Створення Лайків ---
        modelBuilder.Entity<Like>().HasData(
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = maksymId,
                PostId = postIds[0]
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = katerynaId,
                PostId = postIds[2]
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = olenaId,
                PostId = postIds[3]
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = yuliaId,
                PostId = postIds[4]
            }
        );

        // --- 12. Створення Сповіщень ---
        modelBuilder.Entity<Notification>().HasData(
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = olenaId,
                TriggeredBy = maksymId,
                Type = "like",
                Content = "трейдер_макс вподобав ваш пост.",
                PostId = postIds[0],
                IsRead = false,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = maksymId,
                TriggeredBy = olenaId,
                Type = "follow",
                Content = "олена_інвест почала стежити за вами.",
                IsRead = true,
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = maksymId,
                TriggeredBy = andriyId,
                Type = "joinRequest",
                Content = "аналітик_андрій хоче приєднатися до вашого хабу 'Криптотрейдинг 24/7'.",
                HubId = hub2Id,
                RequestId = joinRequestId,
                IsRead = false,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        );
    }

    //Seed data for Category
    // modelBuilder.Entity<Category>().HasData(
    //     new Category
    //     {
    //         Id = category1Id,
    //         Name = "Technology",
    //         Description = "Posts related to the latest technology trends"
    //     },
    //     new Category
    //     {
    //         Id = category2Id,
    //         Name = "Health",
    //         Description = "Health tips and news"
    //     },
    //     new Category
    //     {
    //         Id = category3Id,
    //         Name = "Education",
    //         Description = "Educational articles and resources"
    //     }
    // );

    //Seed data for PostCategory
    // modelBuilder.Entity<PostCategory>().HasData(
    //     new PostCategory
    //     {
    //         PostId = post1Id,
    //         CategoryId = category1Id
    //     },
    //     new PostCategory
    //     {
    //         PostId = post1Id,
    //         CategoryId = category3Id
    //     },
    //     new PostCategory
    //     {
    //         PostId = post2Id,
    //         CategoryId = category2Id
    //     },
    //     new PostCategory
    //     {
    //         PostId = post2Id,
    //         CategoryId = category3Id
    //     });

    // Seed data for Comments
    // modelBuilder.Entity<Comment>().HasData(
    //     new Comment
    //     {
    //         Id = comment1Id,
    //         PostId = post1Id,
    //         AuthorId = user1Id,
    //         Content = "Great introduction! Looking forward to learning more.",
    //         CreatedAt = DateTime.UtcNow.AddDays(-5),
    //         IsModified = false,
    //         ParentId = null
    //     },
    //     new Comment
    //     {
    //         Id = comment2Id,
    //         PostId = post1Id,
    //         AuthorId = user2Id,
    //         Content = "Interesting perspective on finance.",
    //         CreatedAt = DateTime.UtcNow.AddDays(-4),
    //         IsModified = false,
    //         ParentId = null
    //     },
    //     new Comment
    //     {
    //         Id = comment3Id,
    //         PostId = post2Id,
    //         AuthorId = user1Id,
    //         Content = "I found this article very helpful!",
    //         CreatedAt = DateTime.UtcNow.AddDays(-3),
    //         IsModified = false,
    //         ParentId = null
    //     }
    // );

    // modelBuilder.Entity<Like>().HasData(
    //     new Like
    //     {
    //         Id = Guid.NewGuid(),
    //         UserId = user1Id,
    //         PostId = post1Id
    //     },
    //     new Like
    //     {
    //         Id = Guid.NewGuid(),
    //         UserId = user2Id,
    //         PostId = post1Id
    //     },
    //     new Like
    //     {
    //         Id = Guid.NewGuid(),
    //         UserId = user1Id,
    //         PostId = post2Id
    //     }
    // );

    // modelBuilder.Entity<Hub>().HasData(
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Budgeting",
    //         Description = "Tips on managing money, saving, and budgeting.",
    //         PostPermission = "public"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Crypto",
    //         Description = "News and trends in crypto and blockchain.",
    //         PostPermission = "public"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Stocks",
    //         Description = "Market updates, analysis, and stock picks.",
    //         PostPermission = "public"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "FI/RE",
    //         Description = "Financial independence and early retirement.",
    //         PostPermission = "members"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Side Hustles",
    //         Description = "Ideas and stories on earning extra income.",
    //         PostPermission = "members"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Real Estate",
    //         Description = "Investing in properties and REITs.",
    //         PostPermission = "moderated"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Mindset",
    //         Description = "Money habits and financial motivation.",
    //         PostPermission = "public"
    //     },
    //     new Hub
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Finance News",
    //         Description = "Latest updates from the world of finance.",
    //         PostPermission = "moderated"
    //     }
    // );
}
