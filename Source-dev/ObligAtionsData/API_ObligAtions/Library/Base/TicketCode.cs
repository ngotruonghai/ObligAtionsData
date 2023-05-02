using System.Reflection;

namespace Library.Base;

public static class TicketCode
{
    private static readonly Random rnd = new Random(10);
    private static DateTime date= DateTime.Now ;

    /// <summary>
    /// Render ra mã Ticket
    /// </summary>
    /// <param name="Ticket">Tên Ticket</param>
    /// <returns>Mã</returns>
    public static string RenderCode(string Ticket)
    {
        int codeRandom = (int.Parse(date.ToString("hhmmss")) + rnd.Next(1, 200))/rnd.Next(2,9);
        int codeHeader = rnd.Next() / 2;
        string TicketCode = string.Format("{0}{1}{2}", Ticket, codeHeader, codeRandom.ToString());
        return TicketCode;
    }
}
