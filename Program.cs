using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var bot = new TelegramBotClient("8745569184:AAEvQ2pJ1UPOPxtQUMEug9M2ihYFb1f6ErI");

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

bot.StartReceiving(
    async (client, update, token) =>
    {
        try
        {
            if (update.Message?.Text == null) return;

            string text = update.Message.Text.Trim();
            long chatId = update.Message.Chat.Id;

            Console.WriteLine("RAW: [" + text + "]");

            // ================= /START =================
            if (text == "/start")
            {
                ReplyKeyboardMarkup menu = new(new[]
                {
                    new KeyboardButton[]
                    {
                        "📌 Link nhóm tổng",
                        "📞 Liên hệ QC"
                    },
                    new KeyboardButton[]
                    {
                        "👑 ADMIN",
                        "💬 Nhóm chat"
                    },
                    new KeyboardButton[]
                    {
                        "🎬 Kênh phim - Video hot",
                        "⚠️ Nhóm phốt scam"
                    }
                })
                {
                    ResizeKeyboard = true
                };

                await client.SendMessage(
                    chatId,
                    "Xin chào 👋 bạn muốn mình giúp gì?",
                    replyMarkup: menu
                );

                return;
            }

            // ================= MENU =================
            if (text == "📌 Link nhóm tổng")
            {
                await client.SendMessage(chatId,
                    "📌 Link nhóm tổng:\nhttps://t.me/nhomtonghoptele");
            }
            else if (text == "📞 Liên hệ QC")
            {
                await client.SendMessage(chatId,
                    "📞 Liên hệ: @hlong2607");
            }
            else if (text == "👑 ADMIN")
            {
                await client.SendMessage(chatId,
                    "👑 ADMIN: @hlong2607");
            }
            else if (text == "💬 Nhóm chat")
            {
                await client.SendMessage(chatId,
                    "💬 Nhóm chat 01:\nhttps://t.me/+YOl-mdMg7Wk4OTll\n\n" +
                    "💬 Nhóm chat 02:\nhttps://t.me/+UsKJQjPFjXQ1NGJl");
            }
            else if (text == "🎬 Kênh phim - Video hot")
            {
                await client.SendMessage(chatId,
                    "🎬 Kho phim:\nhttps://t.me/videohottele2\n\n" +
                    "🔥 Video hot:\nhttps://t.me/video18tele\n\n" +
                    "🍜 Phở bò:\nhttps://t.me/phobongontele26");
            }
            else if (text == "⚠️ Nhóm phốt scam")
            {
                await client.SendMessage(chatId,
                    "⚠️ Phốt scam:\nhttps://t.me/+tLVXjxIdUwc2OTc1");
            }
            else
            {
                await client.SendMessage(chatId,
                    "👉 Vui lòng chọn menu bên dưới /start");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    },

    async (client, exception, token) =>
    {
        Console.WriteLine("BOT ERROR: " + exception.Message);
    },

    receiverOptions
);

Console.WriteLine("Bot đang chạy...");
await Task.Delay(-1);