using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dentistry.Model;

public partial class News
{
    public int NewsId { get; set; }

    public string? NewsTitle { get; set; }

    public string? NewsDesc { get; set; }

    public DateOnly? DatePublish { get; set; }

    public byte[]? NewsImage { get; set; }

    [Column("news_status", TypeName = "enum('Ожидание','Публикация')")]
    public string? NewsStatus { get; set; }


    public static string AddNews(string newsTitle, string newsDesc, byte[] newsImg)
    {
        if (string.IsNullOrWhiteSpace(newsTitle))
            return "Заполните название статьи";
        if (string.IsNullOrWhiteSpace(newsDesc))
            return "Заполните описание статьи";
        if (newsImg == null)
            return "Заполните изображение для статьи";

        using (var context = new DbDentistryContext())
        {
            context.News.Add(new News
            {
                NewsTitle = newsTitle,
                NewsDesc = newsDesc,
                DatePublish = DateOnly.FromDateTime(DateTime.Now),
                NewsImage = newsImg,
                NewsStatus = "Ожидание"
            });
            context.SaveChanges();
            return "Успешно сохранено";
        }
    }
}
