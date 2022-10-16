using System.Globalization;

namespace first_api.Models;

public class TaskModel
{
    public int? Id { get; set; }
    public string Content { get; set; } = default!;
    public string? Date { get; set; } = DateTime.Now.ToString(new CultureInfo("es-MX"));
}