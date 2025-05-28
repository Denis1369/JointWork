using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dentistry.Model;

public partial class Service
{
    public int ServicesId { get; set; }

    public string? ServicesTitle { get; set; }

    public string? ServicesDesc { get; set; }

    public int? ServicesPrice { get; set; }

    public int? ServicesTypeId { get; set; }

    public virtual ServicesType? ServicesType { get; set; }

    public static string AddService(string title, string desc, string price, int type)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "Заполните название услуги";
        if (string.IsNullOrWhiteSpace(desc))
            return "Заполните описание услуги";
        if (!int.TryParse(price, out int intPrice) || intPrice <= 0)
            return "Цена должна быть положительным числом";

        using (var context = new DbDentistryContext())
        {
            context.Services.Add(
                new Service
                {
                    ServicesTitle = title,
                    ServicesDesc = desc,
                    ServicesPrice = intPrice,
                    ServicesTypeId = type
                }
            );
            context.SaveChanges();
            return "Успешно сохранено";
        }
    }

    public static string ModService(int id, string title, string desc, string price, int type)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "Заполните название услуги";
        if (string.IsNullOrWhiteSpace(desc))
            return "Заполните описание услуги";
        if (!int.TryParse(price, out int intPrice) || intPrice <= 0)
            return "Цена должна быть положительным числом";

        using (var context = new DbDentistryContext())
        {
            var service = context.Services
                .Include(s => s.ServicesType)
                .FirstOrDefault(s => s.ServicesId == id);

            if (service == null)
                return "Услуга не найдена";

            var serviceType = context.ServicesTypes.Find(type);
            if (serviceType == null)
                return "Указанный тип услуги не существует";

            service.ServicesTitle = title.Trim();
            service.ServicesDesc = desc.Trim();
            service.ServicesPrice = intPrice;
            service.ServicesTypeId = type;

            try
            {
                context.SaveChanges();
                return "Изменения сохранены";
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }
}
