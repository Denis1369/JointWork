using System;
using System.Collections.Generic;

namespace dentistry.Model;

public partial class Entry
{
    public int EntryId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? EntryStatus { get; set; }

    public static async Task<bool> UpdateEntryStatusAsync(int entryId, string newStatus)
    {
        using (var context = new DbDentistryContext())
        {
            var entry = await context.Entries.FindAsync(entryId);
            if (entry == null)
                return false;

            entry.EntryStatus = newStatus;
            await context.SaveChangesAsync();
            EmailServis emailServis = new EmailServis();
            var list = new List<string>();
            switch (newStatus)
            {
                case "Ожидание":
                    list = emailServis.GenerateExpectationEmail(entry.UserName, entry.DateTime);
                    break;
                case "Подтвержден":
                    list = emailServis.GenerateConfirmationEmail(entry.UserName, entry.DateTime);
                    break;
                case "Отменено":
                    list = emailServis.GenerateCancellationEmail(entry.UserName, entry.DateTime);
                    break;
            }

            if (list.Count >= 2)
            {
                EmailServis.SendMessage(entry.UserEmail, list[0], list[1]);
            }

            return true;
        }
    }
}
